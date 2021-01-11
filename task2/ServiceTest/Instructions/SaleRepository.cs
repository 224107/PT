using Data.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTests.Instructions
{
    public class SaleRepository : ISaleRepository
    {
        private DataContext _DataContext;
        public SaleRepository(DataContext data)
        {
            _DataContext = data;
        }
        public void AddSale(Data.Sale sale)
        {
            _DataContext.Sales.Add(Mapper.DatabaseSaleToServiceSale(sale));
        }

        Data.Sale ISaleRepository.GetSaleById(int id)
        {
            var sale = _DataContext.Sales.FirstOrDefault(s => s.Id.Equals(id));
            return Mapper.ServiceSaleToDatabaseSale(sale);
        }

        List<Data.Sale> ISaleRepository.GetAllSales()
        {
            List<Data.Sale> sales = new List<Data.Sale>();
            foreach (var sale in _DataContext.Sales)
            {
                sales.Add(Mapper.ServiceSaleToDatabaseSale(sale));
            }
            return sales;
        }

        Data.Sale ISaleRepository.GetLastSale()
        {
            var sale = _DataContext.Sales.LastOrDefault();
            return Mapper.ServiceSaleToDatabaseSale(sale);
        }        

        public void DeleteSale(int id)
        {
            Sale saleDelete = _DataContext.Sales.FirstOrDefault(sale => sale.Id.Equals(id));

            if (saleDelete != null)
            {
                _DataContext.Sales.Remove(saleDelete);
            }
        }

        public List<Data.Sale> GetSalesByProductId(int id)
        {
            List<Data.Sale> sales = new List<Data.Sale>();
            foreach (var sale in _DataContext.Sales)
            {
                if ( sale.ProductId == id)
                    sales.Add(Mapper.ServiceSaleToDatabaseSale(sale));
            }
            return sales;
        }

        public List<Data.Sale> GetSalesByCustomerId(int id)
        {
            List<Data.Sale> sales = new List<Data.Sale>();
            foreach (var sale in _DataContext.Sales)
            {
                if (sale.CustomerId == id)
                    sales.Add(Mapper.ServiceSaleToDatabaseSale(sale));
            }
            return sales;
        }
    }
}
