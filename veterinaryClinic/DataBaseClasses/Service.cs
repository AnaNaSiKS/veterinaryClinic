using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Service
{
    public int Idservices { get; set; }

    public string Name { get; set; } = null!;

    public string? Descriprion { get; set; }

    public decimal Price { get; set; }

    public int IdServiceClass { get; set; }

    public virtual Serviceclass IdServiceClassNavigation { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Typeofanimal> Types { get; set; } = new List<Typeofanimal>();
}
