using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ScheduleItem
    {
        public string ScheduleItemId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        internal static ScheduleItem CreateSleepScheduleItem(string userId, DateTime wakeDate, Sleep sleep)
        {
            ScheduleItem sleepItem = new ScheduleItem();
            sleepItem.UserId = userId;
            sleepItem.ScheduleItemId = Guid.NewGuid().ToString();
            sleepItem.Title = Sleep.SCHED_ITEM_TITLE;
            if (wakeDate.DayOfWeek == DayOfWeek.Saturday || wakeDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sleepItem.EndTime = new DateTime(year: wakeDate.Year, month: wakeDate.Month, day: wakeDate.Day, hour: sleep.WakeTimeWeekend.Hour, minute: sleep.WakeTimeWeekend.Minute, 0);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekend);
            }
            else
            {
                sleepItem.EndTime = new DateTime(year: wakeDate.Year, month: wakeDate.Month, day: wakeDate.Day, hour: sleep.WakeTimeWeekday.Hour, minute: sleep.WakeTimeWeekday.Minute, 0);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekday);
            }
            return sleepItem;
        }
    }
}
