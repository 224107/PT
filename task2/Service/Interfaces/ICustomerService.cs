using Service.Models;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        bool AddCustomer(string customerFirstName, string customerLastName);
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        bool UpdateCustomer(int customerId, string customerFirstName, string customerLastName);
        bool DeleteCustomer(int id);
    }
}
