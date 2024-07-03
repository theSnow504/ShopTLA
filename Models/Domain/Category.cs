using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Category
{
    public int CatId { get; set; }

    public string CatName { get; set; } = null!;

    public string? CatDescription { get; set; }

    public DateTime? CatLastUpdate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
