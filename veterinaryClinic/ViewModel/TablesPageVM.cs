using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using veterinaryClinic.DataBaseClasses;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class TablesPageVM : ViewModelBase
{
    private TableListModel _tableModel;
    private ComboBoxTablesItem _selectedTable;
    private object _selectedRow;
    
    public ICommand DeleteCommand { get; private set; }
    public ICommand BackCommand { get; private set; }

    private void DeleteRow(object obj)
    {
        if (_selectedRow != null)
        {
            _tableModel.DeleteRow(_selectedRow);
            OnPropertyChanged("DisplayTable");
        }
    }
    
    private void Back(object obj)
    {
        try
        {
            _tableModel.RejectChanges();
            _tableModel = new TableListModel(_selectedTable.TableName);
            OnPropertyChanged("DisplayTable");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    
    
    public object SelectedRow
    {
        get => _selectedRow;
        set
        {
            _selectedRow = value;
        }
    }
    
    public ICommand SaveChangesCommand { get; }

    private void saveChangesCommand(object obj)
    {
        try
        {
            _tableModel.SaveDbChanges();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        
    }

    public ObservableCollection<ComboBoxTablesItem> ComboBoxTables { get; }
    
    public ComboBoxTablesItem SelectedTable
    {
        get => _selectedTable; 
        set 
        {
            try
            {
                if (_selectedTable != value)
                {
                    _selectedTable = value;
                    _tableModel = new TableListModel(_selectedTable.TableName);
                    OnPropertyChanged("DisplayTable");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    
    public object TableName
    {
        get => _tableModel.NameTable;
        set
        {
            _tableModel.NameTable = value;
        }
    }

    public ObservableCollection<object> DisplayTable
    {
        get
        {
            if (_tableModel == null)
            {
                return new ObservableCollection<object>();
            }
            return _tableModel.TableList;
        }
        set
        {
            _tableModel.TableList = value;

        }
    }

    public TablesPageVM()
    {
        ComboBoxTables = new ObservableCollection<ComboBoxTablesItem>
        {
            new ComboBoxTablesItem { Title = "Животные", TableName = new Animal() },
            new ComboBoxTablesItem { Title = "Результаты анализов", TableName = new Analysisresult() },
            new ComboBoxTablesItem { Title = "Информация о животных", TableName = new Animalsinfo() },
            new ComboBoxTablesItem { Title = "Приемы", TableName = new Appointment() },
            new ComboBoxTablesItem { Title = "Дата приема", TableName = new Datetimeofreception() },
            new ComboBoxTablesItem { Title = "Диагнозы", TableName = new Diagnosis() },
            new ComboBoxTablesItem { Title = "Сотрудники", TableName = new Employee() },
            new ComboBoxTablesItem { Title = "Классы оборудования", TableName = new Equipmentclass() },
            new ComboBoxTablesItem { Title = "Оборудование клиники", TableName = new Equipmentclinic() },
            new ComboBoxTablesItem { Title = "Медицинские предметы", TableName = new Medicalitem()},
            new ComboBoxTablesItem { Title = "Хозяины животных", TableName = new Ownerofanimal()},
            new ComboBoxTablesItem { Title = "Медицинские предметы", TableName = new Medicalitem()},
            new ComboBoxTablesItem { Title = "Услуги", TableName = new Service()},
            new ComboBoxTablesItem { Title = "Виды животных", TableName = new Typeofanimal()},
            new ComboBoxTablesItem { Title = "Виды услуг", TableName = new Serviceclass()},
            new ComboBoxTablesItem { Title = "Должности", TableName = new Position()},
            new ComboBoxTablesItem { Title = "Прививки", TableName = new Vaccination()},
            new ComboBoxTablesItem { Title = "Ветеринрные клиники", TableName = new Veterinaryclinic()},
            new ComboBoxTablesItem { Title = "Поставленные прививки", TableName = new Vaccinationsdelivered()},
            new ComboBoxTablesItem { Title = "Пользователи", TableName = new User()},
            new ComboBoxTablesItem { Title = "View пользователей", TableName = new Userlog()},
            new ComboBoxTablesItem { Title = "Использованное оборудование", TableName = new Useofclinicequipment()},
            new ComboBoxTablesItem { Title = "Использованный медрасход", TableName = new Useofmedicalitem()},
            new ComboBoxTablesItem { Title = "Использованные лекарства", TableName = new Useofmedicine()},
            new ComboBoxTablesItem { Title = "Лекарства", TableName = new Medicine()},
            new ComboBoxTablesItem { Title = "Медрасход", TableName = new Medicalitem()},
        };

        SaveChangesCommand = new RelayCommand(saveChangesCommand);
        DeleteCommand = new RelayCommand(DeleteRow);
        BackCommand = new RelayCommand(Back);

        try
        {
            _tableModel = new TableListModel(new Employee());
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
       
    }
}