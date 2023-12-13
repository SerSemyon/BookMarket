using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Author
{
    public int Id { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? AuthorDescription { get; set; }

    public virtual ICollection<NodeAuthorBook> NodeAuthorBooks { get; } = new List<NodeAuthorBook>();
}
