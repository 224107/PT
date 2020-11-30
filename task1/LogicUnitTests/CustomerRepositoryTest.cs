using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicUnitTests
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
            Customer customer = new Customer(101, "Matt", "Knox");
            repository.AddCustomer(customer);
            Assert.AreEqual(1, repository.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            repository.AddCustomer(customer);
            Customer customerById = repository.GetCustomerById(101);
            Assert.AreEqual(customer, customerById);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            Customer customerUpdated = new Customer(customer.Id, "Megan", "Fox");
            repository.AddCustomer(customer);
            Assert.AreEqual(customer, repository.GetCustomerById(customer.Id));
            repository.UpdateCustomer(customerUpdated);
            Assert.AreEqual(customerUpdated.FirstName, repository.GetCustomerById(customer.Id).FirstName);
            Assert.AreEqual(customerUpdated.LastName, repository.GetCustomerById(customer.Id).LastName);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            repository.AddCustomer(customer);
            repository.AddCustomer(customer);
            Assert.AreEqual(2, repository.GetAllCustomers().Count);
            repository.DeleteCustomer(customer.Id);
            Assert.AreEqual(1, repository.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetEmptyCustomerListTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllCustomers());
            Assert.AreSame(ex.Message, "There's no customers");
        }

        [TestMethod]
        public void GetNonExistingCustomerTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetCustomerById(1));
            Assert.AreSame(ex.Message, "There's no customer with such id");
        }
    }
}
