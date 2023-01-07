using Microsoft.EntityFrameworkCore;
using DDDSample1.Domain.Categories;
using DDDSample1.Domain.Products;
using DDDSample1.Domain.Families;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Users;
using DDDSample1.Infrastructure.Categories;
using DDDSample1.Infrastructure.Products;
using DDDSample1.Infrastructure.Entregas;
using DDDSample1.Infrastructure.Armazens;
using DDDSample1.Infrastructure.Users;

namespace DDDSample1.Infrastructure
{
    public class DDDSample1DbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<Entrega> Entregas { get; set;}

        public DbSet<Armazem> Armazens {get; set;}

        public DbSet<User> Users{get;set;}

        public DDDSample1DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EntregaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArmazemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}