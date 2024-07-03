using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Nation
{
    public int NatId { get; set; }

    public string NatName { get; set; } = null!;

    public DateTime? NatLastUpdate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
