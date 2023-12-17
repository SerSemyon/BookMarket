using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarket;

public partial class Account
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string? AccName { get; set; }

    public string? AccLastName { get; set; }

    public string? AccMiddleName { get; set; }

    public string? AccGender { get; set; }

    public DateOnly? AccBirthday { get; set; }

    public string? AccEmail { get; set; }

    public string? AccPhoneRegistration { get; set; }

    public string? AccHashPassword { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<LegalEntity> LegalEntities { get; } = new List<LegalEntity>();

    public virtual ICollection<NodeAddressAccount> NodeAddressAccounts { get; } = new List<NodeAddressAccount>();

    public virtual ICollection<NodeNphoneAccount> NodeNphoneAccounts { get; } = new List<NodeNphoneAccount>();

    public virtual ICollection<NodeOrderAccount> NodeOrderAccounts { get; } = new List<NodeOrderAccount>();

    public virtual AccountType Type { get; set; } = null!;
}
