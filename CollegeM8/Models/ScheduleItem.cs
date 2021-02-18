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
            sleepItem.Title = Sleep.TITLE_START;
            if (wakeDate.DayOfWeek == DayOfWeek.Saturday || wakeDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sleepItem.EndTime = DateHelper.CombineDateTime(wakeDate, sleep.WakeTimeWeekend);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekend);
            }
            else
            {
                sleepItem.EndTime = DateHelper.CombineDateTime(wakeDate, sleep.WakeTimeWeekday);
                sleepItem.StartTime = sleepItem.EndTime.AddHours(-sleep.HoursWeekday);
            }
            return sleepItem;
        }
        
        internal static List<ScheduleItem> CreateClassScheduleItems(string userId,DateTime date, Class[] classesToday)
        {

            List<ScheduleItem> items = new List<ScheduleItem>();
            foreach (Class _class in classesToday)
            {
                ScheduleItem classItem = new ScheduleItem();
                classItem.UserId = userId;
                classItem.ScheduleItemId = Guid.NewGuid().ToString();
                classItem.Title = $"{Class.TITLE_START}{_class.CourseCode} - {_class.ClassName}";
                classItem.StartTime = DateHelper.CombineDateTime(date, _class.StartTime);
                classItem.EndTime = DateHelper.CombineDateTime(date, _class.EndTime);
                items.Add(classItem);
            }
            if(items.Count > 0)
            {
                return items;
            }
            return null;
        }

        internal static List<ScheduleItem> CreateExamScheduleItems(string userId, Exam[] exams, Class[] classes)
        {
            if(classes == null || exams == null || classes.Length == 0 || exams.Length == 0)
            {
                return null;
            }
            List<ScheduleItem> items = new List<ScheduleItem>();
            foreach (Exam exam in exams)
            {
                Class _class = classes.FirstOrDefault(c => c.ClassId == exam.ClassId);
                ScheduleItem examItem = new ScheduleItem();
                examItem.UserId = userId;
                examItem.ScheduleItemId = Guid.NewGuid().ToString();
                examItem.Title = $"{Exam.TITLE_START}{_class.CourseCode} - {_class.ClassName}";
                examItem.StartTime = exam.StartTime;
                examItem.EndTime = exam.EndTime;
                items.Add(examItem);
            }
            if(items.Count > 0)
            {
                return items;
            }
            return null;
        }
    }
}
