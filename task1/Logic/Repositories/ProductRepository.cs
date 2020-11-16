using Data;
using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext Data;

        public ProductRepository(DataContext dataContext)
        {
            Data = dataContext;
        }
        public void AddProduct(Product product)
        {
            Data.Products().Add(product);
        }

        public void DeleteProduct(int id)
        {
            Data.Products().Remove(GetProductById(id));
        }

        public List<Product> GetAllProduct()
        {
            if (Data.Products().Count == 0)
                throw new Exception("There's no products");
            else
                return Data.Products();
        }

        public Product GetProductById(int id)
        {
            for (int i = 0; i < Data.Products().Count; i++)
            {
                if (Data.Products()[i].Id == id)
                    return Data.Products()[i];
            }
            throw new Exception("There's no product with such id");
        }

        public void UpdateProduct(Product product)
        {
            GetProductById(product.Id).Name = product.Name;
            GetProductById(product.Id).Price = product.Price;
        }

        public List<Product> GetAvailableProducts()
        {
            List<Product> AvailableProducts = new List<Product>();
            foreach (KeyValuePair<Product, int> qty in Data.ProductsQty())
            {
                if (qty.Value != 0)
                    AvailableProducts.Add(qty.Key);
            }
            return AvailableProducts;
        }

        public int GetProductAmountById(int id)
        {
            if (Data.ProductsQty().ContainsKey(GetProductById(id)))
            {
                return Data.ProductsQty()[GetProductById(id)];
            }
            throw new Exception("There's no product with such id");

        }

        public void IncreaseAmountOfProduct(Product product, int amount)
        {
            if (Data.ProductsQty().ContainsKey(product))
            {
                Data.ProductsQty()[product] = GetProductAmountById(product.Id) + amount;
            }
        }

        public void ReduceAmountOfProduct(Product product, int amount)
        {
            if (Data.ProductsQty().ContainsKey(product))
            {
                Data.ProductsQty()[product] = GetProductAmountById(product.Id) - amount;
            }
        }
    }
}
