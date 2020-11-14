namespace Data
{
    public class Supplier
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public Supplier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
