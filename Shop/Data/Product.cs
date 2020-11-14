namespace Data
{
    public class Product
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
