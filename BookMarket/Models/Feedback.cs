using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int BookId { get; set; }

    public int AccountId { get; set; }

    public bool? FbIsAnonim { get; set; }

    public string? FbDescription { get; set; }

    public decimal? FbRating { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
