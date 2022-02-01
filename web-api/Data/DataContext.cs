using System;
using web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}