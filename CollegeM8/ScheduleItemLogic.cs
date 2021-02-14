using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ScheduleItemLogic : IScheduleItem
    {
        CollegeM8Context _db;
        public ScheduleItemLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public ScheduleItem CreateScheduleItem(ScheduleItem scheduleItem)
        {
            scheduleItem.ScheduleItemId = Guid.NewGuid().ToString();
            _db.Schedule.Add(scheduleItem);
            _db.SaveChanges();
            return GetScheduleItem(scheduleItem.UserId);
        }

        public ScheduleItem GetScheduleItem(string id)
        {
            ScheduleItem scheduleItem = _db.Schedule.AsNoTracking().FirstOrDefault(si => si.ScheduleItemId == id);
            if (scheduleItem == null)
            {
                throw new ServiceException("Schedule item not found");
            }
            return scheduleItem;
        }

        public ScheduleItem UpdateScheduleItem(ScheduleItem newScheduleItem)
        {
            ScheduleItem oldScheduleItem = _db.Schedule.FirstOrDefault(si => si.ScheduleItemId == newScheduleItem.ScheduleItemId);
            if (oldScheduleItem == null)
            {
                throw new ServiceException("Schedule item not found");
            }
            else
            {
                oldScheduleItem.EndTime = newScheduleItem.EndTime;
                oldScheduleItem.StartTime = newScheduleItem.StartTime;
                oldScheduleItem.Title = newScheduleItem.Title;
                _db.Schedule.Update(oldScheduleItem);
                _db.SaveChanges();
            }
            return GetScheduleItem(newScheduleItem.ScheduleItemId);
        }
        public bool DeleteScheduleItem(string id)
        {
            _db.Schedule.Remove(_db.Schedule.Find(id));
            _db.SaveChanges();
            return true;
        }
    }
}
