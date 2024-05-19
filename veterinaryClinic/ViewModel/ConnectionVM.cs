using System.Windows;
using System.Windows.Input;
using veterinaryClinic.ApplicationWindows;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class ConnectionVM: ViewModelBase
{
    private ConnectionModel _connectionModel = new ConnectionModel();
    private string connectionName;
    private string connectionPassword;

    public bool SaveIO
    {
        get { return _connectionModel.IsSaveMe; }
        set
        {
            _connectionModel.IsSaveMe = value;
            OnPropertyChanged();
        }
    }

    public string ConnectionName
    {
        get => connectionName;
        set => connectionName = value;
    }

    public string ConnectionPassword
    {
        get => connectionPassword;
        set => connectionPassword = value;
    }

    public ICommand GetConnect
    {
        get; 
        set;
    }

    private void Connect(object obj)
    {
        _connectionModel.GetConnection(ConnectionName, ConnectionPassword);
    }

    public ConnectionVM()
    {
        GetConnect = new RelayCommand(Connect);
    }
}