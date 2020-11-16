using System.Collections.Generic;

namespace Data
{
    public class ProductsAvaibility
    {
        public ProductsCatalog Products { get; set; }
        public Dictionary<Product, int> ProductsQty { get; set; } = new Dictionary<Product, int>();

        public ProductsAvaibility(ProductsCatalog products)
        {
            Products = products;
        }
    }
}
