using Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class DataService
    {
        private readonly ICustomer customerRepository;
        private readonly IEvent eventRepository;
        private readonly IProduct productRepository;

        public DataService(ICustomer customerRepository, IEvent eventRepository, IProduct productRepository)
        {
            this.customerRepository = customerRepository;
            this.eventRepository = eventRepository;
            this.productRepository = productRepository;
        }

        //Customer Service
        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
        public Customer GetCustomerbyId(int id)
        {
            return customerRepository.GetCustomerById(id);
        }
        public void AddCustomer(int id, string firstName, string lastName)
        {
            Customer customer = new Customer(id, firstName, lastName);
            customerRepository.AddCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            customerRepository.DeleteCustomer(id);
        }
        public void UpdateCustomer(int id, string newFirstName, string newLastName)
        {
            Customer customer = new Customer(id, newFirstName, newLastName);
            customerRepository.UpdateCustomer(customer);
        }

        //Event Service
        public List<Event> GetAllEvents()
        {
            if (eventRepository.GetAllEvents().Count == 0)
                return null;
            else
                return eventRepository.GetAllEvents();
        }
        public Event GetEventByID(int id)
        {
            return eventRepository.GetEventById(id);
        }
        public void AddSale(int id, int productId, int customerId, int qty)
        {
            Product product = productRepository.GetProductById(productId);
            Customer customer = customerRepository.GetCustomerById(customerId);
            if (productRepository.GetProductAmountById(id) < qty)
                throw new Exception("There's no Product available");
            else
            {
                productRepository.ReduceAmountOfProduct(product, qty);
                Sale saleEvent = new Sale(id, DateTime.Now, customer);
                eventRepository.AddEvent(saleEvent);
            }
        }
        public void AddSupply(int id, int productId, int qty)
        {
            Product product = productRepository.GetProductById(productId);
            productRepository.IncreaseAmountOfProduct(product, qty);
            Supply supply = new Supply(id, DateTime.Now);
            eventRepository.AddEvent(supply);
        }
        public void DeleteEvent(int id)
        {
            eventRepository.DeleteEvent(id);
        }

        //Product Service

        public List<Product> GetAllProducts()
        {
            if (productRepository.GetAllProduct().Count == 0)
                return null;
            else
                return productRepository.GetAllProduct();
        }
        public List<Product> GetAllAvailableProducts()
        {
            return productRepository.GetAvailableProducts();
        }
        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }
        public void AddProduct(int id, string name, double price)
        {
            Product product = new Product(id, name, price);
            productRepository.AddProduct(product);
        }
        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }
        public void UpdateProduct(int id, string newName, double newPrice)
        {
            Product product = new Product(id, newName, newPrice);
            productRepository.UpdateProduct(product);
        }
    }
}
