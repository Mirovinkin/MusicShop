using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class PromotionEntity
{
    public int Id { get; set; }

    public string PromotionName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? PlatesId { get; set; }

    public int? CollectionsId { get; set; }

    public virtual CollectionEntity? Collections { get; set; }

    public virtual PlateEntity? Plates { get; set; }
}
