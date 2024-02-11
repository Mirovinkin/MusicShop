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
    internal class SaleEntityConfiguration : IEntityTypeConfiguration<SaleEntity>
    {
        public void Configure(EntityTypeBuilder<SaleEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("sales_pkey");

            builder.ToTable("sales");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.CollectionsId).HasColumnName("collections_id");
            builder.Property(e => e.CustomerId).HasColumnName("customer_id");
            builder.Property(e => e.PlateId).HasColumnName("plate_id");
            builder.Property(e => e.SalesDate).HasColumnName("sales_date");
            builder.Property(e => e.SalesNumber).HasColumnName("sales_number");

            builder.HasOne(d => d.Collections).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CollectionsId)
                .HasConstraintName("sales_collections_id_fkey");

            builder.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("sales_customer_id_fkey");

            builder.HasOne(d => d.Plate).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PlateId)
                .HasConstraintName("sales_plate_id_fkey");
        }
    }
}
