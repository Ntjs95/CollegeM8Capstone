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
                sleepItem.EndTime = CombineDateTime(wakeDate, sleep.WakeTimeWeekend);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekend);
            }
            else
            {
                sleepItem.EndTime = CombineDateTime(wakeDate, sleep.WakeTimeWeekday);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekday);
            }
            return sleepItem;
        }
        
        internal static List<ScheduleItem> CreateClassScheduleItem(string userId,DateTime date, Class[] classesToday)
        {

            List<ScheduleItem> items = new List<ScheduleItem>();
            foreach (Class _class in classesToday)
            {
                ScheduleItem classItem = new ScheduleItem();
                classItem.UserId = userId;
                classItem.ScheduleItemId = Guid.NewGuid().ToString();
                classItem.Title = $"{_class.CourseCode} - {_class.ClassName}";
                classItem.StartTime = CombineDateTime(date, _class.StartTime);
                classItem.EndTime = CombineDateTime(date, _class.EndTime);
                items.Add(classItem);

            }
            if(items.Count > 0)
            {
                return items;
            }
            return null;
        }

        static private DateTime CombineDateTime(DateTime date, DateTime time)
        {
            return new DateTime(year: date.Year, month: date.Month, day: date.Day, hour: time.Hour, minute: time.Minute, 0);
        }
    }
}
