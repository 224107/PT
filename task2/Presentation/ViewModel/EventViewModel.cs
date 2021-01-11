using System.Collections.Generic;
using Presentation.Base;
using System.Windows.Input;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using Data.Interfaces;
using Data.Repositories;


namespace Presentation.ViewModel
{
    class EventViewModel : BaseViewModel
    {

        #region ATTRIBUTES
        IEventService service;
        List<Sale> sales;
        List<Supply> supplies;

        Supply selectedSupply;
        Sale selectedSale;

        private ICustomerRepository customerRepository;
        private IProductRepository productRepository;
        private ISaleRepository saleRepository;
        private ISupplyRepository supplyRepository;

        ICommand addSaleCommand;
        ICommand addSupplyCommand;
        ICommand deleteSaleCommand;
        ICommand deleteSupplyCommand;

        int saleProductID;
        int saleCustomerID;
        int saleAmount;

        int supplyProductID;
        int supplyAmount;

        #endregion 
        public EventViewModel()
        {
            customerRepository = new CustomerRepository();
            productRepository = new ProductRepository();
            saleRepository = new SaleRepository();
            supplyRepository = new SupplyRepository();
            service = new EventService(customerRepository, productRepository, saleRepository, supplyRepository);

            sales = new List<Sale>();
            supplies = new List<Supply>();
            selectedSupply = new Supply();
            selectedSale = new Sale();
            sales = service.GetAllSales();
            supplies = service.GetAllSupplies();

            addSaleCommand = new RelayCommand(e => { AddSale(); });
            addSupplyCommand = new RelayCommand(e => { AddSupply(); });
            deleteSaleCommand = new RelayCommand(e => { DeleteSale(); });
            deleteSupplyCommand = new RelayCommand(e => { DeleteSupply(); });

        }

        #region API

        public List<Sale> Sales
        {
            get => sales;

            set
            {
                sales = value;
                OnPropertyChanged(nameof(Sales));
            }
        }

        public List<Supply> Supplies
        {
            get => supplies;

            set
            {
                supplies = value;
                OnPropertyChanged(nameof(Supplies));
            }
        }

        public int SaleProductID
        {
            get => saleProductID;

            set
            {
                saleProductID = value;
                OnPropertyChanged(nameof(SaleProductID));
            }
        }

        public int SaleCustomerID
        {
            get => saleCustomerID;

            set
            {
                saleCustomerID = value;
                OnPropertyChanged(nameof(SaleCustomerID));
            }
        }

        public int SaleAmount
        {
            get => saleAmount;

            set
            {
                saleAmount = value;
                OnPropertyChanged(nameof(SaleAmount));
            }
        }

        public int SupplyProductID
        {
            get => supplyProductID;

            set
            {
                supplyProductID = value;
                OnPropertyChanged(nameof(SupplyProductID));
            }
        }

        public int SupplyAmount
        {
            get => supplyAmount;

            set
            {
                supplyAmount = value;
                OnPropertyChanged(nameof(SupplyAmount));
            }
        }

        public Sale SelectedSale
        {
            get => selectedSale;

            set
            {
                selectedSale = value;
                OnPropertyChanged(nameof(SelectedSale));
            }
        }

        public Supply SelectedSupply
        {
            get => selectedSupply;

            set
            {
                selectedSupply = value;
                OnPropertyChanged(nameof(SelectedSupply));
            }
        }

        public ICommand AddSaleCommand
        {
            get => addSaleCommand;
        }

        public ICommand AddSupplyCommand
        {
            get => addSupplyCommand;
        }

        public ICommand DeleteSaleCommand
        {
            get => deleteSaleCommand;
        }

        public ICommand DeleteSupplyCommand
        {
            get => deleteSupplyCommand;
        }
        #endregion

        #region METHODS
        private void AddSale()
        {
            service.AddSale(saleProductID, saleCustomerID, saleAmount);
            sales = service.GetAllSales();
            OnPropertyChanged(nameof(Sales));
        }

        private void AddSupply()
        {
            service.AddSupply(supplyProductID, supplyAmount);
            supplies = service.GetAllSupplies();
            OnPropertyChanged(nameof(Supplies));
        }

        private void DeleteSale()
        {
            service.DeleteSale(SelectedSale.Id);
            sales = service.GetAllSales();
            OnPropertyChanged(nameof(Sales));
        }

        private void DeleteSupply()
        {
            service.DeleteSupply(SelectedSupply.Id);
            supplies = service.GetAllSupplies();
            OnPropertyChanged(nameof(Supplies));
        }
        #endregion
    }
}
