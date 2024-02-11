using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class ReservedEntity
{
    public int Id { get; set; }

    public string PromotionDescription { get; set; } = null!;

    public int? CustomersId { get; set; }

    public int? CollectionsId { get; set; }

    public int? PlatesId { get; set; }

    public virtual CollectionEntity? Collections { get; set; }

    public virtual CustomerEntity? Customers { get; set; }

    public virtual PlateEntity? Plates { get; set; }
}
