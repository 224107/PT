using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private string ShopDataConnection;
        public ProductRepository()
        {
            ShopDataConnection = global::Data.Properties.Settings.Default.ShopConnectionString;
        }
        public ProductRepository(string connection)
        {
            ShopDataConnection = connection;
        }
        public void AddProduct(Product product)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();
            }
        }
        public Product GetProductById(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Products.FirstOrDefault(product => product.id.Equals(id));
            }
        }
        public Product GetProductByName(string name)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Products.FirstOrDefault(product => product.product_name.Equals(name));
            }
        }
        public List<Product> GetAllProducts()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Products.Select(product => product).ToList();
            }
        }
        public Product GetLastProduct()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Products.Select(product => product).ToList().LastOrDefault();
            }
        }
        public int GetProductAmount(int id)
        {
            return (int)GetProductById(id).amount;
        }
        public void UpdateProduct(Product product)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Product productUpdate = db.Products.FirstOrDefault(p => p.id.Equals(product.id));

                if (productUpdate != null)
                {
                    productUpdate.product_name = product.product_name;
                    productUpdate.price = product.price;
                    productUpdate.amount = product.amount;
                    db.SubmitChanges();
                }
            }
        }
        public void ChangeProductAmount(int productId, int amount)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Product productUpdate = db.Products.FirstOrDefault(p => p.id.Equals(productId));

                if (productUpdate != null)
                {
                    productUpdate.amount += amount;
                    db.SubmitChanges();
                }
            }
        }
        public void DeleteProduct(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Product productDelete = db.Products.FirstOrDefault(product => product.id.Equals(id));

                if (productDelete != null)
                {
                    db.Products.DeleteOnSubmit(productDelete);
                    db.SubmitChanges();
                }
            }
        }        
    }
}
