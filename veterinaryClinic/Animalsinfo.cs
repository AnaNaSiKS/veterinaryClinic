using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Animalsinfo
{
    public int? Idanimals { get; set; }

    public DateOnly? BirthdayDate { get; set; }

    public string? Breed { get; set; }

    public string? Content { get; set; }

    public string? ContentOfResult { get; set; }

    public string? TelephoneNumber { get; set; }
}
