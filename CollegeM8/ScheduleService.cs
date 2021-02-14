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
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            Sleep sleep = _db.Sleep.AsNoTracking().FirstOrDefault(s => s.UserId == scheduleRequest.userId);
            List<Term> terms = _db.Term.AsNoTracking().Where(t => t.UserId == scheduleRequest.userId).Where(t => (scheduleRequest.startDate >= t.StartDate && scheduleRequest.startDate <= t.EndDate) ||
            (scheduleRequest.endDate <= t.EndDate && scheduleRequest.endDate >= t.StartDate) ||
            (scheduleRequest.startDate <= t.StartDate && scheduleRequest.endDate >= t.EndDate)).ToList();
            HashSet<string> termIdVault = Term.GenerateIdVault(terms);
            List<Class> classes = _db.Classes.AsNoTracking().Where(c => c.UserId == scheduleRequest.userId).Where(c => termIdVault.Contains(c.TermId)).ToList();

            while (scheduleRequest.startDate <= scheduleRequest.endDate) // Per Day
            {
                // Add Sleep
                ScheduleItem sleepItem = ScheduleItem.CreateSleepScheduleItem(scheduleRequest.userId, scheduleRequest.startDate, sleep);
                scheduleItems.Add(sleepItem);
                // Add Classes
                List<ScheduleItem> classItems = ScheduleItem.CreateClassScheduleItem(scheduleRequest.userId, scheduleRequest.startDate, terms, classes);
                scheduleItems.AddRange(classItems);

                scheduleRequest.startDate = scheduleRequest.startDate.AddDays(1);
            }

            foreach (ScheduleItem item in scheduleItems)
            {
                _db.Schedule.Add(item);
            }
            _db.SaveChanges();

            Schedule schedule = new Schedule();
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
