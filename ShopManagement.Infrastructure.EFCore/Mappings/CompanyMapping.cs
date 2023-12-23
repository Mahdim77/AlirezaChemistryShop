using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Origin).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Detail).HasMaxLength(512);
        }
    }
}
