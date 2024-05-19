using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Windows.Documents;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using veterinaryClinic.DataBaseClasses;

namespace veterinaryClinic.Model;

public class TableListModel
{
    private ObservableCollection<object> _tableObservableCollection;
    private ObservableCollection<object> _deleteObservableCollection;
    
    
    public void AddRow(object obj)
    {
        _deleteObservableCollection.Add(obj);
    }

    private object _nameTable;

    public object NameTable
    {
        get { return _nameTable; }
        set { _nameTable = value; }
    }

    public ObservableCollection<object> TableList
    {
        get
        {
            return _tableObservableCollection;
        }
        set
        {
            _tableObservableCollection = value;
        }
    }

    public TableListModel(object nameTable)
    {
        try
        {
            #region MyRegion
            switch (nameTable)
            {
                case Animal: 
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetAnimals());
                    _nameTable = new Animal(); 
                    break;
                case Analysisresult: 
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetAnalysisresults());
                    _nameTable = new Analysisresult();
                    break;
                case Animalsinfo:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetAnimalsInfos());
                    _nameTable = new Animalsinfo();
                    break;
                case Appointment:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetAppointments());
                    _nameTable = new Appointment();
                    break;
                case Datetimeofreception:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetDatetimeOfReceptions());
                    _nameTable = new Datetimeofreception();
                    break;
                case Diagnosis:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetDiagnosis());
                    _nameTable = new Diagnosis();
                    break;
                case Employee: 
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetEmployees());
                    _nameTable = new Employee();
                    break;
                case Equipmentclass:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetEquipmentclasses());
                    _nameTable = new Equipmentclass();
                    break;
                case Equipmentclinic:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetEquipmentclinics());
                    _nameTable = new Equipmentclinic();
                    break;
                case Medicalitem:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetMedicalitems());
                    _nameTable = new Medicalitem();
                    break;
                case Medicine:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetMedicines());
                    _nameTable = new Medicine();
                    break;
                case Ownerofanimal:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetOwnerOfAnimal());
                    _nameTable = new Ownerofanimal();
                    break;
                case Position:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetPostions());
                    _nameTable = new Position();
                    break;
                case Service:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetService());
                    _nameTable = new Service();
                    break;
                case Serviceclass:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetServiceClass());
                    _nameTable = new Serviceclass();
                    break;
                case Typeofanimal:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetTypeofanimals());
                    _nameTable = new Typeofanimal();
                    break;
                case Useofclinicequipment:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetUseofclinicequipments());
                    _nameTable = new Useofclinicequipment();
                    break;
                case Useofmedicalitem:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetUseMedicalItem());
                    _nameTable = new Useofmedicalitem();
                    break;
                case Useofmedicine:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetUseofmedicines());
                    _nameTable = new Useofmedicine();
                    break;
                case User:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetUser());
                    _nameTable = new User();
                    break;
                case Userlog:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetUserLog());
                    _nameTable = new Userlog();
                    break;
                case Vaccination:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetVaccanation());
                    _nameTable = new Vaccination();
                    break;
                case Vaccinationsdelivered:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetVaccanationDelivered());
                    _nameTable = new Vaccinationsdelivered();
                    break;
                case Veterinaryclinic:
                    _tableObservableCollection = new ObservableCollection<object>(ExecuteCommandToDataBase.GetVeterinaryClinic());
                    _nameTable = new Veterinaryclinic();
                    break;
                default: throw new ArgumentException("Неверный тип таблицы"); 
            }
            #endregion

            _deleteObservableCollection = new ObservableCollection<object>();
        }
        catch (Exception e)
        {
            throw new ArgumentException("Нет доступа к таблице");
        }
    }
    
    public void SaveDbChanges()
    {
        try
        {
            foreach (var item in _tableObservableCollection)
            {
                if (OpenConnectionDataBase.GetInstance().Entry(item).State == EntityState.Detached)
                {
                    OpenConnectionDataBase.GetInstance().Entry(item).State = EntityState.Added;
                }
            }
            
            OpenConnectionDataBase.GetInstance().SaveChanges();
            
            foreach (var item in _deleteObservableCollection)
            {
                var entry = OpenConnectionDataBase.GetInstance().Entry(item);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Deleted;
                }
            }
            
            OpenConnectionDataBase.GetInstance().SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new ArgumentException($"Ошибка при сохранении изменений в базе данных. {e.ToString()}");
        }
        catch (DbException e)
        {
            throw new ArgumentException($"Ошибка при сохранении изменений в базе данных. {e.Message}");
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Ошибка! {e.Message}");
        }

    }
    public void RejectChanges()
    {
        foreach (var entry in OpenConnectionDataBase.GetInstance().ChangeTracker.Entries().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }
    }
    
    public void DeleteRow(object obj)
    {
        _tableObservableCollection.Remove(obj);
        AddRow(obj);
    }
}