using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Serviceclass
{
    public int Idserviceclass { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
