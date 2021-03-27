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

        private ScheduleItemType ItemType()
        {
            if (Title.StartsWith(Class.TITLE_START))
            {
                return ScheduleItemType.CLASS;
            }else if (Title.StartsWith(Assignment.TITLE_START))
            {
                return ScheduleItemType.ASSIGNMENT;
            }
            else if (Title.StartsWith(Exam.TITLE_START))
            {
                return ScheduleItemType.EXAM;
            }
            else if(Title.StartsWith(Sleep.TITLE_START))
            {
                return ScheduleItemType.SLEEP;
            }
            return ScheduleItemType.NULL;
        }

        private enum ScheduleItemType
        {
            CLASS,
            ASSIGNMENT,
            EXAM,
            SLEEP,
            NULL
        }

        internal static List<DualDates> GetFreeSpace(List<ScheduleItem> schedule)
        {
            List<DualDates> freeSpace = new List<DualDates>();

            schedule = schedule.OrderBy(si => si.StartTime).ToList();
            int lengthSched = schedule.Count;

            for (int i = 0; i < lengthSched; i++)
            {
                if((i != lengthSched-1) && schedule[i+1].StartTime > schedule[i].EndTime)
                {
                    DualDates dates = new DualDates();
                    dates.Start = schedule[i].EndTime;
                    dates.End = schedule[i+1].StartTime;
                    freeSpace.Add(dates);
                }
            }
            if (freeSpace.Count > 0)
            {
                return freeSpace;
            }
            return null;
        }

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

        internal static List<ScheduleItem> AdjustSleepTimes(List<ScheduleItem> items)
        {
            ScheduleItem[] itemArray = items.OrderBy(i => i.StartTime).ToArray();

            for (int i = 0; i < itemArray.Length; i++)
            {
                // If this item and the next one have intersecting times.
                if (i != itemArray.Length - 1 && DateHelper.AnyDatesIntersect(itemArray[i].StartTime, itemArray[i].EndTime, itemArray[i + 1].StartTime, itemArray[i + 1].EndTime))
                {
                    int overlapMinutes = (int)itemArray[i].EndTime.Subtract(itemArray[i + 1].StartTime).TotalMinutes;
                    if (overlapMinutes > 0)
                    {
                        if (itemArray[i].ItemType() == ScheduleItemType.SLEEP && itemArray[i + 1].EndTime > itemArray[i].EndTime) // If you are current scheduleued to wake up after an item
                        {
                            int maxEarlyBedtimeShift; // How many minutes early can I go to bed before impacting another item
                            if (i == 0)
                            {
                                maxEarlyBedtimeShift = overlapMinutes;
                            }
                            else
                            {
                                maxEarlyBedtimeShift = Math.Min((int)itemArray[i].StartTime.Subtract(itemArray[i - 1].EndTime).TotalMinutes, overlapMinutes);
                            }
                            itemArray[i].StartTime = itemArray[i].StartTime.AddMinutes(-maxEarlyBedtimeShift);
                            itemArray[i].EndTime = itemArray[i].EndTime.AddMinutes(-overlapMinutes);
                        }
                        else if (itemArray[i].ItemType() == ScheduleItemType.SLEEP) // Next item(s) is fully within current sleep item (complex-ish edge case)
                        {
                            int indexNextEventStartsAfterSleep = i + 2;
                            for (int j = i + 1; j < itemArray.Length; j++)
                            {
                                if (itemArray[j].StartTime > itemArray[i].EndTime)
                                {
                                    indexNextEventStartsAfterSleep = j;
                                    break;
                                }
                            }

                            int largestGapInMinutes = 0;
                            DateTime currentstart = itemArray[i].StartTime;
                            DateTime soFarLongestStart = currentstart;
                            DateTime soFarLongestEnd = currentstart;

                            for (int x = i + 1; x < indexNextEventStartsAfterSleep; x++)
                            {
                                int gapBefore = (int)itemArray[x].StartTime.Subtract(currentstart).TotalMinutes;
                                if (gapBefore > largestGapInMinutes)
                                {
                                    largestGapInMinutes = gapBefore;
                                    soFarLongestStart = currentstart;
                                    soFarLongestEnd = itemArray[x].StartTime;
                                }

                                if (x == indexNextEventStartsAfterSleep - 1 && itemArray[x].EndTime < itemArray[i].EndTime)
                                {
                                    int gapAfter = (int)itemArray[i].EndTime.Subtract(itemArray[x].EndTime).TotalMinutes;
                                    if (gapAfter > largestGapInMinutes)
                                    {
                                        largestGapInMinutes = gapAfter;
                                        soFarLongestStart = itemArray[x].EndTime;
                                        soFarLongestEnd = itemArray[i].EndTime;
                                    }
                                }
                                currentstart = itemArray[x].EndTime;
                            }

                            if (soFarLongestStart == itemArray[i].StartTime)
                            {
                                int minutesEarlyToWakeUp = (int)itemArray[i].EndTime.Subtract(soFarLongestEnd).TotalMinutes;
                                if (i == 0)
                                {
                                    itemArray[i].StartTime = itemArray[i].StartTime.AddMinutes(-minutesEarlyToWakeUp);
                                }
                                else
                                {
                                    int maxMinutesToBedEarly = (int)itemArray[i].StartTime.Subtract(itemArray[i-1].EndTime).TotalMinutes;
                                    itemArray[i].StartTime = itemArray[i].StartTime.AddMinutes(-Math.Min(minutesEarlyToWakeUp, maxMinutesToBedEarly));
                                }
                                itemArray[i].EndTime = soFarLongestEnd;
                            }
                            else
                            {
                                itemArray[i].StartTime = soFarLongestStart;
                                itemArray[i].EndTime = soFarLongestEnd;
                            }
                        }
                        else if (itemArray[i + 1].ItemType() == ScheduleItemType.SLEEP) // If you're supposed to go to bed before you're done your current item
                        {
                            int maxLateWakeupShift;
                            if (i + 2 == itemArray.Length) // If the sleep item is the last item in the list
                            {
                                maxLateWakeupShift = overlapMinutes;
                            }
                            else
                            {
                                maxLateWakeupShift = Math.Max(0, Math.Min((int)itemArray[i + 1].StartTime.Subtract(itemArray[i].EndTime).TotalMinutes, overlapMinutes));
                            }
                            itemArray[i + 1].StartTime = itemArray[i + 1].StartTime.AddMinutes(overlapMinutes);
                            itemArray[i + 1].EndTime = itemArray[i + 1].EndTime.AddMinutes(maxLateWakeupShift);
                        }
                    }
                }
            }
            return itemArray.ToList();
        }
    }
}
