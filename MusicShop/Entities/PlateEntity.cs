using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class PlateEntity
{
    public int Id { get; set; }

    public string PlateName { get; set; } = null!;

    public decimal Price { get; set; }

    public int TrackNumber { get; set; }

    public virtual ICollection<CollectionEntity> Collections { get; } = new List<CollectionEntity>();

    public virtual ICollection<PromotionEntity> Promotions { get; } = new List<PromotionEntity>();

    public virtual ICollection<ReservedEntity> Reserveds { get; } = new List<ReservedEntity>();

    public virtual ICollection<SaleEntity> Sales { get; } = new List<SaleEntity>();
}
