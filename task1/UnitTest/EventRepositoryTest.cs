using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class EventRepositoryTest
    {
        private ICustomer customerRepository;
        private IEvent eventRepository;
        private DataContext data;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            customerRepository = new CustomerRepository(data);
            eventRepository = new EventRepository(data);
        }

        [TestMethod]
        public void AddEventTest()
        {
            Sale sale = new Sale(5, DateTime.Now, customerRepository.GetCustomerById(1));
            eventRepository.AddEvent(sale);
            Assert.AreEqual(sale, eventRepository.GetEventById(5));
            Assert.AreEqual(5, eventRepository.GetAllEvents().Count);
        }

        [TestMethod]
        public void GetEventByIdTest()
        {
            Sale sale = new Sale(5, DateTime.Now, customerRepository.GetCustomerById(1));
            eventRepository.AddEvent(sale);
            Assert.AreEqual(sale, eventRepository.GetEventById(5));
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            Assert.AreEqual(4, eventRepository.GetAllEvents().Count);
            eventRepository.DeleteEvent(4);
            Assert.AreEqual(3, eventRepository.GetAllEvents().Count);
        }

        [TestMethod]
        public void GetEmptyEventListTest()
        {
            eventRepository.DeleteEvent(1);
            eventRepository.DeleteEvent(2);
            eventRepository.DeleteEvent(3);
            eventRepository.DeleteEvent(4);

            Exception ex = Assert.ThrowsException<Exception>(() => eventRepository.GetAllEvents());
            Assert.AreSame(ex.Message, "There's no events");
        }

        [TestMethod]
        public void GetNonExistingEventTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => eventRepository.GetEventById(5));
            Assert.AreSame(ex.Message, "There's no event with such id");
        }
    }
}

