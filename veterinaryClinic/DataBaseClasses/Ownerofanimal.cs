using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Ownerofanimal
{
    public int Idownerofanimals { get; set; }

    public string FirstName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public string TelephoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string? Passportseries { get; set; }

    public string? Passportnumber { get; set; }

    public virtual ICollection<Animal> Idanimals { get; set; } = new List<Animal>();
}
