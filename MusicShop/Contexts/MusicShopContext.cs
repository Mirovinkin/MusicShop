using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicShop.Configurations;
using MusicShop.Entities;

namespace MusicShop.Contexts;

public partial class MusicShopContext : DbContext
{
    private readonly IConfiguration configuration;

    public MusicShopContext(IConfiguration configuration)
    {
        this.configuration= configuration;
    }

    public MusicShopContext(DbContextOptions<MusicShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectionEntity> Collections { get; set; }

    public virtual DbSet<CustomerEntity> Customers { get; set; }

    public virtual DbSet<PlateEntity> Plates { get; set; }

    public virtual DbSet<PromotionEntity> Promotions { get; set; }

    public virtual DbSet<PublisherEntity> Publishers { get; set; }

    public virtual DbSet<RegistereduserEntity> Registeredusers { get; set; }

    public virtual DbSet<ReservedEntity> Reserveds { get; set; }

    public virtual DbSet<SaleEntity> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(configuration.GetConnectionString("MusicShopConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CollectionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PlateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RegistereduserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReservedEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SaleEntityConfiguration());

        modelBuilder.HasSequence("collections_plate_id_fkey");
        modelBuilder.HasSequence("promotions_collections_id_fkey");
        modelBuilder.HasSequence("promotions_plates_id_fkey");
        modelBuilder.HasSequence("publisher_collection_id_fkey");
        modelBuilder.HasSequence("reserved_plates_id_fkey");
        modelBuilder.HasSequence("reserved_customers_id_fkey");
        modelBuilder.HasSequence("reserved_collections_id_fkey");
        modelBuilder.HasSequence("sales_plate_id_fkey");
        modelBuilder.HasSequence("sales_customer_id_fkey");
        modelBuilder.HasSequence("sales_collections_id_fkey");

    }

    public void AddUser(RegistereduserEntity newUser)
    {
        Registeredusers.Add(newUser);
        SaveChanges();
    }
    public void AddPlate(PlateEntity newPlate)
    {
        Plates.Add(newPlate);
        SaveChanges();
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
