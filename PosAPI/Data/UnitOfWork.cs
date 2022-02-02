using System.Threading.Tasks;
using PosAPI.Data.Repo;
using PosAPI.Interfaces;

namespace PosAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICustomerRepository CustomerRepository =>
            new CustomerRepository(dc);

        public IUserRepository UserRepository =>
            new UserRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}