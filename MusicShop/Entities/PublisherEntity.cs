using System;
using System.Collections.Generic;

namespace MusicShop.Entities;

public partial class PublisherEntity
{
    public int Id { get; set; }

    public string PublisherName { get; set; } = null!;

    public int? CollectionId { get; set; }

    public virtual CollectionEntity? Collection { get; set; }
}
