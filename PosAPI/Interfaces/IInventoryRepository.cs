using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface IInventoryRepository
    {
         Task<IEnumerable<Inventory>> GetInventoriesAsync();
         void AddInventory(Inventory inventory);
         void DeleteInventory(int InventoryId);
         Task<Inventory> FindInventory(int id);
    }
}