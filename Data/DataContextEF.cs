using Microsoft.EntityFrameworkCore;
using EF.Models;

namespace testAPI.Data
{
    public class DatacontextEF : DbContext
    {
        private readonly IConfiguration _config;

        public DatacontextEF(IConfiguration config)
        {
            _config = config;
        } 

        public virtual DbSet<Customer> Customer {get; set;}
        public virtual DbSet<Product> Product {get; set;}
        public virtual DbSet<Orders> Orders {get; set;}


     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                        optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("basic");
            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasKey(u => u.ID);
            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasKey(u => u.ID);
            modelBuilder.Entity<Orders>()
                .ToTable("Orders")
                .HasKey(u => u.ID);


           
        }


    }

}