using Data.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTests.Instructions
{
    public class SupplyRepository : ISupplyRepository
    {
        private DataContext _DataContext;
        public SupplyRepository(DataContext data)
        {
            _DataContext = data;
        }
        public void AddSupply(Data.Supply supply)
        {
            _DataContext.Supplies.Add(Mapper.DatabaseSupplyToServiceSupply(supply));
        }

        Data.Supply ISupplyRepository.GetSupplyById(int id)
        {
            var supply = _DataContext.Supplies.FirstOrDefault(s => s.Id.Equals(id));
            return Mapper.ServiceSupplyToDatabaseSupply(supply);
        }

        List<Data.Supply> ISupplyRepository.GetAllSupplies()
        {
            List<Data.Supply> supplies = new List<Data.Supply>();
            foreach (var supply in _DataContext.Supplies)
            {
                supplies.Add(Mapper.ServiceSupplyToDatabaseSupply(supply));
            }
            return supplies;
        }

        Data.Supply ISupplyRepository.GetLastSupply()
        {
            var supply = _DataContext.Supplies.LastOrDefault();
            return Mapper.ServiceSupplyToDatabaseSupply(supply);
        }

        public void DeleteSupply(int id)
        {
            Supply supplyDelete = _DataContext.Supplies.FirstOrDefault(supply => supply.Id.Equals(id));

            if (supplyDelete != null)
            {
                _DataContext.Supplies.Remove(supplyDelete);
            }
        }

        public List<Data.Supply> GetSuppliesByProductId(int id)
        {
            List<Data.Supply> supplies = new List<Data.Supply>();
            foreach (var supply in _DataContext.Supplies)
            {
                if (supply.ProductId == id)
                    supplies.Add(Mapper.ServiceSupplyToDatabaseSupply(supply));
            }
            return supplies;
        }
    }
}
