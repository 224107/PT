using Data.Interfaces;
using System;
using System.Linq;

namespace Data
{
    public class RandomExampleData : IDataGenerator
    {
        private const int STRING_LENGHT = 5;
        private static Random random = new Random();        
        public void GenerateData(DataContext data)
        {
            int eventType;
            for (int i = 0; i < 4; i++)
            {
                eventType = RandomInteger(0, 1);
                Customer customer = RandomCustomer();
                Product product = RandomProduct();
                data.Customers.Add(customer);
                data.ProductsCatalog.Products.Add(product);
                data.ProductsState.AvailableProducts.Add(product, RandomInteger(1, 20));
                switch (eventType)
                {
                    case 0:
                        Sale sale = new Sale(customer, RandomDate(), data.ProductsState);
                        data.Events.Add(sale);
                        break;
                    case 1:
                        Supply supply = new Supply(RandomDate(), data.ProductsState);
                        data.Events.Add(supply);
                        break;
                    default:
                        break;
                }
            }
        }
        private Customer RandomCustomer()
        {
            Customer customer = new Customer(RandomInteger(0, 100), RandomString() , RandomString());
            return customer;
        }
        private Product RandomProduct()
        {
            Product product = new Product(RandomInteger(0, 100), RandomString(), RandomDouble(1, 200));
            return product;
        }
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, STRING_LENGHT)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private int RandomInteger(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        private double RandomDouble(int minValue, int maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
        private DateTime RandomDate()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
