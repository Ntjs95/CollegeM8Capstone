using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class SleepLogic : ISleepLogic
    {
        CollegeM8Context _db;
        public SleepLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Sleep CreateSleep(Sleep sleep)
        {
            _db.Sleep.Add(sleep);
            _db.SaveChanges();
            return GetSleep(sleep.UserId);
        }

        public Sleep GetSleep(string id)
        {
            Sleep sleep = _db.Sleep.FirstOrDefault(s => s.UserId == id);
            if(sleep == null)
            {
                throw new ServiceException("No sleep data found for this user.");
            }
            return sleep;
        }

        public Sleep UpdateSleep(Sleep newSleep)
        {
            Sleep oldSleep = _db.Sleep.FirstOrDefault(s => s.UserId == newSleep.UserId);
            if (oldSleep == null)
            {
                throw new ServiceException("No sleep data found for this user.");
            }
            else
            {
                oldSleep.HoursWeekday = newSleep.HoursWeekday;
                oldSleep.HoursWeekend = newSleep.HoursWeekend;
                oldSleep.WakeTimeWeekday = newSleep.WakeTimeWeekday;
                oldSleep.WakeTimeWeekend = newSleep.WakeTimeWeekend;
                _db.Sleep.Update(oldSleep);
                _db.SaveChanges();
            }
            return GetSleep(newSleep.UserId);
        }
    }
}
