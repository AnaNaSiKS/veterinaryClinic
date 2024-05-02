using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Vaccinationsdelivered
{
    public int Animalsid { get; set; }

    public int Vaccanationsid { get; set; }

    public DateTime Datetimeofvaccanations { get; set; }

    public virtual Animal Animals { get; set; } = null!;

    public virtual Vaccination Vaccanations { get; set; } = null!;
}
