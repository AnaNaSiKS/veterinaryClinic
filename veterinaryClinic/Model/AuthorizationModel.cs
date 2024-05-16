namespace veterinaryClinic.Model;

public class AuthorizationModel
{
    private Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();
    private bool isSaveMe = false;

    public bool IsSaveMe
    {
        get { return isSaveMe; }
        set => isSaveMe = value;
    }

    public bool GetUser(string? userName, string? userPassword)
    {
        if (userName == null || userPassword == null)
        {
            return false;
        }
        WriteNewConfig(userName, userPassword);
        return true;
    }
    
    public void WriteNewConfig(string? userName, string? userPassword)
    {
        _configuraiton.UserName = userName;
        _configuraiton.UserPassword = userPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }

    public AuthorizationModel()
    {
        if (_configuraiton.CheckUser())
        {
            MainWindow authorizationWindow = new MainWindow();
            authorizationWindow.Show();
        }
    }
}