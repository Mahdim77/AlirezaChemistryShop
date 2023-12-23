using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ImageAlt).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ImageTitle).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(2000).IsRequired(false);
            builder.Property(x => x.CasNumber).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Formula).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(1500).IsRequired();
            builder.Property(x => x.MeasurementUnit).HasMaxLength(150).IsRequired();
            builder.Property(x => x.IsInStock).IsRequired(false);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoryId);
        }
    }
}
