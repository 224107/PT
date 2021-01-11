using Service.Models;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IEventService
    {
        bool AddSale(int productId, int customerId, int amount);
        bool AddSupply(int productId, int amount);
        Sale GetSaleById(int id);
        Supply GetSupplyById(int id);
        List<Sale> GetAllSales();
        List<Sale> GetAllProductSales(int productId);
        List<Sale> GetAllCustomerSales(int customerId);
        List<Supply> GetAllSupplies();        
        List<Supply> GetAllProductSupplies(int productId);
        bool DeleteSale(int id);              
        bool DeleteSupply(int id);
    }
}
