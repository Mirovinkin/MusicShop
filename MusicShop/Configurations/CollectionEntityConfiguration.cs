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
    internal class CollectionEntityConfiguration : IEntityTypeConfiguration<CollectionEntity>
    {
        public void Configure(EntityTypeBuilder<CollectionEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("collections_pkey");

            builder.ToTable("collections");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CollectionName)
                .HasMaxLength(100)
                .HasColumnName("collection_name");
            builder.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            builder.Property(e => e.PlateId).HasColumnName("plate_id");

            builder.HasOne(d => d.Plate).WithMany(p => p.Collections)
                .HasForeignKey(d => d.PlateId)
                .HasConstraintName("collections_plate_id_fkey");
        }
    }
}
