using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Data.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private string ShopDataConnection;
        public SupplyRepository()
        {
            ShopDataConnection = global::Data.Properties.Settings.Default.ShopConnectionString;
        }
        public SupplyRepository(string connection)
        {
            ShopDataConnection = connection;
        }
        public void AddSupply(Supply supply)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                db.Supplies.InsertOnSubmit(supply);
                db.SubmitChanges();
            }
        }
        public Supply GetSupplyById(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Supplies.FirstOrDefault(supply => supply.id.Equals(id));
            }
        }
        public List<Supply> GetSuppliesByProductId(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Supplies.Where(supply => supply.product.Equals(id)).ToList();
            }
        }       
        public List<Supply> GetAllSupplies()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Supplies.Select(supply => supply).ToList();
            }
        }
        public Supply GetLastSupply()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Supplies.Select(supply => supply).ToList().LastOrDefault();
            }
        }
        public void DeleteSupply(int id)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Supply supplyDelete = db.Supplies.FirstOrDefault(s => s.id.Equals(id));

                if (supplyDelete != null)
                {
                    db.Supplies.DeleteOnSubmit(supplyDelete);
                    db.SubmitChanges();
                }
            }
        }
    }
}
