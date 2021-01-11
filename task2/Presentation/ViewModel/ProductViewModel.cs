using System.Collections.Generic;
using Presentation.Base;
using System.Windows.Input;
using Service.Services;
using Service.Interfaces;
using Service.Models;
using Data.Repositories;



namespace Presentation.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {

        #region ATTRIBUTES
        IProductService service;
        List<Product> products;
        ProductRepository rep;
        Product selectedProduct;

        ICommand addCommand;
        ICommand deleteCommand;
        ICommand updateCommand;

        private string nameA;
        private double priceA;
        private string nameU;
        private double priceU;

        #endregion

        public ProductViewModel()
        {
            rep = new ProductRepository();
            service = new ProductService(rep);
            products = new List<Product>();
            products = service.GetAllProducts();
            selectedProduct = new Product();
            addCommand = new RelayCommand(e => { AddProduct(); });
            deleteCommand = new RelayCommand(e => { DeleteProduct(); });
            updateCommand = new RelayCommand(e => { UpdateProduct(); });

        }

        #region API
        public List<Product> Products
        {
            get => products;

            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public string NameA
        {
            get => nameA;
            set
            {
                nameA = value;
                OnPropertyChanged(nameof(NameA));
            }
        }

        public double PriceA
        {
            get => priceA;
            set
            {
                priceA = value;
                OnPropertyChanged(nameof(PriceA));
            }
        }

        public string NameU
        {
            get => nameU;
            set
            {
                nameU = value;
                OnPropertyChanged(nameof(NameU));
            }
        }

        public double PriceU
        {
            get => priceU;
            set
            {
                priceU = value;
                OnPropertyChanged(nameof(PriceU));
            }
        }


        public Product SelectedProduct
        {
            get => selectedProduct;

            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public ICommand UpdateCommand
        {
            get => updateCommand;
        }

        #endregion

        #region METHODS
        private void AddProduct()
        {

            service.AddProduct(nameA, priceA);
            products = service.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }
        private void DeleteProduct()
        {

            service.DeleteProduct(SelectedProduct.Id);
            products = service.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }

        private void UpdateProduct()
        {
            service.UpdateProduct(SelectedProduct.Id, nameU, priceU);
            products = service.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }
        #endregion
    }

}

