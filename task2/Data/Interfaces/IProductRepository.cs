using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        Product GetLastProduct();
        int GetProductAmount(int id);
        void UpdateProduct(Product product);
        void ChangeProductAmount(int productId, int amount);
        void DeleteProduct(int id);        
    }
}
