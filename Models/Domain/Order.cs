using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Order
{
    public int OrdId { get; set; }

    public int? CusId { get; set; }

    public DateTime? OrdDate { get; set; }

    public int? OrdStatus { get; set; }

    public double? OrdTotal { get; set; }

    public DateTime? OrdLastUpdate { get; set; }

    public virtual Customer? Cus { get; set; }

    public virtual StatusOrder? OrdStatusNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
