using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class SaleEntity
{
    public int Id { get; set; }

    public int? SalesNumber { get; set; }

    public DateTime SalesDate { get; set; }

    public int? CustomerId { get; set; }

    public int? CollectionsId { get; set; }

    public int? PlateId { get; set; }

    public virtual CollectionEntity? Collections { get; set; }

    public virtual CustomerEntity? Customer { get; set; }

    public virtual PlateEntity? Plate { get; set; }
}
