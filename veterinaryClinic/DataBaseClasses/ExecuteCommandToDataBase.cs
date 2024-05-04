using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace veterinaryClinic;

public class ExecuteCommandToDataBase
{
    public List<Analysisresult> GetAnalysisresults()
    {
        return OpenConnectionDataBase.GetInstance().Analysisresults.ToList();
    }

    public List<Animal> GetAnamsl()
    {
        return OpenConnectionDataBase.GetInstance().Animals.ToList();
    }

    public List<Animalsinfo> GetAnimalsInfos()
    {
        return OpenConnectionDataBase.GetInstance().Animalsinfos.ToList();
    }

    public List<Appointment> GetAppointments()
    {
        return OpenConnectionDataBase.GetInstance().Appointments.ToList();
    }

    public List<Datetimeofreception> GetDatetimeOfReceptions()
    {
        return OpenConnectionDataBase.GetInstance().Datetimeofreceptions.ToList();
    }

    public List<Diagnosis> GetDiagnosis()
    {
        return OpenConnectionDataBase.GetInstance().Diagnoses.ToList();
    }

    public List<Employee> GetEmployees()
    {
        return OpenConnectionDataBase.GetInstance().Employees.ToList();
    }

    public List<Equipmentclass> GetEquipmentclasses()
    {
        return OpenConnectionDataBase.GetInstance().Equipmentclasses.ToList();
    }
    
    
}