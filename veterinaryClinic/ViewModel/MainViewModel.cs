using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using veterinaryClinic.ApplicationPages;
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
                        MessageBox.Show($"Результат проверки: {ExecuteCommandToDataBase.CheckAppointment()}");
                    }
                    else if (_selectedItem.Title == "Создать пользователя")
                    {
                        //MessageBox.Show($"Новый пользователь создан: {ExecuteCommandToDataBase.AddUser();}
                    }
                }
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    public ObservableCollection<SampleItem> SampleList { get; }

    public MainViewModel()
    {
        SampleList = new ObservableCollection<SampleItem>
        {
            new SampleItem { Title = "Таблицы", Notification = "", SelectedIcon =  PackIconKind.FileTableBoxMultiple, UnselectedIcon = PackIconKind.FileTableBoxMultipleOutline },
            new SampleItem { Title = "Запись на приём", Notification = "", SelectedIcon = PackIconKind.BadgeAccountAlert,UnselectedIcon = PackIconKind.BadgeAccountAlertOutline },
            new SampleItem { Title = "Создать пользователя", Notification = "", SelectedIcon = PackIconKind.AccountPlus,UnselectedIcon = PackIconKind.AccountPlusOutline },
        };
    }
}