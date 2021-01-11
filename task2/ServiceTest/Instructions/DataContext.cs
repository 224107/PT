using Service.Models;
using System.Collections.Generic;

namespace ServiceTests.Instructions
{
    public class DataContext
    {
        public List<Customer> Customers = new List<Customer>();
        public List<Product> Products = new List<Product>();
        public List<Sale> Sales = new List<Sale>();
        public List<Supply> Supplies = new List<Supply>();
        public Dictionary<Product, int> ProductAmount = new Dictionary<Product, int>(); 
    }
}
