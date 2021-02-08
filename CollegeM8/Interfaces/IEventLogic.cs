using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public interface IEventLogic
    {
        public Event GetEvent(string id);
        public List<Event> GetEventsByUser(string userId);
        public Event CreateEvent(Event schedEvent);
        public Event UpdateEvent(Event schedEvent);
    }
}
