using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IDataContext
    {
        List<Customer> Customers();
        List<Event> Events();
        List<Product> Products();
        Dictionary<Product, int> ProductsQty();
    }
}
