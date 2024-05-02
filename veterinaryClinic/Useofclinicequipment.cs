using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Useofclinicequipment
{
    public int Employeesid { get; set; }

    public int Equipmentid { get; set; }

    public DateTime Datetimeofuse { get; set; }

    public virtual Employee Employees { get; set; } = null!;

    public virtual Equipmentclinic Equipment { get; set; } = null!;
}
