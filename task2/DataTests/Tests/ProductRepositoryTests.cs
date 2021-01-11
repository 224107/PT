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
    public class ProductRepositoryTests
    {
        public static string m_ConnectionString;
        private static IProductRepository _ProductRepository { get; set; }

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"TestDb.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";

            _ProductRepository = new ProductRepository(m_ConnectionString);
        }

        [TestMethod]
        public void GetProductByIdTest()
        {
            Product product = _ProductRepository.GetProductById(1);
            Assert.AreEqual("Chair", product.product_name);
            Assert.AreEqual(11, product.price);
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            Assert.AreEqual(4, _ProductRepository.GetAllProducts().Count());
        }

        [TestMethod]
        public void GetLastProductTest()
        {
            Product customer = _ProductRepository.GetLastProduct();
            Assert.AreEqual("Lamp", customer.product_name);
            Assert.AreEqual(14, customer.price);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product customer = new Product()
            {
                id = 1,
                product_name = "Glass",
                price = 123
            };
            _ProductRepository.UpdateProduct(customer);
            Product customer1 = _ProductRepository.GetProductById(1);
            Assert.AreEqual("Glass", customer1.product_name);
            Assert.AreEqual(123, customer1.price);
        }

        [TestMethod]
        public void GetProductAmountTest()
        {
            Assert.AreEqual(10, _ProductRepository.GetProductAmount(1));
        }

        [TestMethod]
        public void ChangeProductAmountTest()
        {
            Assert.AreEqual(10, _ProductRepository.GetProductAmount(1));
            _ProductRepository.ChangeProductAmount(1, -1);
            Assert.AreEqual(9, _ProductRepository.GetProductAmount(1));
        }
    }
}
