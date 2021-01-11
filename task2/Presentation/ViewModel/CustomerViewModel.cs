using System.Collections.Generic;
using Presentation.Base;
using System.Windows.Input;
using Service.Services;
using Service.Interfaces;
using Service.Models;
using Data.Repositories;


namespace Presentation.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        ICustomerService service;
        List<Customer> customers;
        CustomerRepository rep;
        Customer selectedCustomer;

        ICommand addCommand;
        ICommand deleteCommand;
        ICommand updateCommand;

        private string firstNameA;
        private string lastNameA;
        private string firstNameU;
        private string lastNameU;

        #endregion

        public CustomerViewModel()
        {
            rep = new CustomerRepository();
            service = new CustomerService(rep);
            customers = new List<Customer>();
            customers = service.GetAllCustomers();
            selectedCustomer = new Customer();
            addCommand    = new RelayCommand(e => { AddCustomer(); });
            deleteCommand = new RelayCommand(e => { DeleteCustomer(); });
            updateCommand = new RelayCommand(e => { UpdateCustomer(); });

        }

        #region API
        public List<Customer> Customers
        {
            get => customers;

            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public string FirstNameA
        {
            get => firstNameA;
            set
            {
                firstNameA = value;
                OnPropertyChanged(nameof(FirstNameA));
            }
        }

        public string LastNameA
        {
            get => lastNameA;
            set
            {
                lastNameA = value;
                OnPropertyChanged(nameof(LastNameA));
            }
        }

        public string FirstNameU
        {
            get => firstNameU;
            set
            {
                firstNameU = value;
                OnPropertyChanged(nameof(FirstNameU));
            }
        }

        public string LastNameU
        {
            get => lastNameU;
            set
            {
                lastNameU = value;
                OnPropertyChanged(nameof(LastNameU));
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;

            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
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
        private void AddCustomer()
        {

            service.AddCustomer(firstNameA,lastNameA);
            customers = service.GetAllCustomers();
            OnPropertyChanged(nameof(Customers));
        }
        private void DeleteCustomer()
        {
          
            service.DeleteCustomer(SelectedCustomer.Id);
            customers = service.GetAllCustomers();
            OnPropertyChanged(nameof(Customers));
        }

        private void UpdateCustomer()
        {
            service.UpdateCustomer(SelectedCustomer.Id, firstNameU, lastNameU);
            customers = service.GetAllCustomers();
            OnPropertyChanged(nameof(Customers));
        }
        #endregion

    }
}
