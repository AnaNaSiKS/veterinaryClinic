using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Position
{
    public int Idpositions { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public string? Requirements { get; set; }

    public string Responsibilities { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
