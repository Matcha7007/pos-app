using System.Collections.Generic;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        void AddCustomer(Customer customer);
        void DeleteCustomer(int CustId);
        Task<Customer> FindCustomer(int id);
    }
}