using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Equipmentclass
{
    public int Idequipmentclass { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Equipmentclinic> Equipmentclinics { get; set; } = new List<Equipmentclinic>();
}
