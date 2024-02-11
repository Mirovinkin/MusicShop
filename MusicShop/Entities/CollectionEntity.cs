using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class CollectionEntity
{
    public int Id { get; set; }

    public string? CollectionName { get; set; }

    public string Genre { get; set; } = null!;

    public int? PlateId { get; set; }

    public virtual PlateEntity? Plate { get; set; }

    public virtual ICollection<PromotionEntity> Promotions { get; } = new List<PromotionEntity>();

    public virtual ICollection<PublisherEntity> Publishers { get; } = new List<PublisherEntity>();

    public virtual ICollection<ReservedEntity> Reserveds { get; } = new List<ReservedEntity>();

    public virtual ICollection<SaleEntity> Sales { get; } = new List<SaleEntity>();
}
