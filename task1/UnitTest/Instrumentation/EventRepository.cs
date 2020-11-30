using Data;
using System;
using System.Collections.Generic;

namespace DataUnitTests
{
    public class EventRepository : IEvent
    {
        private readonly DataContext Data;

        public EventRepository(DataContext dataContext)
        {
            Data = dataContext;
        }
        public void AddEvent(Event @event)
        {
            Data.Events.Add(@event);
        }

        public void DeleteEvent(Event @event)
        {
            Data.Events.Remove(@event);
        }

        public List<Event> GetAllEvents()
        {
            if (Data.Events.Count == 0)
                throw new Exception("There's no events");
            else
                return Data.Events;
        }
    }
}
