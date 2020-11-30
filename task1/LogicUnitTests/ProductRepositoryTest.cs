using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LogicUnitTests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProduct repository;
        private DataContext data;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            repository = new ProductRepository(data);
        }

        [TestMethod]
        public void AddProductTest()
        {
            Product product = new Product(101, "Paint", 23.23);
            repository.AddProduct(product);
            Assert.AreEqual(1, repository.GetAllProduct().Count);
        }

        [TestMethod]
        public void GetProductByIdTest()
        {
            Product product = new Product(101, "Paint", 23.23);
            repository.AddProduct(product);
            Product productById = repository.GetProductById(101);
            Assert.AreEqual(product, productById);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product product = new Product(101, "Paint", 23.23);
            Product productUpdated = new Product(product.Id, "Hi-Fi",  999.33);
            repository.AddProduct(product);
            Assert.AreEqual(product, repository.GetProductById(product.Id));
            repository.UpdateProduct(productUpdated);
            Assert.AreEqual(productUpdated.Name, repository.GetProductById(product.Id).Name);
            Assert.AreEqual(productUpdated.Price, repository.GetProductById(product.Id).Price);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Product product1 = new Product(101, "Paint", 23.23);
            Product product2 = new Product(102, "Hi-Fi", 999.33);
            repository.AddProduct(product1);
            repository.AddProduct(product2);
            Assert.AreEqual(2, repository.GetAllProduct().Count);
            repository.DeleteProduct(product1.Id);
            Assert.AreEqual(1, repository.GetAllProduct().Count);
        }

        [TestMethod]
        public void GetEmptyProductListTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllProduct());
            Assert.AreSame(ex.Message, "There's no products");
        }

        [TestMethod]
        public void GetNonExistingProductTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetProductById(1));
            Assert.AreSame(ex.Message, "There's no product with such id");
        }

        [TestMethod]
        public void GetAvailableProductTest()
        {
            Product product = new Product(101, "Paint", 23.23);
            repository.AddProduct(product);
            repository.IncreaseAmountOfProduct(repository.GetProductById(product.Id), 11);
            Assert.AreEqual(1, repository.GetAvailableProducts().Count);
            repository.ReduceAmountOfProduct(repository.GetProductById(product.Id), repository.GetProductAmountById(product.Id));
            Assert.AreEqual(0, repository.GetAvailableProducts().Count);
        }
    }
}
