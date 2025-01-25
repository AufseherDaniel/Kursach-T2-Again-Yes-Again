using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Models.Context
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .ToTable("Supliers");

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.Supplier_id)
                .WillCascadeOnDelete(true);
        }
    }
}
