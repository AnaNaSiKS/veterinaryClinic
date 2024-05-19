using System.Windows;
using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class AuthorizationVM: ViewModelBase
{
    private AuthorizationModel _authorizationModel = new AuthorizationModel();
    private string userName;
    private string userPassword;

    public bool SaveIO
    {
        get { return _authorizationModel.IsSaveMe; }
        set
        {
            _authorizationModel.IsSaveMe = value;
            OnPropertyChanged();
        }
    }

    public string UserName
    {
        get => userName;
        set => userName = value;
    }

    public string UserPassword
    {
        get => userPassword;
        set => userPassword = value;
    }

    public ICommand GetConnect
    {
        get; 
        set;
    }

    private void Connect(object obj)
    {
        _authorizationModel.GetUser(userName, userPassword);
    }

    public AuthorizationVM()
    {
        GetConnect = new RelayCommand(Connect);
    }
}