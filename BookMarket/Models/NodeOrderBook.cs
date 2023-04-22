using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NodeOrderBook
{
    public int NodeOrderBookId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public int Amount { get; set; }

    public virtual Book? Book { get; set; }
}
