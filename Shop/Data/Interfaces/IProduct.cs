using System.Collections.Generic;

namespace Data.Interfaces
{
    interface IProduct
    {
        List<Product> GetAllProducts();
        Product GetProductById();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
