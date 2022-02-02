using System.Collections.Generic;
using System.Threading.Tasks;
using PosAPI.Models;

namespace PosAPI.Interfaces
{
    public interface ISupplierRepository
    {
         Task<IEnumerable<Supplier>> GetSuppliersAsync();
         void AddSupplier(Supplier supplier);
         void DeleteSupplier(int SupplierId);
         Task<Supplier> FindSupplier(int id);
    }
}