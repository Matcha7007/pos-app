using System.Threading.Tasks;

namespace web_api.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        Task<bool> SaveAsync();
    }
}