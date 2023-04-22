using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public int? OstateId { get; set; }

    public string? OrderDescription { get; set; }

    public int? OrderAddressId { get; set; }

    public int? OrderNphoneId { get; set; }

    public DateOnly? OrderCreatedAt { get; set; }

    public virtual OrderState? Ostate { get; set; }
}
