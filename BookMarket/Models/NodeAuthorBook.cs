using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class NodeAuthorBook
{
    public int NodeAuthorBookId { get; set; }

    public int? AuthorId { get; set; }

    public int? BookId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? Book { get; set; }
}
