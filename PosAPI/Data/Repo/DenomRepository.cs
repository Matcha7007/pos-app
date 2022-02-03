using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
{
    public class DenomRepository : IDenomRepository
    {
        private readonly DataContext dc;
        public DenomRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<Denom>> GetDenomsAsync()
        {
            return await dc.Denoms.ToListAsync();
        }

        public void AddDenom(Denom denom)
        {
            dc.Denoms.Add(denom);
        }

        public void DeleteDenom(int DenomId)
        {
            var denom = dc.Denoms.Find(DenomId);
            dc.Denoms.Remove(denom);
        }

        public async Task<Denom> FindDenom(int id)
        {
            return await dc.Denoms.FindAsync(id);
        }
    }
}