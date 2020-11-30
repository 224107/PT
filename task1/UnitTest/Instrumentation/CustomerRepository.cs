using Data;
using System;
using System.Collections.Generic;

namespace DataUnitTests
{
    public class CustomerRepository : ICustomer
    {
        private readonly DataContext Data;

        public CustomerRepository(DataContext dataContext)
        {
            Data = dataContext;
        }
        public Customer GetCustomerById(int id)
        {
            for (int i = 0; i < Data.Customers.Count; i++)
            {
                if (Data.Customers[i].Id == id)
                    return Data.Customers[i];
            }
            throw new Exception("There's no customer with such id");
        }
        public void AddCustomer(Customer customer)
        {
            Data.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            GetCustomerById(customer.Id).FirstName = customer.FirstName;
            GetCustomerById(customer.Id).LastName = customer.LastName;
        }
        public void DeleteCustomer(int id)
        {
            Data.Customers.Remove(GetCustomerById(id));
        }

        public List<Customer> GetAllCustomers()
        {
            if (Data.Customers.Count == 0)
                throw new Exception("There's no customers");
            else
                return Data.Customers;
        }
    }
}
