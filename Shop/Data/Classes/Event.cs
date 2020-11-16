using System;

namespace Data
{
    public abstract class Event
    {
        public int Id { get; set; }
        public ProductsAvaibility ProductsQty { get; set; }
        public DateTime Date { get; set; }

        public Event(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }
    }
    public class Sale : Event
    {
        public Customer Customer { get; set; }

        public Sale(int id, DateTime date, Customer customer) : base(id, date)
        {
            Customer = customer;
        }
    }
    public class Supply : Event
    {
        public Supply(int id, DateTime date) : base(id,  date)
        {
        }
    }
}
