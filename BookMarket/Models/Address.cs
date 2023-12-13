using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Address
{
    public int Id { get; set; }

    public string? AdrCity { get; set; }

    public string? AdrStreet { get; set; }

    public string? AdrHouse { get; set; }

    public int? AdrEntrance { get; set; }

    public int? AdrFloor { get; set; }

    public int? AdrApartment { get; set; }

    public bool? AdrIsDefault { get; set; }

    public virtual ICollection<NodeAddressAccount> NodeAddressAccounts { get; } = new List<NodeAddressAccount>();
}
