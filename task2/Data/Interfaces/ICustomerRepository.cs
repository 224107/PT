using System.Collections.Generic;
namespace Data.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<Customer> GetAllCustomers();
        Customer GetLastCustomer();        
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);        
    }
}
