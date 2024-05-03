using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Vaccination
{
    public int Idvaccinations { get; set; }

    public string Name { get; set; } = null!;

    public string? Features { get; set; }

    public virtual ICollection<Vaccinationsdelivered> Vaccinationsdelivereds { get; set; } = new List<Vaccinationsdelivered>();
}
