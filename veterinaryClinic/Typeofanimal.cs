using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Typeofanimal
{
    public int Idtypeofanimal { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
