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
    internal class PromotionEntityConfiguration : IEntityTypeConfiguration<PromotionEntity>
    {
        public void Configure(EntityTypeBuilder<PromotionEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("promotions_pkey");

            builder.ToTable("promotions");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CollectionsId).HasColumnName("collections_id");
            builder.Property(e => e.EndDate).HasColumnName("end_date");
            builder.Property(e => e.PlatesId).HasColumnName("plates_id");
            builder.Property(e => e.PromotionName)
                .HasMaxLength(100)
                .HasColumnName("promotion_name");
            builder.Property(e => e.StartDate).HasColumnName("start_date");

            builder.HasOne(d => d.Collections).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.CollectionsId)
                .HasConstraintName("promotions_collections_id_fkey");

            builder.HasOne(d => d.Plates).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.PlatesId)
                .HasConstraintName("promotions_plates_id_fkey");
        }
    }
}
