using System;
using Service.Models;

namespace ServiceTests.Instructions
{
    public class FixedExampleData
    {
        public void GenerateData(DataContext data)
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "Matt",
                LastName = "Newman"
            };
            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Watts"
            };            

            data.Customers.Add(customer1);
            data.Customers.Add(customer2);

            Product product1 = new Product()
            {
                Id = 1,
                Name = "Sofa",
                Price = 243.23
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "Table",
                Price = 99.99
            };

            data.Products.Add(product1);
            data.Products.Add(product2);

            data.ProductAmount.Add(product1, 10);
            data.ProductAmount.Add(product2, 20);

            Sale sale1 = new Sale()
            {
                Id = 1,
                Date = DateTime.Today,
                ProductId = 1,
                ProductAmount = 1,
                CustomerId = 1
            };
            Sale sale2 = new Sale()
            {
                Id = 2,
                Date = DateTime.Today,
                ProductId = 2,
                ProductAmount = 3,
                CustomerId = 2
            };

            data.Sales.Add(sale1);
            data.Sales.Add(sale2);

            Supply supply1 = new Supply()
            {
                Id = 1,
                Date = DateTime.Today,
                ProductId = 1,
                ProductAmount = 1                
            };
            Supply supply2 = new Supply()
            {
                Id = 2,
                Date = DateTime.Today,
                ProductId = 2,
                ProductAmount = 2
            };

            data.Supplies.Add(supply1);
            data.Supplies.Add(supply2);
        }
    }
}
