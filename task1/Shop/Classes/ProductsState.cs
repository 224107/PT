using System.Collections.Generic;

namespace Data
{
    public class ProductsState
    {
        public ProductsCatalog Products { get; set; }
        public Dictionary<Product, int> AvailableProducts { get; set; } = new Dictionary<Product, int>();

        public ProductsState(ProductsCatalog products)
        {
            Products = products;
        }
    }
}
