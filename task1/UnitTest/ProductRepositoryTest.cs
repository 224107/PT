using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
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
            Product product = new Product(4, "Lamp", 23.23);
            Assert.AreEqual(3, repository.GetAllProduct().Count);
            repository.AddProduct(product);
            Assert.AreEqual(4, repository.GetAllProduct().Count);
        }

        [TestMethod]
        public void GetProductByIdTest()
        {
            Product product = new Product(4, "Lamp", 23.23);
            repository.AddProduct(product);
            Product productById = repository.GetProductById(4);
            Assert.AreEqual(product, productById);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product product = repository.GetProductById(1);
            Product productUpdated = new Product(1, "Lamp", 23.23);
            Assert.AreEqual(product, repository.GetProductById(1));
            repository.UpdateProduct(productUpdated);
            Assert.AreEqual(product, repository.GetProductById(1));
            Assert.AreEqual(productUpdated.Name, repository.GetProductById(1).Name);
            Assert.AreEqual(productUpdated.Price, repository.GetProductById(1).Price);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Assert.AreEqual(3, repository.GetAllProduct().Count);
            repository.DeleteProduct(1);
            Assert.AreEqual(2, repository.GetAllProduct().Count);
        }

        [TestMethod]
        public void GetEmptyProductListTest()
        {
            repository.DeleteProduct(1);
            repository.DeleteProduct(2);
            repository.DeleteProduct(3);

            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllProduct());
            Assert.AreSame(ex.Message, "There's no products");
        }

        [TestMethod]
        public void GetNonExistingProductTest()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetProductById(4));
            Assert.AreSame(ex.Message, "There's no product with such id");
        }

        [TestMethod]
        public void GetAvailableProductTest()
        {
            Assert.AreEqual(3, repository.GetAvailableProducts().Count);
            repository.ReduceAmountOfProduct(repository.GetProductById(1), repository.GetProductAmountById(1));
            Assert.AreEqual(2, repository.GetAvailableProducts().Count);
        }

        [TestMethod]
        public void GetProductQtyByIdTest()
        {
            Assert.AreEqual(11, repository.GetProductAmountById(1));
            repository.IncreaseAmountOfProduct(repository.GetProductById(1), 11);
            Assert.AreEqual(22, repository.GetProductAmountById(1));
        }
    }
}
