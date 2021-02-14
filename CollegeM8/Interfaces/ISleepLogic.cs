using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface ISleepLogic
    {
        public Sleep GetSleep(string id);
        public Sleep CreateSleep(Sleep sleep);
        public Sleep UpdateSleep(Sleep sleep);
    }
}
