using System.Runtime.CompilerServices;
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

    public static List<Equipmentclinic> GetEquipmentClinic()
    {
        return db.Equipmentclinics.ToList();
    }

    public static List<Ownerofanimal> GetOwnerOfAnimal()
    {
        return db.Ownerofanimals.ToList();
    }

    public static List<Position> GetPostions()
    {
        return db.Positions.ToList();
    }

    public static List<Service> GetService()
    {
        return db.Services.ToList();
    }

    public static List<Serviceclass> GetServiceClass()
    {
        return db.Serviceclasses.ToList();
    }

    public static List<Typeofanimal> GetTypeofanimals()
    {
        return db.Typeofanimals.ToList();
    }

    public static List<Useofmedicalitem> GetUseMedicalItem()
    {
        return db.Useofmedicalitems.ToList();
    }

    public static List<Useofmedicine> GetUseofmedicines()
    {
        return db.Useofmedicines.ToList();
    }

    public static List<User> GetUser()
    {
        return db.Users.ToList();
    }

    public static List<Userlog> GetUserLog()
    {
        return db.Userlogs.ToList();
    }

    public static List<Vaccination> GetVaccanation()
    {
        return db.Vaccinations.ToList();
    }

    public static List<Vaccinationsdelivered> GetVaccanationDelivered()
    {
        return db.Vaccinationsdelivereds.ToList();
    }

    public static List<Veterinaryclinic> GetVeterinaryClinic()
    {
        return db.Veterinaryclinics.ToList();
    }
}