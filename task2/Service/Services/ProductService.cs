using Data.Interfaces;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository { get; }

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public bool AddProduct(string productName, double productPrice)
        {
            if (productName != null && productPrice > 0)
            {
                int id = _ProductRepository.GetLastProduct().id++;
                Product product = new Product()
                {
                    Id = id,
                    Name = productName,
                    Price = productPrice
                };
                _ProductRepository.AddProduct(Mapper.ServiceProductToDatabaseProduct(product));
                return true;
            }
            return false;
        }
        public bool DeleteProduct(int id)
        {
            if (ProductExist(id))
            {
                _ProductRepository.DeleteProduct(id);
                return true;
            }
            return false;
        }
        public List<Product> GetAllProducts()
        {
            List<Product> prodcuts = new List<Product>();
            foreach (var product in _ProductRepository.GetAllProducts())
            {
                prodcuts.Add(Mapper.DatabaseProductToServiceProduct(product));
            }
            return prodcuts;            
        }
        public Product GetProductById(int id)
        {
            if (ProductExist(id))
            {
                return Mapper.DatabaseProductToServiceProduct(_ProductRepository.GetProductById(id));
            }
            throw new Exception("There's no product with such id");
        }
        public bool UpdateProduct(int productId, string productName, double productPrice)
        {
            if (ProductExist(productId) && productPrice > 0)
            {
                Product product = new Product()
                {
                    Id = productId,
                    Name = productName,
                    Price = productPrice
                };
                _ProductRepository.UpdateProduct(Mapper.ServiceProductToDatabaseProduct(product));
                return true;
            }
            return false;
        }
        private bool ProductExist(int id)
        {
            return _ProductRepository.GetProductById(id) != null;
        }
    }
}
