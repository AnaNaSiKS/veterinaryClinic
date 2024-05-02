using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Diagnosis
{
    public int Iddiagnosis { get; set; }

    public int EmployeesId { get; set; }

    public int AnimalsId { get; set; }

    public string Content { get; set; } = null!;

    public virtual Animal Animals { get; set; } = null!;

    public virtual Employee Employees { get; set; } = null!;
}
