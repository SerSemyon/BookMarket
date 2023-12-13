using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Book
{
    public int Id { get; set; }

    public int? LegalEntityId { get; set; }

    public string BookName { get; set; } = null!;

    public int? PhouseId { get; set; }

    public int BookAmount { get; set; }

    public decimal BookPrice { get; set; }

    public decimal? BookRating { get; set; }

    public string? BookDescription { get; set; }

    public string? BookImagePath { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual LegalEntity? LegalEntity { get; set; }

    public virtual ICollection<NodeAuthorBook> NodeAuthorBooks { get; } = new List<NodeAuthorBook>();

    public virtual ICollection<NodeGenreBook> NodeGenreBooks { get; } = new List<NodeGenreBook>();

    public virtual ICollection<NodeOrderBook> NodeOrderBooks { get; } = new List<NodeOrderBook>();

    public virtual PublishingHouse? Phouse { get; set; }
}
