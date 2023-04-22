using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class LegalEntity
{
    public int LegalEntityId { get; set; }

    public int? AccountId { get; set; }

    public DateOnly? DateRegistration { get; set; }

    public string? Psr { get; set; }

    public string? Tin { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
