using System.Collections.Generic;

namespace Data
{
    public class ProductsAvaibility
    {
        private ProductsCatalog Products{ get; set;}
        private Dictionary<int, int> ProductsQty { get; set; } = new Dictionary<int, int>();

        public ProductsAvaibility(ProductsCatalog products)
        {
            Products = products;
        }
    }
}
