using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private ICustomer repository;
        private DataContext data;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            repository = new CustomerRepository(data);
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Customer customer = new Customer(4, "Matt", "Knox");
            Assert.AreEqual(3, repository.GetAllCustomers().Count);
            repository.AddCustomer(customer);
            Assert.AreEqual(4, repository.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            Customer customer = new Customer(4, "Matt", "Knox");
            repository.AddCustomer(customer);
            Customer customerById = repository.GetCustomerById(4);
            Assert.AreEqual(customer, customerById);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer customer = repository.GetCustomerById(1);
            Customer customerUpdated = new Customer(1, "Matt", "Knox");
            Assert.AreEqual(customer, repository.GetCustomerById(1));
            repository.UpdateCustomer(customerUpdated);
            Assert.AreEqual(customer, repository.GetCustomerById(1));
            Assert.AreEqual(customerUpdated.FirstName, repository.GetCustomerById(1).FirstName);
            Assert.AreEqual(customerUpdated.LastName, repository.GetCustomerById(1).LastName);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            Assert.AreEqual(3, repository.GetAllCustomers().Count);
            repository.DeleteCustomer(1);
            Assert.AreEqual(2, repository.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetEmptyCustomerListTest()
        {
            repository.DeleteCustomer(1);
            repository.DeleteCustomer(2);
            repository.DeleteCustomer(3);

            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllCustomers());
            Assert.AreSame(ex.Message, "There's no customers");
        }

        [TestMethod]
        public void GetNonExistingCustomerTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetCustomerById(4));
            Assert.AreSame(ex.Message, "There's no customer with such id");
        }
    }
}
