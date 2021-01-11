using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISupplyRepository
    {
        void AddSupply(Supply supply);
        Supply GetSupplyById(int id);
        List<Supply> GetAllSupplies();
        List<Supply> GetSuppliesByProductId(int id);
        Supply GetLastSupply();
        void DeleteSupply(int id);       
    }
}
