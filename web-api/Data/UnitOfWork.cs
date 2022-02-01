using System.Threading.Tasks;
using web_api.Data.Repo;
using web_api.Interfaces;

namespace web_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IUserRepository UserRepository => 
            new UserRepository(dc);

        public ICustomerRepository CustomerRepository =>
            new CustomerRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}