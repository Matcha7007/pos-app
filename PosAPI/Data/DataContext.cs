using Microsoft.EntityFrameworkCore;
using PosAPI.Models;
// >> step 3
// Install package Microsoft.EntityFrameworkCore

namespace PosAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Customer> Customers { get; set; }
    }
}