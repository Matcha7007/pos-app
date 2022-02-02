using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface IDevisionRepository
    {
        Task<IEnumerable<Devision>> GetDevisionsAsync();
        void AddDevision(Devision devision);
        void DeleteDevision(int DevisionId);
        Task<Devision> FindDevision(int id);
    }
}