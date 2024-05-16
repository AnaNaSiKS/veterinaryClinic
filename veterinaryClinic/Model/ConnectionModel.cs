using System.Windows.Navigation;
using veterinaryClinic.ApplicationWindows;
using veterinaryClinic.DataBaseClasses;
using veterinaryClinic.ViewModel;

namespace veterinaryClinic.Model;

public class ConnectionModel
{
    private Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();
    private bool isSaveMe = false;

    public bool IsSaveMe
    {
        get { return isSaveMe; }
        set => isSaveMe = value;
    }

    public bool GetConnection(string? connName, string? connPassword)
    {
        if (connName == null || connPassword == null)
        {
            return false;
        }
        WriteNewConfig(connName, connPassword);
        return true;
}
    
    public void WriteNewConfig(string? connName, string? connPassword)
    {
        _configuraiton.ConnectionName = connName;
        _configuraiton.ConnectionPassword = connPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }

    public ConnectionModel()
    {
        if (_configuraiton.CheckConnection())
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
        }
    }
}