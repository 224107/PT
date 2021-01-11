using Data.Interfaces;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _CustomerRepository { get; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        public bool AddCustomer(string customerFirstName, string customerLastName)
        {
            if (customerFirstName != null && customerLastName != null)
            {
                int id = _CustomerRepository.GetLastCustomer().id++;
                Customer customer = new Customer()
                {
                    Id = id,
                    FirstName = customerFirstName,
                    LastName = customerLastName
                };
                _CustomerRepository.AddCustomer(Mapper.ServiceCustomerToDatabaseCustomer(customer));
                return true;
            }
            return false;
        }
        public bool DeleteCustomer(int id)
        {
            if (CustomerExist(id))
            {
                _CustomerRepository.DeleteCustomer(id);
                return true;
            }
            return false; 
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            foreach (var customer in _CustomerRepository.GetAllCustomers())
            {
                customers.Add(Mapper.DatabaseCustomerToServiceCustomer(customer));
            }
            return customers;

        }
        public Customer GetCustomerById(int id)
        {
            if (CustomerExist(id)){
                return Mapper.DatabaseCustomerToServiceCustomer(_CustomerRepository.GetCustomerById(id));
            }
            throw new Exception("There's no customer with such id");
        }
        public bool UpdateCustomer(int customerId, string customerFirstName, string customerLastName)
        {
            if (CustomerExist(customerId)){
                Customer customer = new Customer()
                {
                    Id = customerId,
                    FirstName = customerFirstName,
                    LastName = customerLastName
                };
                _CustomerRepository.UpdateCustomer(Mapper.ServiceCustomerToDatabaseCustomer(customer));
                return true;
            }
            return false;
        }
        private bool CustomerExist(int id)
        {
            return _CustomerRepository.GetCustomerById(id) != null;
        }
    }
}
