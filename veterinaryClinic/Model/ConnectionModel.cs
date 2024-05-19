using System.Windows;
using System.Windows.Navigation;
using veterinaryClinic.ApplicationWindows;
using veterinaryClinic.DataBaseClasses;
using veterinaryClinic.ViewModel;

namespace veterinaryClinic.Model;

public class ConnectionModel
{
    private Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();

    public bool IsSaveMe
    {
        get { return _configuraiton.IsSaveConnection; }
        set => _configuraiton.IsSaveConnection = value;
    }

    public void GetConnection(string? connName, string? connPassword)
    {
        if (connName == null || connPassword == null)
        {
            return;
        }
        
        WriteNewConfig(connName, connPassword);
        
        if (_configuraiton.CheckUser() && _configuraiton.IsSaveUser)
        {
            NavigationController.GoToMainWindow();
        }
        else
        {
            NavigationController.GoToAuthorizationWindow();
        }
}
    
    public void WriteNewConfig(string? connName, string? connPassword)
    {
        _configuraiton.ConnectionName = connName;
        _configuraiton.ConnectionPassword = connPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }

    public ConnectionModel()
    {
        if (_configuraiton.CheckConnection() && _configuraiton.IsSaveConnection)
        {
            if (_configuraiton.CheckUser() && _configuraiton.IsSaveUser)
            {
                NavigationController.GoToMainWindow();
            }
            else
            {
                NavigationController.GoToAuthorizationWindow();
            }
        }
        
    }
}