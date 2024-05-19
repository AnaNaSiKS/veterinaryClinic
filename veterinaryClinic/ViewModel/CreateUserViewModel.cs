using System.Windows;
using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class CreateUserViewModel: ViewModelBase
{
    private CreateUserModel _createUserModel;
    
    public string Login
    {
        get => _createUserModel.Login;
        set
        {
            _createUserModel.Login = value;
        }
    }
    
    public string Password
    {
        get => _createUserModel.Password;
        set
        {
            _createUserModel.Password = value;
        }
    }
    
    public string Employee
    {
        get => _createUserModel.Employee;
        set
        {
            _createUserModel.Employee = value;
        }
    }

    public ICommand CreateUserCommand
    {
        get;
        set;
    }
    
    private void CreateUser(object obj)
    {
        try
        {
            _createUserModel.CreateUser();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public CreateUserViewModel()
    {
        _createUserModel = new CreateUserModel();
        CreateUserCommand = new RelayCommand(CreateUser);
    }
}