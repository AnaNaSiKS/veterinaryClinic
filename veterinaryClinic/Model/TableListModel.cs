using System.Data;
using System.Windows.Documents;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using veterinaryClinic.DataBaseClasses;

namespace veterinaryClinic.Model;

public class TableListModel
{
    private List<object> _tableList;
    private object _nameTable;

    public object NameTable
    {
        get { return _nameTable; }
        set { _nameTable = value; }
    }

    public List<object> TableList
    {
        get { return _tableList; }
        set { _tableList = value; }
    }

    public TableListModel(object nameTable)
    {
        #region MyRegion
        switch (nameTable)
        {
            case Animal: 
                _tableList = new List<object>(ExecuteCommandToDataBase.GetAnimals());
                _nameTable = new Animal(); 
                break;
            case Analysisresult: 
                _tableList = new List<object>(ExecuteCommandToDataBase.GetAnalysisresults());
                _nameTable = new Analysisresult();
                break;
            case Animalsinfo:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetAnimalsInfos());
                _nameTable = new Animalsinfo();
                break;
            case Appointment:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetAppointments());
                _nameTable = new Appointment();
                break;
            case Datetimeofreception:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetDatetimeOfReceptions());
                _nameTable = new Datetimeofreception();
                break;
            case Diagnosis:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetDiagnosis());
                _nameTable = new Diagnosis();
                break;
            case Employee: 
                _tableList = new List<object>(ExecuteCommandToDataBase.GetEmployees());
                _nameTable = new Employee();
                break;
            case Equipmentclass:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetEquipmentclasses());
                _nameTable = new Equipmentclass();
                break;
            case Equipmentclinic:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetEquipmentclinics());
                _nameTable = new Equipmentclinic();
                break;
            case Medicalitem:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetMedicalitems());
                _nameTable = new Medicalitem();
                break;
            case Medicine:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetMedicines());
                _nameTable = new Medicine();
                break;
            case Ownerofanimal:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetOwnerOfAnimal());
                _nameTable = new Ownerofanimal();
                break;
            case Position:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetPostions());
                _nameTable = new Position();
                break;
            case Service:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetService());
                _nameTable = new Service();
                break;
            case Serviceclass:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetServiceClass());
                _nameTable = new Serviceclass();
                break;
            case Typeofanimal:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetTypeofanimals());
                _nameTable = new Typeofanimal();
                break;
            case Useofclinicequipment:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetUseofclinicequipments());
                _nameTable = new Useofclinicequipment();
                break;
            case Useofmedicalitem:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetUseMedicalItem());
                _nameTable = new Useofmedicalitem();
                break;
            case Useofmedicine:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetUseofmedicines());
                _nameTable = new Useofmedicine();
                break;
            case User:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetUser());
                _nameTable = new User();
                break;
            case Userlog:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetUserLog());
                _nameTable = new Userlog();
                break;
            case Vaccination:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetVaccanation());
                _nameTable = new Vaccination();
                break;
            case Vaccinationsdelivered:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetVaccanationDelivered());
                _nameTable = new Vaccinationsdelivered();
                break;
            case Veterinaryclinic:
                _tableList = new List<object>(ExecuteCommandToDataBase.GetVeterinaryClinic());
                _nameTable = new Veterinaryclinic();
                break;
            default: throw new ArgumentException("Неверный тип таблицы"); 
        }
        #endregion
    }
    
    public void SaveDbChanges()
    {
        OpenConnectionDataBase.GetInstance().SaveChanges();
    }
}