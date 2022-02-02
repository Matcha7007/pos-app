using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
{
    public class DevisionRepository : IDevisionRepository
    {
        private readonly DataContext dc;
        public DevisionRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddDevision(Devision devision)
        {
            dc.Devisions.Add(devision);
        }

        public void DeleteDevision(int DevisionId)
        {
            var devision = dc.Devisions.Find(DevisionId);
            dc.Devisions.Remove(devision);
        }

        public async Task<Devision> FindDevision(int id)
        {
            return await dc.Devisions.FindAsync(id);
        }

        public async Task<IEnumerable<Devision>> GetDevisionsAsync()
        {
            return await dc.Devisions.ToListAsync();
        }
    }
}