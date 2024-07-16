using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class StatusOrder
{
    public int SttId { get; set; }

    public string? SttType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
