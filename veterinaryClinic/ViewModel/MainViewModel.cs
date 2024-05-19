using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using veterinaryClinic.ApplicationPages;
using veterinaryClinic.ApplicationWindows;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class MainViewModel: ViewModelBase
{
    private SampleItem _selectedItem;
    private Page _currentPage;
    
    public Page CurrentPage
    {
        get => _currentPage;
        set
        {
            if (_currentPage != value)
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
    
    public SampleItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            try
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    if (_selectedItem.Title == "Таблицы")
                    {
                        CurrentPage = new TablesPage();
                    }
                    else if (_selectedItem.Title == "Запись на приём")
                    {
                        CurrentPage = new CheckAppointmentPage();
                    }
                    else if (_selectedItem.Title == "Создать пользователя")
                    {
                        CurrentPage = new CreateUserPage();
                    }
                    else if (_selectedItem.Title == "Изменить пользователя")
                    {
                        veterinaryClinic.Model.Configuraiton conf = ConfigurationHelper.ReadFromJson();
                        conf.IsSaveUser = false;
                        ConfigurationHelper.WriteToJson(conf);
                        
                        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                        authorizationWindow.Show();
            
                        Application.Current.Windows[0].Close();
                    }
                    else if (_selectedItem.Title == "Изменить подключение к БД")
                    {
                        veterinaryClinic.Model.Configuraiton conf = ConfigurationHelper.ReadFromJson();
                        conf.IsSaveConnection = false;
                        ConfigurationHelper.WriteToJson(conf);
                        
                        ConnectionWindows connectionWindows = new ConnectionWindows();
                        connectionWindows.Show();
            
                        Application.Current.Windows[0].Close();
                    }
                }
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    public ObservableCollection<SampleItem> SampleList { get; }

    private Dictionary<string, ObservableCollection<SampleItem>> _dictOfUserItem =
        new Dictionary<string, ObservableCollection<SampleItem>>
        {
            {
                "doctor", new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
                    new SampleItem { Title = "Изменить пользователя", Notification = "", SelectedIcon = PackIconKind.AccountEdit, UnselectedIcon = PackIconKind.AccountEditOutline},
                    new SampleItem { Title = "Изменить подключение к БД", Notification = "", SelectedIcon = PackIconKind.DatabaseSettings, UnselectedIcon = PackIconKind.DatabaseSettingsOutline},
                }
            },
            {
                "reception", new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
                    new SampleItem { Title = "Запись на приём", Notification = "", SelectedIcon = PackIconKind.BadgeAccountAlert,UnselectedIcon = PackIconKind.BadgeAccountAlertOutline },
                    new SampleItem { Title = "Изменить пользователя", Notification = "", SelectedIcon = PackIconKind.AccountEdit, UnselectedIcon = PackIconKind.AccountEditOutline},
                    new SampleItem { Title = "Изменить подключение к БД", Notification = "", SelectedIcon = PackIconKind.DatabaseSettings, UnselectedIcon = PackIconKind.DatabaseSettingsOutline},
                }
            },
            {
                "storekeeper", new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
                    new SampleItem { Title = "Изменить пользователя", Notification = "", SelectedIcon = PackIconKind.AccountEdit, UnselectedIcon = PackIconKind.AccountEditOutline},
                    new SampleItem { Title = "Изменить подключение к БД", Notification = "", SelectedIcon = PackIconKind.DatabaseSettings, UnselectedIcon = PackIconKind.DatabaseSettingsOutline},
                }
            },
            {
                "administrator", new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
                    new SampleItem { Title = "Запись на приём", Notification = "", SelectedIcon = PackIconKind.BadgeAccountAlert,UnselectedIcon = PackIconKind.BadgeAccountAlertOutline },
                    new SampleItem { Title = "Создать пользователя", Notification = "", SelectedIcon = PackIconKind.AccountPlus,UnselectedIcon = PackIconKind.AccountPlusOutline },
                    new SampleItem { Title = "Изменить пользователя", Notification = "", SelectedIcon = PackIconKind.AccountEdit, UnselectedIcon = PackIconKind.AccountEditOutline},
                    new SampleItem { Title = "Изменить подключение к БД", Notification = "", SelectedIcon = PackIconKind.DatabaseSettings, UnselectedIcon = PackIconKind.DatabaseSettingsOutline},
                }
            },
            {
                "postgres", new ObservableCollection<SampleItem>
                {
                    new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
                    new SampleItem { Title = "Запись на приём", Notification = "", SelectedIcon = PackIconKind.BadgeAccountAlert,UnselectedIcon = PackIconKind.BadgeAccountAlertOutline },
                    new SampleItem { Title = "Создать пользователя", Notification = "", SelectedIcon = PackIconKind.AccountPlus,UnselectedIcon = PackIconKind.AccountPlusOutline },
                    new SampleItem { Title = "Изменить пользователя", Notification = "", SelectedIcon = PackIconKind.AccountEdit, UnselectedIcon = PackIconKind.AccountEditOutline},
                    new SampleItem { Title = "Изменить подключение к БД", Notification = "", SelectedIcon = PackIconKind.DatabaseSettings, UnselectedIcon = PackIconKind.DatabaseSettingsOutline},
                }
            }
        };

    public MainViewModel()
    {
        var conf = ConfigurationHelper.ReadFromJson();
        
        SampleList = _dictOfUserItem[conf.ConnectionName];
    }
}