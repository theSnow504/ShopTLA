using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Product
{
    public int ProId { get; set; }

    public int? CatId { get; set; }

    public string ProName { get; set; } = null!;

    public string? ProDescription { get; set; }

    public int? NatId { get; set; }

    public DateTime? ProLastUpdate { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual Nation? Nat { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
