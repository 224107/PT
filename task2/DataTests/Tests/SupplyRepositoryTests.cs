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
    public class SupplyRepositoryTests
    {
        public static string m_ConnectionString;
        private static ISupplyRepository _SupplyRepository { get; set; }

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"TestDb.mdf";
            string _TestingWorkingFolder = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";

            _SupplyRepository = new SupplyRepository(m_ConnectionString);
        }

        [TestMethod]
        public void GetSupplyByIdTest()
        {
            Supply supply = _SupplyRepository.GetSupplyById(1);
            Assert.AreEqual(12, supply.product_amount);
            Assert.AreEqual(1, supply.product);
        }

        [TestMethod]
        public void GetAllSupplysTest()
        {
            Assert.AreEqual(3, _SupplyRepository.GetAllSupplies().Count());
        }

        [TestMethod]
        public void GetLastSupplyTest()
        {
            Supply supply = _SupplyRepository.GetLastSupply();
            Assert.AreEqual(5, supply.product_amount);
            Assert.AreEqual(4, supply.product);
        }

        [TestMethod]
        public void GetSupplysByProductIdTest()
        {
            Assert.AreEqual(1, _SupplyRepository.GetSuppliesByProductId(1).Count());
        }
    }
}
