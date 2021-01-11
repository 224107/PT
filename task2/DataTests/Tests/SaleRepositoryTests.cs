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
    public class SaleRepositoryTests
    {
        public static string m_ConnectionString;
        private static ISaleRepository _SaleRepository { get; set; }

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"TestDb.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";

            _SaleRepository = new SaleRepository(m_ConnectionString);
        }

        [TestMethod]
        public void GetSaleByIdTest()
        {
            Sale sale = _SaleRepository.GetSaleById(1);
            Assert.AreEqual(1, sale.customer);
            Assert.AreEqual(1, sale.product);
        }

        [TestMethod]
        public void GetAllSalesTest()
        {
            Assert.AreEqual(3, _SaleRepository.GetAllSales().Count());
        }

        [TestMethod]
        public void GetLastSaleTest()
        {
            Sale sale = _SaleRepository.GetLastSale();
            Assert.AreEqual(4, sale.customer);
            Assert.AreEqual(3, sale.product);
        }

        [TestMethod]
        public void GetSalesByProductIdTest()
        {
            Assert.AreEqual(1, _SaleRepository.GetSalesByProductId(1).Count());
        }

        [TestMethod]
        public void GetSalesByCustomerIdTest()
        {
            Assert.AreEqual(1, _SaleRepository.GetSalesByCustomerId(1).Count());
        }
    }
}
