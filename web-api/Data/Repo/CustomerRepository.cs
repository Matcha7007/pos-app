using System.Security.Cryptography;
using System.Threading.Tasks;
using web_api.Interfaces;
using web_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace web_api.Data.Repo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext dc;
        public CustomerRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddCustomer(Customer customer)
        {
            dc.Customers.AddAsync(customer);
        }

        public void DeleteCustomer(int CustId)
        {
            var customer = dc.Customers.Find(CustId);
            dc.Customers.Remove(customer);
        }

        public async Task<Customer> FindCustomer(int id)
        {
            return await dc.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await dc.Customers.ToListAsync();
        }
    }
}