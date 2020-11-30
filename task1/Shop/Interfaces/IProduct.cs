using System.Collections.Generic;

namespace Data
{
    public interface IProduct
    {
        List<Product> GetAllProduct();
        List<Product> GetAvailableProducts();
        ProductsState GetProductsState();
        Product GetProductById(int id);
        int GetProductAmountById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void IncreaseAmountOfProduct(Product product, int amount);
        void ReduceAmountOfProduct(Product product, int amount);
    }
}
