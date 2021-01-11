using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private string ShopDataConnection;
        public CustomerRepository()
        {
            ShopDataConnection = global::Data.Properties.Settings.Default.ShopConnectionString;
        }
        public CustomerRepository(string connection)
        {
            ShopDataConnection = connection;
        }
        public void AddCustomer(Customer customer)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges();
            }
        }
        public Customer GetCustomerById(int id)
        {  
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Customers.FirstOrDefault(customer => customer.id.Equals(id));
            }
        }
        
        public List<Customer> GetAllCustomers()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Customers.Select(customer => customer).ToList();
            }
        }
        public Customer GetLastCustomer()
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                return db.Customers.Select(customer => customer).ToList().LastOrDefault();
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            using (var db = new ShopDataContext(ShopDataConnection))
            {
                Customer customerUpdate = db.Customers.FirstOrDefault(c => c.id.Equals(customer.id));

                if (customerUpdate != null)
                {
                    customerUpdate.first_name = customer.first_name;
                    customerUpdate.last_name = customer.last_name;
                    db.SubmitChanges();
                }
            }
        }
        public void DeleteCustomer(int id)
        {
            using(var db = new ShopDataContext(ShopDataConnection))
            {
                Customer customerDelete = db.Customers.FirstOrDefault(customer => customer.id.Equals(id));

                if (customerDelete != null)
                {
                    db.Customers.DeleteOnSubmit(customerDelete);
                    db.SubmitChanges();
                }
            }
        }        
    }
}
