using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreMigrationProvider
{
    public class ShopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=ShopApp;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Deneme());
        }
    }

    public class Deneme : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Price);
            builder.HasData(new Product() {Id = 1, Name = "urun1", Price = 2000, });
        }
    }

    public class Product    
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}