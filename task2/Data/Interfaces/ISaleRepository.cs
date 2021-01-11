using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        Sale GetSaleById(int id);
        List<Sale> GetAllSales();
        List<Sale> GetSalesByProductId(int id);
        List<Sale> GetSalesByCustomerId(int id);
        Sale GetLastSale();
        void DeleteSale(int id);
    }
}
