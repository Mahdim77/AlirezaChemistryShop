using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mappings
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
           builder.ToTable("ProductCategories");
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
           builder.Property(x => x.Image).HasMaxLength(500).IsRequired();
           builder.Property(x => x.ImageAlt).HasMaxLength(120).IsRequired();
           builder.Property(x => x.ImageTitle).HasMaxLength(80).IsRequired();
           builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
           builder.Property(x => x.MetaDescription).HasMaxLength(500).IsRequired();
           builder.Property(x => x.Keywords).HasMaxLength(300).IsRequired();
           builder.Property(x => x.Slug).HasMaxLength(150).IsRequired();
           builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.ProductCategoryId);

            
        }
    }
}
