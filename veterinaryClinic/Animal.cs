using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Animal
{
    public int Idanimals { get; set; }

    public string NameOfAnimals { get; set; } = null!;

    public int TypeOfAnimals { get; set; }

    public string? Breed { get; set; }

    public char Gender { get; set; }

    public DateOnly BirthdayDate { get; set; }

    public string? Color { get; set; }

    public string? Features { get; set; }

    public string? Photo { get; set; }

    public string? NumberOfElectronicChip { get; set; }

    public virtual ICollection<Analysisresult> Analysisresults { get; set; } = new List<Analysisresult>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Typeofanimal TypeOfAnimalsNavigation { get; set; } = null!;

    public virtual ICollection<Vaccinationsdelivered> Vaccinationsdelivereds { get; set; } = new List<Vaccinationsdelivered>();

    public virtual ICollection<Ownerofanimal> Idanimalsowners { get; set; } = new List<Ownerofanimal>();
}
