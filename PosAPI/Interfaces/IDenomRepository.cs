using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface IDenomRepository
    {
         Task<IEnumerable<Denom>> GetDenomsAsync();
         void AddDenom(Denom denom);
         void DeleteDenom(int DenomId);
         Task<Denom> FindDenom(int id);
    }
}