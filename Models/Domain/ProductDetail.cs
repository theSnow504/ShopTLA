using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class ProductDetail
{
    public int PrdId { get; set; }

    public int ProId { get; set; }

    public int? PrdInventory { get; set; }

    public string? PrdSize { get; set; }

    public string? PrdColor { get; set; }

    public double? PrdPrice { get; set; }

    public DateTime? PrdLastUpdate { get; set; }

    public virtual Product? Pro { get; set; }
}
