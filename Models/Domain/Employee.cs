using System;
using System.Collections.Generic;

namespace ShopTLA.Models.Domain;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public DateTime? EmpDateOfBirth { get; set; }

    public string? EmpAddress { get; set; }

    public string? EmpPhone { get; set; }

    public string? EmpEmail { get; set; }

    public double? EmpSalary { get; set; }

    public DateTime? EmpLastUpdate { get; set; }

    public virtual UserAccount Emp { get; set; } = null!;
}
