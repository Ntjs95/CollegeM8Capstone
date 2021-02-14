using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface IClass
    {
        public Class GetClass(string id);
        public Class[] GetClassByUser(string userId);
        public Class CreateClass(Class _class);
        public Class UpdateClass(Class _class);
        public bool DeleteClass(string id);
    }
}
