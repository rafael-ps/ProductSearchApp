using Microsoft.EntityFrameworkCore;
using ProductSearchApp.Server.Entities;
using System.Reflection.Emit;

namespace ProductSearchApp.Server.Data
{
    public class ProductSearchDbContext : DbContext
    {

        public ProductSearchDbContext(DbContextOptions<ProductSearchDbContext> options) : base(options) { }
        
        public DbSet<ItemProduct> Products { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemProduct>(model =>
            {
                model.HasKey(e => e.Id);
                model.ToTable("ProductSearch");
                model.Property(e => e.Id).HasColumnName("id");
                model.Property(e => e.Name).HasColumnName("Name");
                model.Property(e => e.Cost).HasColumnName("Cost");
                model.Property(e => e.Id).UseIdentityColumn();


            });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
