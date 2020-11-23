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
            Data.ProductsCatalog.Products.Add(product);
            Data.ProductsState.AvailableProducts.Add(product, 0);
        }

        public void DeleteProduct(int id)
        {
            Data.ProductsCatalog.Products.Remove(GetProductById(id));
        }

        public List<Product> GetAllProduct()
        {
            if (Data.ProductsCatalog.Products.Count == 0)
                throw new Exception("There's no products");
            else
                return Data.ProductsCatalog.Products;
        }

        public Product GetProductById(int id)
        {
            for (int i = 0; i < Data.ProductsCatalog.Products.Count; i++)
            {
                if (Data.ProductsCatalog.Products[i].Id == id)
                    return Data.ProductsCatalog.Products[i];
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
            foreach (KeyValuePair<Product, int> qty in Data.ProductsState.AvailableProducts)
            {
                if (qty.Value > 0)
                    AvailableProducts.Add(qty.Key);
            }
            return AvailableProducts;
        }

        public int GetProductAmountById(int id)
        {
            if (Data.ProductsState.AvailableProducts.ContainsKey(GetProductById(id)))
            {
                return Data.ProductsState.AvailableProducts[GetProductById(id)];
            }
            throw new Exception("There's no product with such id");

        }

        public void IncreaseAmountOfProduct(Product product, int amount)
        {
            if (Data.ProductsState.AvailableProducts.ContainsKey(product))
            {
                Data.ProductsState.AvailableProducts[product] = GetProductAmountById(product.Id) + amount;
            }
        }

        public void ReduceAmountOfProduct(Product product, int amount)
        {
            if (Data.ProductsState.AvailableProducts.ContainsKey(product))
            {
                Data.ProductsState.AvailableProducts[product] = GetProductAmountById(product.Id) - amount;
            }
        }

        public ProductsState GetProductsState()
        {
            return Data.ProductsState;
        }
    }
}
