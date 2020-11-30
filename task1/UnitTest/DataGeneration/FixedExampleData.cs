using Data;
using System;

namespace DataUnitTests
{
    public class FixedExampleData : IDataGenerator
    {
        public void GenerateData(DataContext data)
        {
            Customer customer1 = new Customer(1, "Matt", "Newman");
            Customer customer2 = new Customer(2, "John", "Watts");
            Customer customer3 = new Customer(3, "Nicole", "Mayer");
            Customer customer4 = new Customer(4, "Scott", "Wild");

            data.Customers.Add(customer1);
            data.Customers.Add(customer2);
            data.Customers.Add(customer3);
            data.Customers.Add(customer4);

            Product product1 = new Product(1, "Sofa", 234.23);
            Product product2 = new Product(2, "Table", 99.99);
            Product product3 = new Product(3, "Chair", 25);
            Product product4 = new Product(4, "Lamp", 12.34);

            data.ProductsCatalog.Products.Add(product1);
            data.ProductsCatalog.Products.Add(product2);
            data.ProductsCatalog.Products.Add(product3);
            data.ProductsCatalog.Products.Add(product4);

            data.ProductsState.AvailableProducts.Add(product1, 11);
            data.ProductsState.AvailableProducts.Add(product2, 22);
            data.ProductsState.AvailableProducts.Add(product3, 33);
            data.ProductsState.AvailableProducts.Add(product4, 44);

            Sale sale1 = new Sale(customer1, DateTime.Now, data.ProductsState);
            Sale sale2 = new Sale(customer2, DateTime.Now, data.ProductsState);
            Supply supply1 = new Supply(DateTime.Now, data.ProductsState);
            Supply supply2 = new Supply(DateTime.Now, data.ProductsState);

            data.Events.Add(sale1);
            data.Events.Add(sale2);
            data.Events.Add(supply1);
            data.Events.Add(supply2);
        }
    }
}
