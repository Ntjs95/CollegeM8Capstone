using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}
