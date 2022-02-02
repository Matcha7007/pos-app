using System.Threading.Tasks;

namespace PosAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}