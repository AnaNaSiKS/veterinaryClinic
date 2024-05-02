using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Datetimeofreception
{
    public int Iddatetimeofreception { get; set; }

    public int EmployeesId { get; set; }

    public DateTime DateTimeOfStart { get; set; }

    public DateTime DateTimeOfEnd { get; set; }

    public virtual Employee Employees { get; set; } = null!;
}
