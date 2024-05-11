using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace veterinaryClinic;

internal class ExecuteCommandToDataBase
{
    private static readonly PostgresContext db = OpenConnectionDataBase.GetInstance();
    public static List<Medicine> GetMedicines()
    {
        return db.Medicines.ToList();
    }

    public static List<Medicalitem> GetMedicalitems()
    {
        return db.Medicalitems.ToList();
    }

    public static List<Equipmentclinic> GetEquipmentclinics()
    {
        return db.Equipmentclinics.ToList();
    }

    public static List<Analysisresult> GetAnalysisresults()
    {
        return db.Analysisresults.ToList();
    }

    public static List<Animal> GetAnimals()
    {
        return db.Animals.ToList();
    }

    public static List<Animalsinfo> GetAnimalsInfos()
    {
        return db.Animalsinfos.ToList();
    }

    public static List<Appointment> GetAppointments()
    {
        return db.Appointments.ToList();
    }

    public static List<Datetimeofreception> GetDatetimeOfReceptions()
    {
        return db.Datetimeofreceptions.ToList();
    }

    public static List<Diagnosis> GetDiagnosis()
    {
        return db.Diagnoses.ToList();
    }

    public static List<Employee> GetEmployees()
    {
        return db.Employees.ToList();
    }

    public static List<Equipmentclass> GetEquipmentclasses()
    {
        return db.Equipmentclasses.ToList();
    }
    
    
}