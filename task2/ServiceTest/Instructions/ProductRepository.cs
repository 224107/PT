using Data.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTests.Instructions
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _DataContext;
        public ProductRepository(DataContext data)
        {
            _DataContext = data;
        }
        public void AddProduct(Data.Product product)
        {
            _DataContext.Products.Add(Mapper.DatabaseProductToServiceProduct(product));
        }

        Data.Product IProductRepository.GetProductById(int id)
        {
            var product = _DataContext.Products.FirstOrDefault(c => c.Id.Equals(id));
            return Mapper.ServiceProductToDatabaseProduct(product);
        }

        List<Data.Product> IProductRepository.GetAllProducts()
        {
            List<Data.Product> products = new List<Data.Product>();
            foreach (var product in _DataContext.Products)
            {
                products.Add(Mapper.ServiceProductToDatabaseProduct(product));
            }
            return products;
        }

        Data.Product IProductRepository.GetLastProduct()
        {
            var product = _DataContext.Products.LastOrDefault();
            return Mapper.ServiceProductToDatabaseProduct(product);
        }

        public void UpdateProduct(Data.Product product)
        {
            Product productUpdate = _DataContext.Products.FirstOrDefault(c => c.Id.Equals(product.id));

            if (productUpdate != null)
            {
                productUpdate.Name = product.product_name;
                productUpdate.Price = (double)product.price;
            }
        }

        public void DeleteProduct(int id)
        {
            Product productDelete = _DataContext.Products.FirstOrDefault(product => product.Id.Equals(id));

            if (productDelete != null)
            {
                _DataContext.Products.Remove(productDelete);
            }
        }

        public int GetProductAmount(int id)
        {
            Product product = _DataContext.Products.FirstOrDefault(c => c.Id.Equals(id));
            return _DataContext.ProductAmount[product];
        }

        public void ChangeProductAmount(int productId, int amount)
        {
            Product product = _DataContext.Products.FirstOrDefault(c => c.Id.Equals(productId));
            _DataContext.ProductAmount[product] += amount;
        }
    }
}
