using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class UserType
{
    public int TypeUser { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
