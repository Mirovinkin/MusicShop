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
    internal class RegistereduserEntityConfiguration : IEntityTypeConfiguration<RegistereduserEntity>
    {
        public void Configure(EntityTypeBuilder<RegistereduserEntity> builder)
        {
            builder.HasKey(e => e.UserId).HasName("registeredusers_pkey");

            builder.ToTable("registeredusers");

            builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        }
    }
}
