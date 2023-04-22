using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class PublishingHouse
{
    public int PhouseId { get; set; }

    public string PhName { get; set; } = null!;

    public string? PhDescription { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
