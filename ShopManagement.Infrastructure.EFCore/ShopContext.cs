using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EFCore.Mappings;

namespace ShopManagement.Infrastructure.EFCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public ShopContext(DbContextOptions<ShopContext> option): base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
