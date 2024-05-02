using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Appointment
{
    public int Idappointment { get; set; }

    public int AnimalsId { get; set; }

    public int? Employeesid { get; set; }

    public DateTime DateTimeOfStart { get; set; }

    public DateTime DateTimeOfEnd { get; set; }

    public string? Notes { get; set; }

    public virtual Animal Animals { get; set; } = null!;

    public virtual Employee? Employees { get; set; }

    public virtual ICollection<Useofmedicalitem> Useofmedicalitems { get; set; } = new List<Useofmedicalitem>();

    public virtual ICollection<Useofmedicine> Useofmedicines { get; set; } = new List<Useofmedicine>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
