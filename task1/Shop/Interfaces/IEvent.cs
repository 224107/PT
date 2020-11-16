using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IEvent
    {
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        void AddEvent(Event @event);
        void DeleteEvent(int id);
    }
}
