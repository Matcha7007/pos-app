using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Interfaces
{    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        void Register(string username, string password, int userrole);
        Task<bool> UserAlreadyExists(string userName);
    }
}