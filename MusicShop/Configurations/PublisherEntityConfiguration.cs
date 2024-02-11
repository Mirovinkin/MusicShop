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
    internal class PublisherEntityConfiguration : IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("publisher_pkey");

            builder.ToTable("publisher");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CollectionId).HasColumnName("collection_id");
            builder.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .HasColumnName("publisher_name");

            builder.HasOne(d => d.Collection).WithMany(p => p.Publishers)
                .HasForeignKey(d => d.CollectionId)
                .HasConstraintName("publisher_collection_id_fkey");
        }
    }
}
