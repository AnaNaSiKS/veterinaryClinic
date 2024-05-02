using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Equipmentclinic
{
    public int Idequipmentclinic { get; set; }

    public string Name { get; set; } = null!;

    public int VeterinaryClinicId { get; set; }

    public int? EquipmentClassId { get; set; }

    public virtual Equipmentclass? EquipmentClass { get; set; }

    public virtual ICollection<Useofclinicequipment> Useofclinicequipments { get; set; } = new List<Useofclinicequipment>();

    public virtual Veterinaryclinic VeterinaryClinic { get; set; } = null!;
}
