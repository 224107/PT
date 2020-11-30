using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LogicUnitTests
{
    [TestClass]
    public class EventRepositoryTest
    {
        private ICustomer customerRepository;
        private IProduct productRepository;
        private IEvent eventRepository;
        private DataContext data;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            customerRepository = new CustomerRepository(data);
            productRepository = new ProductRepository(data);
            eventRepository = new EventRepository(data);
        }

        [TestMethod]
        public void AddEventTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            Sale sale = new Sale(customer, DateTime.Today, productRepository.GetProductsState());
            eventRepository.AddEvent(sale);
            Assert.AreEqual(1, eventRepository.GetAllEvents().Count);
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            Sale sale = new Sale(customer, DateTime.Today, productRepository.GetProductsState());
            Supply supply = new Supply(DateTime.Today, productRepository.GetProductsState());
            eventRepository.AddEvent(sale);
            eventRepository.AddEvent(supply);
            Event _event = eventRepository.GetAllEvents().First();
            Assert.AreEqual(2, eventRepository.GetAllEvents().Count);
            eventRepository.DeleteEvent(_event);
            Assert.AreEqual(1, eventRepository.GetAllEvents().Count);
        }      

        [TestMethod]
        public void GetEmptyEventListTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => eventRepository.GetAllEvents());
            Assert.AreSame(ex.Message, "There's no events");
        }
    }
}

