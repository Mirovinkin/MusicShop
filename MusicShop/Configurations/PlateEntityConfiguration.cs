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
    internal class PlateEntityConfiguration : IEntityTypeConfiguration<PlateEntity>
    {
        public void Configure(EntityTypeBuilder<PlateEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("plates_pkey");

            builder.ToTable("plates");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.PlateName)
                .HasMaxLength(100)
                .HasColumnName("plate_name");
            builder.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            builder.Property(e => e.TrackNumber).HasColumnName("track_number");
        }
    }
}
