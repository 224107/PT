using Service.Models;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IProductService
    {
        bool AddProduct(string productName, double productPrice);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        bool UpdateProduct(int productId, string productName, double productPrice);
        bool DeleteProduct(int id);
    }
}
