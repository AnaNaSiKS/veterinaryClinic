using System;
using System.Collections.Generic;

namespace veterinaryClinic;

public partial class Analysisresult
{
    public int Idanalysisresults { get; set; }

    public int EmployessId { get; set; }

    public int AnimalsId { get; set; }

    public DateTime DateOfResult { get; set; }

    public string ContentOfResult { get; set; } = null!;

    public virtual Animal Animals { get; set; } = null!;

    public virtual Employee Employess { get; set; } = null!;
}
