using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NodeNphoneAccount
{
    public int NodeNphoneAccountId { get; set; }

    public int? NphoneId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual NumberPhone? Nphone { get; set; }
}
