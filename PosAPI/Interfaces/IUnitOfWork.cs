using System.Threading.Tasks;

namespace PosAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        Task<bool> SaveAsync();
    }
}