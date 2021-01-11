using System;

namespace Service.Models
{
    public abstract class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
    public class Sale : Event
    {
        public int CustomerId { get; set; }

    }
    public class Supply : Event
    {
        
    }
}
