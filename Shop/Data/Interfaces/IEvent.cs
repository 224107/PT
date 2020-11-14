using System.Collections.Generic;

namespace Data.Interfaces
{
    interface IEvent
    {
        List<Event> GetAllEvents();
        void AddEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(int id);
    }
}
