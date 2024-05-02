﻿using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Useofmedicalitem
{
    public int Medicalitemid { get; set; }

    public int Employeesid { get; set; }

    public DateTime Datetimeofuse { get; set; }

    public int Count { get; set; }

    public int? Appointmentid { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Employee Employees { get; set; } = null!;

    public virtual Medicalitem Medicalitem { get; set; } = null!;
}
