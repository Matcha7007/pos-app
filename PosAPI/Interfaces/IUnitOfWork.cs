using System.Threading.Tasks;

namespace PosAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IUserRepository UserRepository { get; }
        IDevisionRepository DevisionRepository { get; }
        Task<bool> SaveAsync();
    }
}