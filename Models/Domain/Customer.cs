using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Customer
{
    public int CusId { get; set; }

    public string CusName { get; set; } = null!;

    public DateTime? CusDateOfBirth { get; set; }

    public string? CusAddress { get; set; }

    public string? CusPhone { get; set; }

    public string? CusEmail { get; set; }

    public DateTime? CusLastUpdate { get; set; }

    public virtual UserAccount Cus { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
