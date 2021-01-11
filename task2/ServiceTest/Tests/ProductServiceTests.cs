using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using ServiceTests.Instructions;
using System.Linq;

namespace ServiceTests
{
    [TestClass]
    public class ProductServiceTests
    {
        private IProductService _ProductService { get; }
        public ProductServiceTests()
        {
            DataContext _DataContext = new DataContext();
            FixedExampleData exampleData = new FixedExampleData();
            exampleData.GenerateData(_DataContext);
            ProductRepository _ProductRepository = new ProductRepository(_DataContext);
            _ProductService = new ProductService(_ProductRepository);  
        }

        [TestMethod]
        public void GetProductByIdTest()
        {
            Product product = _ProductService.GetProductById(1);
            Assert.AreEqual("Sofa", product.Name);
            Assert.AreEqual(243.23, product.Price);
        }

        [TestMethod]
        public void AddProductTest()
        {
            Assert.AreEqual(2, _ProductService.GetAllProducts().Count());
            _ProductService.AddProduct("Sylwester", 102.12);
            Assert.AreEqual(3, _ProductService.GetAllProducts().Count());
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Assert.AreEqual(2, _ProductService.GetAllProducts().Count());
            _ProductService.DeleteProduct(1);
            Assert.AreEqual(1, _ProductService.GetAllProducts().Count());
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product product1 = _ProductService.GetProductById(1);
            Assert.AreEqual("Sofa", product1.Name);
            Assert.AreEqual(243.23, product1.Price);
            _ProductService.UpdateProduct(1, "Chair", 102.12);
            Product product2 = _ProductService.GetProductById(1);
            Assert.AreEqual("Chair", product2.Name);
            Assert.AreEqual(102.12, product2.Price);
        }
    }
}
