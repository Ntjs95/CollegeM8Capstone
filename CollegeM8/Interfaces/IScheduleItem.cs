using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface IScheduleItem
    {
        public ScheduleItem GetScheduleItem(string id);
        public ScheduleItem CreateScheduleItem(ScheduleItem scheduleItem);
        public ScheduleItem UpdateScheduleItem(ScheduleItem scheduleItem);
        public bool DeleteScheduleItem(string id);
    }
}
