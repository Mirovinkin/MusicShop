using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class CustomerEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public decimal? TotalSpendings { get; set; }

    public virtual ICollection<ReservedEntity> Reserveds { get; } = new List<ReservedEntity>();

    public virtual ICollection<SaleEntity> Sales { get; } = new List<SaleEntity>();
}
