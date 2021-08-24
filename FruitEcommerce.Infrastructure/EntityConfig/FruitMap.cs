using FruitEcommerce.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FruitEcommerce.Infrastructure.EntityConfig
{
    public class FruitMap : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> builder)
        {
            builder.HasKey(sale => sale.FruitId);
        }
    }
}
