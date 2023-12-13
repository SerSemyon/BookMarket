using System;
using System.Collections.Generic;

namespace BookMarket;

public partial class AccountType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
