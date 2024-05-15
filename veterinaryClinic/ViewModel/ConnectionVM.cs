using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class ConnectionVM
{
    private ConnectionModel _connectionModel;
    private string connectionName;
    private string connectionPassword;

    public ICommand GetConnect
    {
        get; 
        set;
    }

    private void Connect(object obj)
    {
        _connectionModel.GetConnection(connectionName, connectionPassword);
    }

    public ConnectionVM()
    {
        GetConnect = new RelayCommand(Connect);
    }
}