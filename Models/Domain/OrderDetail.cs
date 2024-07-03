using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class OrderDetail
{
    public int DetId { get; set; }

    public int? OrdId { get; set; }

    public int? ProId { get; set; }

    public int? DetQuantity { get; set; }

    public double? DetPrice { get; set; }

    public DateTime? DetLastUpdate { get; set; }

    public virtual Order? Ord { get; set; }

    public virtual Product? Pro { get; set; }
}
