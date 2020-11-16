using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DataServiceTest
    {
        private DataService service;
        private DataContext data;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            service = new DataService(new CustomerRepository(data), new EventRepository(data), new ProductRepository(data));
        }

        [TestMethod]
        public void GetAllCustomerTest()
        {
            Assert.AreEqual(3, service.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            Assert.AreEqual("Mark", service.GetCustomerbyId(1).FirstName);
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            service.AddCustomer(4, "Matt", "Knox");
            Assert.AreEqual(4, service.GetAllCustomers().Count);
        }
        [TestMethod]
        public void DeleteCustomerTest()
        {
            service.DeleteCustomer(3);
            Exception ex = Assert.ThrowsException<Exception>(() => service.GetCustomerbyId(3));
            Assert.AreSame(ex.Message, "There's no customer with such id");
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            service.UpdateCustomer(1, "Matt", "Knox");
            Assert.AreEqual("Matt", service.GetCustomerbyId(1).FirstName);
            Assert.AreEqual("Knox", service.GetCustomerbyId(1).LastName);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            Assert.AreEqual(4, service.GetAllEvents().Count);
        }

    }
}
