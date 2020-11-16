using Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Logic
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
            Data.Events().Add(@event);
        }

        public void DeleteEvent(int id)
        {
            Data.Events().Remove(GetEventById(id));
        }

        public List<Event> GetAllEvents()
        {
            if (Data.Events().Count == 0)
                throw new Exception("There's no events");
            else
                return Data.Events();
        }

        public Event GetEventById(int id)
        {
            for (int i = 0; i < Data.Events().Count; i++)
            {
                if (Data.Events()[i].Id == id)
                    return Data.Events()[i];
            }
            throw new Exception("There's no event with such id");
        }
    }
}
