using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Mappings;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProductCompany> ProductCompanies { get; set; }
        public ShopContext(DbContextOptions<ShopContext> option): base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
