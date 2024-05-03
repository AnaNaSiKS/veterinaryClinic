using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Medicine
{
    public int Idmedicines { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Features { get; set; }

    public int Count { get; set; }

    public virtual ICollection<Useofmedicine> Useofmedicines { get; set; } = new List<Useofmedicine>();

    public virtual ICollection<Typeofanimal> Types { get; set; } = new List<Typeofanimal>();
}
