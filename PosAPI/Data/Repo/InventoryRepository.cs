using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext dc;
        public InventoryRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddInventory(Inventory inventory)
        {
            dc.Inventories.Add(inventory);
        }

        public void DeleteInventory(int InventoryId)
        {
            var inventory = dc.Inventories.Find(InventoryId);
            dc.Inventories.Remove(inventory);
        }

        public async Task<Inventory> FindInventory(int id)
        {
            return await dc.Inventories.FindAsync(id);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await dc.Inventories.ToListAsync();
        }
    }
}