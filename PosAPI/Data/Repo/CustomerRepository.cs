using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
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
            dc.Customers.Add(customer);
        }
        public void DeleteCustomer(int CustomerId)
        {
            var customer = dc.Customers.Find(CustomerId);
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