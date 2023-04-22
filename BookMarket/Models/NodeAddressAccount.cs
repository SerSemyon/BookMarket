using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NodeAddressAccount
{
    public int NodeAddressAccountId { get; set; }

    public int? AddressId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Address? Address { get; set; }
}
