using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<NodeGenreBook> NodeGenreBooks { get; } = new List<NodeGenreBook>();
}
