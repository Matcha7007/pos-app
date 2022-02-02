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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Devision> Devisions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}