using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataUnitTests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private ICustomer repository;
        private DataContext data;
        private IDataGenerator generator;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            repository = new CustomerRepository(data);
            generator = new FixedExampleData();
            //generator = new RandomExampleData();
            generator.GenerateData(data);
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Customer customer = new Customer(101, "Matt", "Knox");
            Assert.AreEqual(4, repository.GetAllCustomers().Count);
            repository.AddCustomer(customer);
            Assert.AreEqual(5, repository.GetAllCustomers().Count);
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
            Customer customer = repository.GetAllCustomers().First();
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
            Assert.AreEqual(4, repository.GetAllCustomers().Count);
            Customer customer = repository.GetAllCustomers().First();
            repository.DeleteCustomer(customer.Id);
            Assert.AreEqual(3, repository.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetEmptyCustomerListTest()
        {
            repository.GetAllCustomers().Clear();
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllCustomers());
            Assert.AreSame(ex.Message, "There's no customers");
        }

        [TestMethod]
        public void GetNonExistingCustomerTest()
        {
            repository.GetAllCustomers().Clear();
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetCustomerById(1));
            Assert.AreSame(ex.Message, "There's no customer with such id");
        }
    }
}
