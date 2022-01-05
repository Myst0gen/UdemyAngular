using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o.Description).IsRequired();
            builder.Property(o => o.Name).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
            builder.Property(o => o.PictureUrl).IsRequired();
            builder.HasOne(o => o.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
        }
    }
}