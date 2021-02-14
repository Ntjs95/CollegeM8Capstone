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
            Schedule schedule = new Schedule();
            schedule.startDate = scheduleRequest.startDate;
            schedule.endDate = scheduleRequest.endDate;
            //Data Setup
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            Sleep sleep = _db.Sleep.AsNoTracking().FirstOrDefault(s => s.UserId == scheduleRequest.userId);
            Term[] terms = _db.Term.AsNoTracking().Where(t => t.UserId == scheduleRequest.userId).Where(t => (scheduleRequest.startDate >= t.StartDate && scheduleRequest.startDate <= t.EndDate) ||
            (scheduleRequest.endDate <= t.EndDate && scheduleRequest.endDate >= t.StartDate) ||
            (scheduleRequest.startDate <= t.StartDate && scheduleRequest.endDate >= t.EndDate)).ToArray();
            HashSet<string> termIdVault = Term.GenerateIdVault(terms);
            Class[] classes = _db.Classes.AsNoTracking().Where(c => c.UserId == scheduleRequest.userId).Where(c => termIdVault.Contains(c.TermId)).ToArray();

            // Per Day Schedule Item Createion
            while (scheduleRequest.startDate <= scheduleRequest.endDate) 
            {
                // Add Sleep
                ScheduleItem sleepItem = ScheduleItem.CreateSleepScheduleItem(scheduleRequest.userId, scheduleRequest.startDate, sleep);
                scheduleItems.Add(sleepItem);
                // Add Classes
                Term term = terms.FirstOrDefault(t => t.StartDate <= scheduleRequest.startDate && scheduleRequest.startDate <= t.EndDate); // Choose term that we are in today (since terms cannot overlap)
                if (term != null)
                {
                    Class[] dayOfWeekClasses = classes.Where(c => c.TermId == term.TermId && c.IsSchoolDay(scheduleRequest.startDate.DayOfWeek)).ToArray(); // Choose classes on this day of the week in this term
                    if (dayOfWeekClasses != null && dayOfWeekClasses.Length > 0)
                    {
                        List<ScheduleItem> classItems = ScheduleItem.CreateClassScheduleItem(scheduleRequest.userId, scheduleRequest.startDate, dayOfWeekClasses);
                        if (classItems != null)
                        {
                            scheduleItems.AddRange(classItems);
                        }
                    }
                }
                // Add Exams

                // Add Assignments
                

                scheduleRequest.startDate = scheduleRequest.startDate.AddDays(1); // Increment while loop
            }

            // Remove old items from schedule
            ScheduleItem[] oldScheduleItems = _db.Schedule.Where(si => si.UserId == scheduleRequest.userId).ToArray();
            oldScheduleItems = oldScheduleItems.Where(si => DateHelper.AnyDatesIntersect(si.StartTime, si.EndTime, scheduleRequest.startDate, scheduleRequest.endDate)).ToArray();
            _db.Schedule.RemoveRange(oldScheduleItems);

            // Add New items to schedule
            foreach (ScheduleItem item in scheduleItems)
            {
                _db.Schedule.Add(item);
            }
            _db.SaveChanges();

            
            schedule.userId = scheduleRequest.userId;
            schedule.schedule = scheduleItems;
            return schedule;
        }

        public Schedule GetSchedule(string id)
        {
            Schedule schedule = new Schedule();
            List<ScheduleItem> items =_db.Schedule.AsNoTracking().Where(s => s.UserId == id).ToList();
            schedule.userId = id;
            schedule.schedule = items;
            return schedule;
        }


    }
}
