using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private string ShopDataConnection;
        public SaleRepository()
        {
            ShopDataConnection = global::Data.Properties.Settings.Default.ShopConnectionString;
        }
        public SaleRepository(string connection)
        {
            ShopDataConnection = connection;
        }
        public void AddSale(Sale sale)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                db.Sales.InsertOnSubmit(sale);
                db.SubmitChanges();
            }
        }
        public Sale GetSaleById(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Sales.FirstOrDefault(sale => sale.id.Equals(id));
            }
        }
        public List<Sale> GetSalesByProductId(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Sales.Where(sale => sale.product.Equals(id)).ToList();
            }
        }
        public List<Sale> GetSalesByCustomerId(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Sales.Where(sale => sale.customer.Equals(id)).ToList();
            }
        }
        public List<Sale> GetAllSales()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Sales.Select(sale => sale).ToList();
            }
        }
        public Sale GetLastSale()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Sales.Select(sale => sale).ToList().LastOrDefault();
            }
        }
        public void DeleteSale(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Sale saleDelete = db.Sales.FirstOrDefault(s => s.id.Equals(id));

                if (saleDelete != null)
                {
                    db.Sales.DeleteOnSubmit(saleDelete);
                    db.SubmitChanges();
                }
            }
        }
    }
}
