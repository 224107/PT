using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using ServiceTests.Instructions;
using System.Linq;

namespace ServiceTests
{
    [TestClass]
    public class EventServiceTests
    {
        private IEventService _EventService { get; }
        public EventServiceTests()
        {
            DataContext _DataContext = new DataContext();
            FixedExampleData exampleData = new FixedExampleData();
            exampleData.GenerateData(_DataContext);
            SaleRepository _SaleRepository = new SaleRepository(_DataContext);
            CustomerRepository _CustomerRepository = new CustomerRepository(_DataContext);
            ProductRepository _ProductRepository = new ProductRepository(_DataContext);
            SupplyRepository _SupplyRepository = new SupplyRepository(_DataContext);
            _EventService = new EventService(_CustomerRepository, _ProductRepository,
                                     _SaleRepository, _SupplyRepository); 
        }
        
        [TestMethod]
        public void GetSaleByIdTest()
        {
            Sale sale = _EventService.GetSaleById(1);
            Assert.AreEqual(1, sale.ProductId);
            Assert.AreEqual(1, sale.CustomerId);
        }

        [TestMethod]
        public void AddSaleTest()
        {
            Assert.AreEqual(2, _EventService.GetAllSales().Count());
            _EventService.AddSale(1, 1, 3);
            Assert.AreEqual(3, _EventService.GetAllSales().Count());
        }

        [TestMethod]
        public void DeleteSaleTest()
        {
            Assert.AreEqual(2, _EventService.GetAllSales().Count());
            _EventService.DeleteSale(1);
            Assert.AreEqual(1, _EventService.GetAllSales().Count());
        }

        [TestMethod]
        public void GetSupplyByIdTest()
        {
            Supply supply = _EventService.GetSupplyById(1);
            Assert.AreEqual(1, supply.ProductId);
        }

        [TestMethod]
        public void AddSupplyTest()
        {
            Assert.AreEqual(2, _EventService.GetAllSupplies().Count());
            _EventService.AddSupply(1, 2);
            Assert.AreEqual(3, _EventService.GetAllSupplies().Count());
        }

        [TestMethod]
        public void DeleteSupplyTest()
        {
            Assert.AreEqual(2, _EventService.GetAllSupplies().Count());
            _EventService.DeleteSupply(1);
            Assert.AreEqual(1, _EventService.GetAllSupplies().Count());
        }

        [TestMethod]
        public void GetAllProductSalesTest()
        {
            Assert.AreEqual(1, _EventService.GetAllProductSales(1).Count());
        }

        [TestMethod]
        public void GetAllProductSuppliesTest()
        {
            Assert.AreEqual(1, _EventService.GetAllProductSupplies(1).Count());
        }

        [TestMethod]
        public void GetAllCustomerSalesTest()
        {
            Assert.AreEqual(1, _EventService.GetAllCustomerSales(1).Count());
        }
    }
}
