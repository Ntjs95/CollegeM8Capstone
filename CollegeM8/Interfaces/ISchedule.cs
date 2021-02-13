using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface ISchedule
    {
        List<ScheduleItem> GenerateSchedule(string userId, DateTime startDate, DateTime endDate);
    }
}
