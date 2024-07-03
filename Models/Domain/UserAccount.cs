using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class UserAccount
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public int? TypeUser { get; set; }

    public bool? Status { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual UserType? TypeUserNavigation { get; set; }
}
