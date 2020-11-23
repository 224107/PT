using System;

namespace Data
{
    public abstract class Event
    {
        public ProductsState ProductsState { get; set; }
        public DateTime Date { get; set; }
        public Event(DateTime date, ProductsState productsState)
        {
            Date = date;
            ProductsState = productsState;
        }
    }
    public class Sale : Event
    {
        public Customer Customer { get; set; }

        public Sale(Customer customer, DateTime date, ProductsState productsState) : base(date,  productsState)
        {
            Customer = customer;
        }
    }
    public class Supply : Event
    {
        public Supply(DateTime date, ProductsState productsState) : base(date,  productsState)
        {
        }
    }
}
