using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Veterinaryclinic
{
    public int Idveterinaryclinic { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Equipmentclinic> Equipmentclinics { get; set; } = new List<Equipmentclinic>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
