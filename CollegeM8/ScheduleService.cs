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

        public List<ScheduleItem> GenerateSchedule(string userId, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate || !_db.Users.AsNoTracking().Any(u => u.UserId == userId))
            {
                throw new ServiceException("Data invalid to create schedule.");
            }
            List<ScheduleItem> schedule = new List<ScheduleItem>();
            Sleep sleep = _db.Sleep.AsNoTracking().FirstOrDefault(s => s.UserId == userId);

            while (startDate <= endDate)
            {
                ScheduleItem sleepItem = ScheduleItem.CreateSleepScheduleItem(userId, startDate, sleep);


                startDate = startDate.AddDays(1);
            }

            return schedule;
        }
    }
}
