using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class User
{
    public int Usersid { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Employeesid { get; set; }

    public virtual Employee Employees { get; set; } = null!;
}
