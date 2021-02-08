using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class EventLogic : IEventLogic
    {
        CollegeM8Context _db;
        public EventLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public Event CreateEvent(Event schedEvent)
        {
            string guid = Guid.NewGuid().ToString();
            schedEvent.EventId = guid;
            _db.Events.Add(schedEvent);
            _db.SaveChanges();
            return GetEvent(guid);
        }

        public Event GetEvent(string id)
        {
            Event schedEvent;
            schedEvent = _db.Events.FirstOrDefault(e => e.EventId == id);
            if (schedEvent == null)
            {
                throw new ServiceException("Event Does Not Exist");
            }
            return schedEvent;
        }

        public List<Event> GetEventsByUser(string userId)
        {
            var events = _db.Events.Where(e => e.UserId == userId).ToList();
            if(events != null && events.Count > 0)
            {
                return events;
            }
            else
            {
                throw new ServiceException("No events found");
            }
        }

        public Event UpdateEvent(Event schedEvent)
        {
            throw new NotImplementedException();
        }
    }
}
