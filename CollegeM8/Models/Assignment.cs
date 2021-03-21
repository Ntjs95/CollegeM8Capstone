using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class Assignment
    {
        [Key]
        public string AssignmentId { get; set; }
        public string UserId { get; set; }
        public string TermId { get; set; }
        public string ClassId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DueDate { get; set; }
        public int GradeWeight { get; set; } // 1-100
        public float HoursToComplete { get; set; }

        public static string TITLE_START = "ASSIGNMENT: ";

        internal List<ScheduleItem> CreateScheduleItems(Class[] classes)
        {
            List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
            float minHoursWork = 0.5f;
            float maxHoursWork = 2.75f;
            int numDaysToComplete = (DueDate - ReleaseDate).Days;
            float averageHoursPerDay = HoursToComplete / numDaysToComplete;

            if(averageHoursPerDay > minHoursWork)
            {
                DateTime currentDate = ReleaseDate;
                while(currentDate < DueDate)
                {
                    ScheduleItem item = new ScheduleItem();
                    item.ScheduleItemId = Guid.NewGuid().ToString();
                    item.UserId = UserId;
                    for (int i = 0; i < classes.Length; i++)
                    {
                        if(ClassId == classes[i].ClassId)
                        {
                            item.Title = $"{TITLE_START}{classes[i].CourseCode}-{classes[i].ClassName}";
                            break;
                        }
                    }
                    item.StartTime = currentDate;
                    item.EndTime = currentDate.AddHours(averageHoursPerDay);
                    scheduleItems.Add(item);
                    currentDate = currentDate.AddDays(1);
                }
            }
            else
            {
                int numberOfDaysNeeded = 1;
                while (numberOfDaysNeeded < numDaysToComplete)
                {
                    float calculatedNewAverage = HoursToComplete / numberOfDaysNeeded;
                    if (calculatedNewAverage >= minHoursWork && calculatedNewAverage <= maxHoursWork)
                    {
                        averageHoursPerDay = calculatedNewAverage;
                        break;
                    }
                    numberOfDaysNeeded++;
                }

                DateTime currentDate = ReleaseDate;
                for (int d = 0; d < numberOfDaysNeeded; d++)
                {
                    ScheduleItem item = new ScheduleItem();
                    item.ScheduleItemId = Guid.NewGuid().ToString();
                    item.UserId = UserId;
                    for (int i = 0; i < classes.Length; i++)
                    {
                        if (ClassId == classes[i].ClassId)
                        {
                            item.Title = $"{TITLE_START}{classes[i].CourseCode}-{classes[i].ClassName}";
                            break;
                        }
                    }
                    item.StartTime = currentDate;
                    item.EndTime = currentDate.AddHours(averageHoursPerDay);
                    scheduleItems.Add(item);
                    currentDate = currentDate.AddDays(1);
                }
            }

            if(scheduleItems.Count > 0)
            {
                return scheduleItems;
            }
            return null;
        }
    }
}
