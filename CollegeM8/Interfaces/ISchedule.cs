using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface ISchedule
    {
        Schedule GenerateSchedule(Schedule schedule);
        Schedule GetSchedule(string id);
    }
}
