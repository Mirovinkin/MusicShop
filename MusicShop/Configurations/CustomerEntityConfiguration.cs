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
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(e => e.Id).HasName("customers_pkey");

            builder.ToTable("customers");

            builder.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            builder.HasIndex(e => e.PhoneNumber, "customers_phone_number_key").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");
            builder.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            builder.Property(e => e.TotalSpendings)
                .HasColumnType("money")
                .HasColumnName("total_spendings");
        }
    }
}
