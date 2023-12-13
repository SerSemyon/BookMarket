using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NodeOrderAccount
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }
}
