using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using ServiceTests.Instructions;
using System.Linq;

namespace ServiceTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private ICustomerService _CustomerService { get; }
        public CustomerServiceTests()
        {
            DataContext _DataContext = new DataContext();
            FixedExampleData exampleData = new FixedExampleData();
            exampleData.GenerateData(_DataContext);
            CustomerRepository _CustomerRepository = new CustomerRepository(_DataContext);
            _CustomerService = new CustomerService(_CustomerRepository);
        }

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            Customer customer = _CustomerService.GetCustomerById(1);
            Assert.AreEqual("Matt", customer.FirstName);
            Assert.AreEqual("Newman", customer.LastName);
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Assert.AreEqual(2, _CustomerService.GetAllCustomers().Count());
            _CustomerService.AddCustomer("Sylwester", "Nowak");
            Assert.AreEqual(3, _CustomerService.GetAllCustomers().Count());
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            Assert.AreEqual(2, _CustomerService.GetAllCustomers().Count());
            _CustomerService.DeleteCustomer(1);
            Assert.AreEqual(1, _CustomerService.GetAllCustomers().Count());
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer customer1 = _CustomerService.GetCustomerById(1);
            Assert.AreEqual("Matt", customer1.FirstName);
            Assert.AreEqual("Newman", customer1.LastName);
            _CustomerService.UpdateCustomer(1, "Sylwester", "Nowak");
            Customer customer2 = _CustomerService.GetCustomerById(1);
            Assert.AreEqual("Sylwester", customer2.FirstName);
            Assert.AreEqual("Nowak", customer2.LastName);
        }
    }
}
