using System.Collections.Generic;

namespace Data
{
    public interface IEvent
    {
        List<Event> GetAllEvents();
        void AddEvent(Event @event);
        void DeleteEvent(Event @event);
    }
}
