using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NumberPhone
{
    public int NphoneId { get; set; }

    public string? NpPhone { get; set; }

    public bool? NpIsDefault { get; set; }

    public virtual ICollection<NodeNphoneAccount> NodeNphoneAccounts { get; } = new List<NodeNphoneAccount>();
}
