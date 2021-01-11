using Data.Interfaces;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class EventService : IEventService
    {
        private ICustomerRepository _CustomerRepository { get; }
        private IProductRepository _ProductRepository { get; }
        private ISaleRepository _SaleRepository { get; }
        private ISupplyRepository _SupplyRepository { get; }
        public EventService(ICustomerRepository customerRepository, IProductRepository productRepository, 
            ISaleRepository saleRepository, ISupplyRepository supplyRepository)
        {
            _CustomerRepository = customerRepository;
            _ProductRepository = productRepository;
            _SaleRepository = saleRepository;
            _SupplyRepository = supplyRepository;
        }
        public bool AddSale(int productId, int customerId, int amount)
        {
            if (ProductExist(productId) && CustomerExist(customerId) 
                && amount > 0 && _ProductRepository.GetProductAmount(productId) > amount)
            {
                int id = _SaleRepository.GetLastSale().id++;
                Sale sale = new Sale()
                {
                    Id = id,
                    Date = DateTime.Today,
                    ProductId = productId,
                    ProductAmount = amount,
                    CustomerId = customerId
                };
                _SaleRepository.AddSale(Mapper.ServiceSaleToDatabaseSale(sale));
                _ProductRepository.ChangeProductAmount(productId, -amount);
                return true;
            }
            return false;
        }

        public bool AddSupply(int productId, int amount)
        {
            if (ProductExist(productId) && amount > 0)
            {
                int id = _SupplyRepository.GetLastSupply().id++;
                Supply supply = new Supply()
                {
                    Id = id,
                    Date = DateTime.Today,
                    ProductId = productId,
                    ProductAmount = amount                    
                };
                _SupplyRepository.AddSupply(Mapper.ServiceSupplyToDatabaseSupply(supply));
                _ProductRepository.ChangeProductAmount(productId, amount);
                return true;
            }
            return false;
        }

        public bool DeleteSale(int id)
        {
            if (SaleExist(id))
            {
                _SaleRepository.DeleteSale(id);
                return true;
            }
            return false;
        }

        public bool DeleteSupply(int id)
        {
            if (SupplyExist(id))
            {
                _SupplyRepository.DeleteSupply(id);
                return true;
            }
            return false;
        }

        public List<Sale> GetAllCustomerSales(int customerId)
        {
            List<Sale> sales = new List<Sale>();
            if (CustomerExist(customerId))
            {
                foreach (var sale in _SaleRepository.GetSalesByCustomerId(customerId))
                {
                    sales.Add(Mapper.DatabaseSaleToServiceSale(sale));
                }
            }
            return sales;
        }

        public List<Sale> GetAllProductSales(int productId)
        {
            List<Sale> sales = new List<Sale>();
            if (ProductExist(productId))
            {
                foreach (var sale in _SaleRepository.GetSalesByProductId(productId))
                {
                    sales.Add(Mapper.DatabaseSaleToServiceSale(sale));
                }
            }
            return sales;
        }

        public List<Supply> GetAllProductSupplies(int productId)
        {
            List<Supply> supplies = new List<Supply>();
            if (ProductExist(productId))
            {
                foreach (var supply in _SupplyRepository.GetSuppliesByProductId(productId))
                {
                    supplies.Add(Mapper.DatabaseSupplyToServiceSupply(supply));
                }
            }
            return supplies;
        }

        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            foreach (var sale in _SaleRepository.GetAllSales())
            {
                sales.Add(Mapper.DatabaseSaleToServiceSale(sale));
            }
            return sales;
        }

        public List<Supply> GetAllSupplies()
        {
            List<Supply> supplies = new List<Supply>();
            foreach (var supply in _SupplyRepository.GetAllSupplies())
            {
                supplies.Add(Mapper.DatabaseSupplyToServiceSupply(supply));
            }
            return supplies;
        }

        public Sale GetSaleById(int id)
        {
            if (SaleExist(id))
            {
                return Mapper.DatabaseSaleToServiceSale(_SaleRepository.GetSaleById(id));
            }
            throw new Exception("There's no sale with such id");
        }

        public Supply GetSupplyById(int id)
        {
            if (SupplyExist(id))
            {
                return Mapper.DatabaseSupplyToServiceSupply(_SupplyRepository.GetSupplyById(id));
            }
            throw new Exception("There's no supply with such id");
        }
        private bool ProductExist(int id)
        {
            return _ProductRepository.GetProductById(id) != null;
        }
        private bool CustomerExist(int id)
        {
            return _CustomerRepository.GetCustomerById(id) != null;
        }
        private bool SaleExist(int id)
        {
            return _SaleRepository.GetSaleById(id) != null;
        }
        private bool SupplyExist(int id)
        {
            return _SupplyRepository.GetSupplyById(id) != null;
        }
    }
}
