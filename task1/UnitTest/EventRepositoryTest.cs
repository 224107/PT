using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataUnitTests
{
    [TestClass]
    public class EventRepositoryTest
    {
        private ICustomer customerRepository;
        private IProduct productRepository;
        private IEvent eventRepository;
        private DataContext data;
        private IDataGenerator generator;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            customerRepository = new CustomerRepository(data);
            productRepository = new ProductRepository(data);
            eventRepository = new EventRepository(data);
            generator = new FixedExampleData();
            //generator = new RandomExampleData();
            generator.GenerateData(data);
        }

        [TestMethod]
        public void AddEventTest()
        {
            Customer customer = customerRepository.GetAllCustomers().First();
            Sale sale = new Sale(customer, DateTime.Today, productRepository.GetProductsState());
            eventRepository.AddEvent(sale);
            Assert.AreEqual(5, eventRepository.GetAllEvents().Count);
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            Event _event = eventRepository.GetAllEvents().First();
            Assert.AreEqual(4, eventRepository.GetAllEvents().Count);
            eventRepository.DeleteEvent(_event);
            Assert.AreEqual(3, eventRepository.GetAllEvents().Count);
        }      

        [TestMethod]
        public void GetEmptyEventListTest()
        {
            eventRepository.GetAllEvents().Clear();
            Exception ex = Assert.ThrowsException<Exception>(() => eventRepository.GetAllEvents());
            Assert.AreSame(ex.Message, "There's no events");
        }
    }
}

