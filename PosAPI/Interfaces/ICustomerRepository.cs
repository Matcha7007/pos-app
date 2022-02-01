using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<Customer>> GetCustomersAsync();
         void AddCustomer(Customer customer);
         void DeleteCustomer(int CustomerId);
         Task<Customer> FindCustomer(int id);
    }
}