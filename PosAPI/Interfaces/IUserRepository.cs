using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Authenticate(string userName, string password);
         void Signup(string userName, string password, int userRole);
         Task<bool> UserAlreadyExists(string username);
    }
}