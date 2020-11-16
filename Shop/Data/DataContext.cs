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
