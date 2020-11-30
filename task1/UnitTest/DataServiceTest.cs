using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataUnitTests
{
    [TestClass]
    public class DataServiceTest
    {       
        private DataService service;
        private DataContext context;
        private ICustomer customerRepository;
        private IProduct productRepository;
        private IEvent eventRepository;
        private IDataGenerator generator;

        [TestInitialize]
        public void Initialize()
        {
            context = new DataContext();
            customerRepository = new CustomerRepository(context);
            productRepository = new ProductRepository(context);
            eventRepository = new EventRepository(context);
            service = new DataService(customerRepository, eventRepository, productRepository);
            generator = new FixedExampleData();
            //generator = new RandomExampleData();
            generator.GenerateData(context);                        
        }
        [TestMethod]
        public void AddingCustomersTest()
        {
            service.AddCustomer(101, "Mark", "Twain");
            Assert.AreEqual(5, service.GetAllCustomers().Count);
        }
        [TestMethod]
        public void DeletingCustomerTest()
        {
            int id = service.GetAllCustomers().First().Id;
            service.DeleteCustomer(id);
            Assert.AreEqual(3, service.GetAllCustomers().Count);
        }
        [TestMethod]
        public void UpdatingCustomerTest()
        {
            int id = service.GetAllCustomers().First().Id;
            service.UpdateCustomer(id, "Mark", "Twain");
            Assert.AreEqual("Mark", service.GetCustomerById(id).FirstName);
            Assert.AreEqual("Twain", service.GetCustomerById(id).LastName);
        }
        [TestMethod]
        public void AddSaleTest()
        {
            Product product = service.GetAllProducts().First();
            Customer customer = service.GetAllCustomers().First();
            service.AddSale(product, customer, 1);
            Assert.AreEqual(5, service.GetAllEvents().Count);
        }
        [TestMethod]
        public void AddSupplyTest()
        {
            Product product = service.GetAllProducts().First();
            service.AddSupply(product,  1);
            Assert.AreEqual(5, service.GetAllEvents().Count);
        }
        [TestMethod]
        public void DeleteEventTest()
        {
            Event _event = service.GetAllEvents().First();
            service.DeleteEvent(_event);
            Assert.AreEqual(3, service.GetAllEvents().Count);
        }
        [TestMethod]
        public void AddProductTest()
        {
            service.AddProduct(101, "Paint", 24.24);
            Assert.AreEqual(5, service.GetAllProducts().Count);
        }
        [TestMethod]
        public void GetProductByIdTest()
        {
            service.AddProduct(101, "Paint", 24.24);
            Product product = service.GetProductById(101);
            Assert.AreEqual("Paint", product.Name);
            Assert.AreEqual(24.24, product.Price);
        }
        [TestMethod]
        public void DeleteProductTest()
        {
            int id = service.GetAllProducts().First().Id;
            service.DeleteProduct(id);
            Assert.AreEqual(3, service.GetAllProducts().Count);
        }
        [TestMethod]
        public void UpdateProductTest()
        {
            service.AddProduct(101, "Paint", 24.24);
            service.UpdateProduct(101, "Shelf", 25.25);
            Assert.AreEqual("Shelf", service.GetProductById(101).Name);
            Assert.AreEqual(25.25, service.GetProductById(101).Price);
        }
        [TestMethod]
        public void GetAvailableProductsTest()
        {
            int id = service.GetAllProducts().First().Id;
            service.DeleteProduct(id);
            int available = service.GetAllAvailableProducts().Count;
            Assert.AreEqual(4, available);
        }
    }
}
