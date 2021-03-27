using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ScheduleService: ISchedule
    {
        CollegeM8Context _db;
        public ScheduleService(CollegeM8Context db)
        {
            _db = db;
        }

        public Schedule GenerateSchedule(Schedule scheduleRequest)
        {
            if (scheduleRequest.startDate > scheduleRequest.endDate || !_db.Users.AsNoTracking().Any(u => u.UserId == scheduleRequest.userId))
            {
                throw new ServiceException("Data invalid to create schedule.");
            }
            //Data Setup
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            Sleep sleep = _db.Sleep.AsNoTracking().FirstOrDefault(s => s.UserId == scheduleRequest.userId);
            Term[] terms = _db.Term.AsNoTracking().Where(t => t.UserId == scheduleRequest.userId).Where(t => (scheduleRequest.startDate >= t.StartDate && scheduleRequest.startDate <= t.EndDate) ||
            (scheduleRequest.endDate <= t.EndDate && scheduleRequest.endDate >= t.StartDate) ||
            (scheduleRequest.startDate <= t.StartDate && scheduleRequest.endDate >= t.EndDate)).ToArray();
            HashSet<string> termIdVault = Term.GenerateIdVault(terms);
            Class[] classes = null;
            Exam[] exams = null;
            Assignment[] assignments = null;
            if (termIdVault != null)
            {
                classes = _db.Classes.AsNoTracking().Where(c => c.UserId == scheduleRequest.userId).Where(c => termIdVault.Contains(c.TermId)).ToArray();
                HashSet<string> classIdVault = Class.GenerateIdVault(classes);
                if (classIdVault != null)
                {
                    exams = _db.Exams.AsNoTracking().Where(e => e.UserId == scheduleRequest.userId).Where(e => classIdVault.Contains(e.ClassId)).ToArray();
                    assignments = _db.Assignments.AsNoTracking().Where(a => a.UserId == scheduleRequest.userId).Where(a => classIdVault.Contains(a.ClassId)).ToArray();
                }
            }

            // Add Exams to schedule
            List<ScheduleItem> examItems = ScheduleItem.CreateExamScheduleItems(scheduleRequest.userId, exams, classes);
            if(examItems != null)
            {
                scheduleItems.AddRange(examItems);
            }

            // Per Day Schedule Item Createion
            DateTime currentDate = scheduleRequest.startDate;
            while (currentDate <= scheduleRequest.endDate) 
            {
                // Add Sleep
                if (sleep != null)
                {
                    ScheduleItem sleepItem = ScheduleItem.CreateSleepScheduleItem(scheduleRequest.userId, currentDate, sleep);
                    scheduleItems.Add(sleepItem);
                }
                // Add Classes
                Term term = terms.FirstOrDefault(t => t.StartDate <= currentDate && currentDate <= t.EndDate); // Choose term that we are in today (since terms cannot overlap)
                if (term != null && classes != null)
                {
                    Class[] dayOfWeekClasses = classes.Where(c => c.TermId == term.TermId && c.IsSchoolDay(currentDate.DayOfWeek)).ToArray(); // Choose classes on this day of the week in this term
                    if (dayOfWeekClasses != null && dayOfWeekClasses.Length > 0)
                    {
                        List<ScheduleItem> classItems = ScheduleItem.CreateClassScheduleItems(scheduleRequest.userId, currentDate, dayOfWeekClasses);
                        if (classItems != null)
                        {
                            scheduleItems.AddRange(classItems);
                        }
                    }
                }
                currentDate = currentDate.AddDays(1); // Increment while loop
            }
            if (sleep != null)
            {
                // Make Smart Adjustments
                scheduleItems = ScheduleItem.AdjustSleepTimes(scheduleItems);
            }

            // Add assignments
            if (assignments != null)
            {
                List<ScheduleItem> assignmentItems = new List<ScheduleItem>();
                foreach (var assignment in assignments)
                {
                    assignmentItems.AddRange(assignment.CreateScheduleItems(classes));
                }
                List<DualDates> freeSpace = ScheduleItem.GetFreeSpace(scheduleItems);
                if (assignmentItems != null && freeSpace != null)
                {
                    foreach (ScheduleItem assignmentItem in assignmentItems)
                    {
                        bool isTimeFound = false;
                        double assignmentLengthHours = assignmentItem.EndTime.Subtract(assignmentItem.StartTime).TotalHours;
                        List<DualDates> freeTimeThisDayAcendingLength;
                        if (sleep != null)
                        {
                            freeTimeThisDayAcendingLength = freeSpace.Where(s => DateHelper.IsSameDay(assignmentItem.StartTime, s.Start)).OrderBy(s => s.LengthHours()).ToList();
                        }
                        else
                        {
                            freeTimeThisDayAcendingLength = freeSpace.Where(s => DateHelper.AnyDatesIntersect(assignmentItem.StartTime, assignmentItem.StartTime, s.Start, s.End)).OrderBy(s => s.LengthHours()).ToList();
                        }
                        for (int i = 0; i < freeTimeThisDayAcendingLength.Count; i++)
                        {
                            if (freeTimeThisDayAcendingLength[i].LengthHours() >= assignmentLengthHours)
                            {
                                assignmentItem.StartTime = freeTimeThisDayAcendingLength[i].Start;
                                assignmentItem.EndTime = assignmentItem.StartTime.AddHours(assignmentLengthHours);
                                isTimeFound = true;
                                if(sleep == null)
                                {
                                    freeTimeThisDayAcendingLength[i].Start = freeTimeThisDayAcendingLength[i].Start.AddDays(1);
                                }
                                break;
                            }
                        }
                        if (!isTimeFound)
                        {
                            assignmentItem.StartTime = freeTimeThisDayAcendingLength.Last().Start;
                            assignmentItem.EndTime = assignmentItem.StartTime.AddHours(assignmentLengthHours);
                            isTimeFound = true;
                        }
                        // Clean seconds to be even.
                        assignmentItem.EndTime = assignmentItem.EndTime.AddSeconds(-assignmentItem.EndTime.Second).AddMilliseconds(-assignmentItem.EndTime.Millisecond);
                    }
                    scheduleItems.AddRange(assignmentItems);
                }
            }

            // Remove old items from schedule
            ScheduleItem[] oldScheduleItems = _db.Schedule.Where(si => si.UserId == scheduleRequest.userId).ToArray();
            oldScheduleItems = oldScheduleItems.Where(si => DateHelper.AnyDatesIntersect(scheduleRequest.startDate, scheduleRequest.endDate.AddDays(1), si.StartTime, si.EndTime)).ToArray(); // Removes items that already exist during the scheduling time
            _db.Schedule.RemoveRange(oldScheduleItems);

            // Add New items to schedule
            foreach (ScheduleItem item in scheduleItems)
            {
                _db.Schedule.Add(item);
            }
            _db.SaveChanges();

            Schedule schedule = new Schedule();
            schedule.startDate = scheduleRequest.startDate;
            schedule.endDate = scheduleRequest.endDate;
            schedule.userId = scheduleRequest.userId;
            schedule.schedule = scheduleItems.OrderBy(si => si.StartTime).ToList();
            return schedule;
        }

        public Schedule GetSchedule(string id)
        {
            Schedule schedule = new Schedule();
            List<ScheduleItem> items =_db.Schedule.AsNoTracking().Where(s => s.UserId == id && s.StartTime >= DateTime.Now).OrderBy(s => s.StartTime).ToList();
            schedule.userId = id;
            schedule.schedule = items;
            return schedule;
        }


    }
}
