using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Medicalitem
{
    public int Idmedicalitem { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Count { get; set; }

    public virtual ICollection<Useofmedicalitem> Useofmedicalitems { get; set; } = new List<Useofmedicalitem>();
}
