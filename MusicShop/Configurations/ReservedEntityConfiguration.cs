using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicShop.Entities;

namespace MusicShop.Configurations
{
    internal class ReservedEntityConfiguration : IEntityTypeConfiguration<ReservedEntity>
    {
        public void Configure(EntityTypeBuilder<ReservedEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("reserved_pkey");

            builder.ToTable("reserved");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CollectionsId).HasColumnName("collections_id");
            builder.Property(e => e.CustomersId).HasColumnName("customers_id");
            builder.Property(e => e.PlatesId).HasColumnName("plates_id");
            builder.Property(e => e.PromotionDescription)
                .HasMaxLength(200)
                .HasColumnName("promotion_description");

            builder.HasOne(d => d.Collections).WithMany(p => p.Reserveds)
                .HasForeignKey(d => d.CollectionsId)
                .HasConstraintName("reserved_collections_id_fkey");

            builder.HasOne(d => d.Customers).WithMany(p => p.Reserveds)
                .HasForeignKey(d => d.CustomersId)
                .HasConstraintName("reserved_customers_id_fkey");

            builder.HasOne(d => d.Plates).WithMany(p => p.Reserveds)
                .HasForeignKey(d => d.PlatesId)
                .HasConstraintName("reserved_plates_id_fkey");
        }
    }
}
