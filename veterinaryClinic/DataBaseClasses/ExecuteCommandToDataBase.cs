using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using veterinaryClinic.DataBaseClasses;


namespace veterinaryClinic;

internal class ExecuteCommandToDataBase
{
    private static PostgresContext db = OpenConnectionDataBase.GetInstance();
    public static List<Medicine> GetMedicines()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Medicines.ToList();
    }
    
    public static async Task<List<Medicine>> GetMedicinesAsync()
    {
        db = OpenConnectionDataBase.GetInstance();
        return await db.Medicines.ToListAsync();
    }

    public static List<Medicalitem> GetMedicalitems()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Medicalitems.ToList();
    }

    public static List<Equipmentclinic> GetEquipmentclinics()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Equipmentclinics.ToList();
    }

    public static List<Analysisresult> GetAnalysisresults()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Analysisresults.ToList();
    }

    public static List<Animal> GetAnimals()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Animals.ToList();
    }

    public static List<Animalsinfo> GetAnimalsInfos()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Animalsinfos.ToList();
    }

    public static List<Appointment> GetAppointments()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Appointments.ToList();
    }

    public static List<Datetimeofreception> GetDatetimeOfReceptions()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Datetimeofreceptions.ToList();
    }

    public static List<Diagnosis> GetDiagnosis()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Diagnoses.ToList();
    }

    public static List<Employee> GetEmployees()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Employees.ToList();
    }
    
    public static async Task<List<Employee>> GetEmployeesAsync()
    {
        db = OpenConnectionDataBase.GetInstance();
        return await db.Employees.ToListAsync();
    }

    public static List<Equipmentclass> GetEquipmentclasses()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Equipmentclasses.ToList();
    }

    public static List<Useofclinicequipment> GetUseofclinicequipments()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Useofclinicequipments.ToList();
    }

    public static List<Ownerofanimal> GetOwnerOfAnimal()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Ownerofanimals.ToList();
    }

    public static List<Position> GetPostions()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Positions.ToList();
    }

    public static List<Service> GetService()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Services.ToList();
    }

    public static List<Serviceclass> GetServiceClass()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Serviceclasses.ToList();
    }

    public static List<Typeofanimal> GetTypeofanimals()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Typeofanimals.ToList();
    }

    public static List<Useofmedicalitem> GetUseMedicalItem()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Useofmedicalitems.ToList();
    }

    public static List<Useofmedicine> GetUseofmedicines()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Useofmedicines.ToList();
    }

    public static List<User> GetUser()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Users.ToList();
    }

    public static List<Userlog> GetUserLog()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Userlogs.ToList();
    }

    public static List<Vaccination> GetVaccanation()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Vaccinations.ToList();
    }

    public static List<Vaccinationsdelivered> GetVaccanationDelivered()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Vaccinationsdelivereds.ToList();
    }

    public static List<Veterinaryclinic> GetVeterinaryClinic()
    {
        db = OpenConnectionDataBase.GetInstance();
        return db.Veterinaryclinics.ToList();
    }

    public static int CheckAppointment(DateTime starting, DateTime ending, int empid)
    {
        try
        {
            db = OpenConnectionDataBase.GetInstance();
            var connection = db.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            
            command.CommandText = "SELECT checkappointment(@starting, @ending, @empid)";
            command.Parameters.Add(new NpgsqlParameter("starting", starting));
            command.Parameters.Add(new NpgsqlParameter("ending", ending));
            command.Parameters.Add(new NpgsqlParameter("empid", empid));

            var result = command.ExecuteScalar();
            connection.Close();
            Console.WriteLine(result);
            return (short) result;
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in CheckAppointment {e.Message}");
        }
    }
    
    public static void AddUser(string login, string password, int employee)
    {
        try
        {
            db = OpenConnectionDataBase.GetInstance();
            NpgsqlParameter parameter1 = new NpgsqlParameter("login", login);
            NpgsqlParameter parameter2 = new NpgsqlParameter("password", password);
            NpgsqlParameter parameter3 = new NpgsqlParameter("empl", employee);
            db.Database.ExecuteSqlRaw("call insertuser(@login, @password, @empl)", parameter1, parameter2, parameter3);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in AddUser {e.Message}");
        }
    }
    
    public static bool CheckUser(string login, string password)
    {
        try
        {
            db = OpenConnectionDataBase.GetInstance();
            var connection = db.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();

            command.CommandText = "select checkpasswordofuser(@login, @password)";
            command.Parameters.Add(new NpgsqlParameter("login", login));
            command.Parameters.Add(new NpgsqlParameter("password", password));

            var result = command.ExecuteScalar();

            connection.Close();
            
            if (result is bool)
            {
                return (bool) result;
            }
            return false;
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in checkpasswordofuser {e.Message}");
        }
    }
}