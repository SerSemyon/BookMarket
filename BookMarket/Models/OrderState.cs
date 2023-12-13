using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class OrderState
{
    public int Id { get; set; }

    public string OstateName { get; set; } = null!;

    public string? OstateDescription { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
