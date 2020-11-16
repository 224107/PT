using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data
{
    public class DataContext : IDataContext
    {
        public List<Customer> customers = new List<Customer>();
        public List<Event> events = new List<Event>();
        public ProductsCatalog products;
        public ProductsAvaibility availableProducts;

        public DataContext()
        {
            products = new ProductsCatalog();
            availableProducts = new ProductsAvaibility(products);

            //Example vlaues
            Customer customer1 = new Customer(1, "Mark", "Time");
            Customer customer2 = new Customer(2, "Daniel", "Well");
            Customer customer3 = new Customer(3, "John", "Bosh");

            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            Product product1 = new Product(1, "Sofa", 245.99);
            Product product2 = new Product(2, "Chair", 99.90);
            Product product3 = new Product(3, "Table", 111.11);

            products.Products.Add(product1);
            products.Products.Add(product2);
            products.Products.Add(product3);

            availableProducts.ProductsQty[product1] = 11;
            availableProducts.ProductsQty[product2] = 22;
            availableProducts.ProductsQty[product3] = 33;

            Sale sale1 = new Sale(1, DateTime.Now, customer1);
            Sale sale2 = new Sale(2, DateTime.Now, customer2);
            Supply supply1 = new Supply(3, DateTime.Now);
            Supply supply2 = new Supply(4, DateTime.Now);

            events.Add(sale1);
            events.Add(sale2);
            events.Add(supply1);
            events.Add(supply2);
        }

        public List<Customer> Customers()
        {
            return customers;
        }

        public List<Event> Events()
        {
            return events;
        }

        public List<Product> Products()
        {
            return products.Products;
        }

        public Dictionary<Product, int> ProductsQty()
        {
            return availableProducts.ProductsQty;
        }
    }
}
