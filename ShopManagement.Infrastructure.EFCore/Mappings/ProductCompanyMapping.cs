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
    public class ProductCompanyMapping : IEntityTypeConfiguration<ProductCompany>
    {
        public void Configure(EntityTypeBuilder<ProductCompany> builder)
        {
            builder.ToTable("ProductCompanies");
            builder.HasKey(x => new { x.ProductId, x.CompanyId });
            builder.HasOne(x =>  x.Company).WithMany(x => x.ProductCompanies).HasForeignKey(x => x.CompanyId);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductCompanies).HasForeignKey(x => x.ProductId);
        }
    }
}
