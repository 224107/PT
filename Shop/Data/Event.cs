using System;

namespace Data
{
    abstract class Event
    {
        protected int Id { get; set; }
        protected ProductsAvaibility ProductsQty { get; set; }
        protected DateTime Date { get; }

        protected Event(int id,ProductsAvaibility productsQty, DateTime date)
        {
            Id = id;
            ProductsQty = productsQty;
            Date = date;
        }
    }
    class Sale : Event
    {
        private Customer Customer { get; set; }

        public Sale(int id, ProductsAvaibility productsQty, DateTime date, Customer customer) : base(id, productsQty, date)
        {
            Customer = customer;
        }
    }
    class Supply : Event
    {
        private Supplier Supplier { get; set; }
        public Supply(int id, ProductsAvaibility productsQty, DateTime date, Supplier supplier) : base(id, productsQty, date)
        {
            Supplier = supplier;
        }
    }
}
