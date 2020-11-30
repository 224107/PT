using System.Collections.Generic;

namespace Data
{
    public class DataContext
    {
        public List<Customer> Customers;
        public List<Event> Events;
        public ProductsState ProductsState;
        public ProductsCatalog ProductsCatalog;
        public DataContext()
        {
            Customers = new List<Customer>();
            Events = new List<Event>();
            ProductsCatalog = new ProductsCatalog();
            ProductsState = new ProductsState(ProductsCatalog);                     
        }

    }
}
