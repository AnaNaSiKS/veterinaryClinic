using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Employee
{
    public int Idemployees { get; set; }

    public string FirstName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly BirthdayDate { get; set; }

    public char Gender { get; set; }

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public string Education { get; set; } = null!;

    public int PositionId { get; set; }

    public virtual ICollection<Analysisresult> Analysisresults { get; set; } = new List<Analysisresult>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Datetimeofreception> Datetimeofreceptions { get; set; } = new List<Datetimeofreception>();

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Useofclinicequipment> Useofclinicequipments { get; set; } = new List<Useofclinicequipment>();

    public virtual ICollection<Useofmedicalitem> Useofmedicalitems { get; set; } = new List<Useofmedicalitem>();

    public virtual ICollection<Useofmedicine> Useofmedicines { get; set; } = new List<Useofmedicine>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Serviceclass> Classservices { get; set; } = new List<Serviceclass>();

    public virtual ICollection<Veterinaryclinic> Veterinaryclinics { get; set; } = new List<Veterinaryclinic>();

    public override string ToString()
    {
        return Name;
    }
}
