using Data;
using Data.Interfaces;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DataUnitTests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProduct repository;
        private DataContext data;
        private IDataGenerator generator;

        [TestInitialize]
        public void Initialize()
        {
            data = new DataContext();
            repository = new ProductRepository(data);
            generator = new FixedExampleData();
            //generator = new RandomExampleData();
            generator.GenerateData(data);
        }

        [TestMethod]
        public void AddProductTest()
        {
            Product product = new Product(101, "Paint", 23.23);
            Assert.AreEqual(4, repository.GetAllProduct().Count);
            repository.AddProduct(product);
            Assert.AreEqual(5, repository.GetAllProduct().Count);
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
            Product product = repository.GetAllProduct().First();
            Product productUpdated = new Product(product.Id, "Paint", 23.23);
            Assert.AreEqual(product, repository.GetProductById(product.Id));
            repository.UpdateProduct(productUpdated);
            Assert.AreEqual(product, repository.GetProductById(product.Id));
            Assert.AreEqual(productUpdated.Name, repository.GetProductById(product.Id).Name);
            Assert.AreEqual(productUpdated.Price, repository.GetProductById(product.Id).Price);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            Product product = repository.GetAllProduct().First();
            Assert.AreEqual(4, repository.GetAllProduct().Count);
            repository.DeleteProduct(product.Id);
            Assert.AreEqual(3, repository.GetAllProduct().Count);
        }

        [TestMethod]
        public void GetEmptyProductListTest()
        {
            repository.GetAllProduct().Clear();
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetAllProduct());
            Assert.AreSame(ex.Message, "There's no products");
        }

        [TestMethod]
        public void GetNonExistingProductTest()
        {
            repository.GetAllProduct().Clear();
            Exception ex = Assert.ThrowsException<Exception>(() => repository.GetProductById(1));
            Assert.AreSame(ex.Message, "There's no product with such id");
        }

        [TestMethod]
        public void GetAvailableProductTest()
        {
            Product product = repository.GetAllProduct().First();
            Assert.AreEqual(4, repository.GetAvailableProducts().Count);
            repository.ReduceAmountOfProduct(repository.GetProductById(product.Id), repository.GetProductAmountById(product.Id));
            Assert.AreEqual(3, repository.GetAvailableProducts().Count);
        }

        [TestMethod]
        public void GetProductQtyByIdTest()
        {
            Product product = repository.GetAllProduct().First();
            int amount = repository.GetProductAmountById(product.Id);
            repository.IncreaseAmountOfProduct(repository.GetProductById(product.Id), 1);
            Assert.AreEqual(amount + 1, repository.GetProductAmountById(product.Id));
        }
    }
}
