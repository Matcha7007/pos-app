using System.Threading.Tasks;

namespace PosAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IUserRepository UserRepository { get; }
        IDevisionRepository DevisionRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IDenomRepository DenomRepository { get; }
        Task<bool> SaveAsync();
    }
}