using Data;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace DataTests
{
    [TestClass]
    [DeploymentItem(@"TestDb.mdf")]
    public class CustomerRepositoryTests
    {
        public static string m_ConnectionString;
        private static ICustomerRepository _CustomerRepository { get; set; }
        
        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"TestDb.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";

            _CustomerRepository = new CustomerRepository(m_ConnectionString);
        }

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            Customer customer = _CustomerRepository.GetCustomerById(1);
            Assert.AreEqual("Mark", customer.first_name);
            Assert.AreEqual("Kent", customer.last_name);
        }

        [TestMethod]
        public void GetAllCustomersTest()
        {                         
            Assert.AreEqual(4, _CustomerRepository.GetAllCustomers().Count());           
        }

        [TestMethod]
        public void GetLastCustomerTest()
        {
            Customer customer = _CustomerRepository.GetLastCustomer();            
            Assert.AreEqual("Michael", customer.first_name);
            Assert.AreEqual("Black", customer.last_name);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer customer = new Customer()
            {
                id = 1,
                first_name = "Emily",
                last_name = "Green"
            };
            _CustomerRepository.UpdateCustomer(customer);
            Customer customer1 = _CustomerRepository.GetCustomerById(1);
            Assert.AreEqual("Emily", customer1.first_name);
            Assert.AreEqual("Green", customer1.last_name);
        }
    }
}
