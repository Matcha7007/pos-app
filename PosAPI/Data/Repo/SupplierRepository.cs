using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Data.Repo
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext dc;
        public SupplierRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddSupplier(Supplier supplier)
        {
            dc.Suppliers.Add(supplier);
        }
        public void DeleteSupplier(int SupplierId)
        {
            var supplier = dc.Suppliers.Find(SupplierId);
            dc.Suppliers.Remove(supplier);
        }
        public async Task<Supplier> FindSupplier(int id)
        {
            return await dc.Suppliers.FindAsync(id);
        }
        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await dc.Suppliers.ToListAsync();
        }
    }
}