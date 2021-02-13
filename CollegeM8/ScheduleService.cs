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

            while (scheduleRequest.startDate <= scheduleRequest.endDate)
            {
                ScheduleItem sleepItem = ScheduleItem.CreateSleepScheduleItem(scheduleRequest.userId, scheduleRequest.startDate, sleep);
                scheduleItems.Add(sleepItem);
                scheduleRequest.startDate = scheduleRequest.startDate.AddDays(1);
            }
            Schedule schedule = new Schedule();
            schedule.userId = scheduleRequest.userId;
            schedule.schedule = scheduleItems;
            return schedule;
        }
    }
}
