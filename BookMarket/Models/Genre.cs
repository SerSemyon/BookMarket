using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<NodeGenreBook> NodeGenreBooks { get; } = new List<NodeGenreBook>();
}
