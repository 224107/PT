using Data.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceTests.Instructions
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext _DataContext;
        public CustomerRepository( DataContext data)
        {
            _DataContext = data;
        }
        public void AddCustomer(Data.Customer customer)
        {
            _DataContext.Customers.Add(Mapper.DatabaseCustomerToServiceCustomer(customer));
        }

        Data.Customer ICustomerRepository.GetCustomerById(int id)
        {
            var customer = _DataContext.Customers.FirstOrDefault(c => c.Id.Equals(id));
            return Mapper.ServiceCustomerToDatabaseCustomer(customer);
        }

        List<Data.Customer> ICustomerRepository.GetAllCustomers()
        {
            List<Data.Customer> customers = new List<Data.Customer>();
            foreach (var customer in _DataContext.Customers)
            {
                customers.Add(Mapper.ServiceCustomerToDatabaseCustomer(customer));
            }
            return customers;
        }

        Data.Customer ICustomerRepository.GetLastCustomer()
        {
            var customer = _DataContext.Customers.LastOrDefault();
            return Mapper.ServiceCustomerToDatabaseCustomer(customer);
        }

        public void UpdateCustomer(Data.Customer customer)
        {
            Customer customerUpdate = _DataContext.Customers.FirstOrDefault(c => c.Id.Equals(customer.id));

                if (customerUpdate != null)
                {
                    customerUpdate.FirstName = customer.first_name;
                    customerUpdate.LastName = customer.last_name;
                }
        }

        public void DeleteCustomer(int id)
        {
            Customer customerDelete = _DataContext.Customers.FirstOrDefault(customer => customer.Id.Equals(id));

            if (customerDelete != null)
            {
                _DataContext.Customers.Remove(customerDelete);
            }
        }
    }
}
