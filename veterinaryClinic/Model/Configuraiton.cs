namespace veterinaryClinic.Model;

public class Configuraiton
{
    private string? connectionName;
    private string? connectionPassword;
    private string? userName;
    private string? userPassword;
    
    public string? ConnectionName
    {
        get => connectionName;
        set => connectionName = value;
    }

    public string? ConnectionPassword
    {
        get => connectionPassword;
        set => connectionPassword = value;
    }

    public string? UserName
    {
        get => userName;
        set => userName = value;
    }

    public string? UserPassword
    {
        get => userPassword;
        set => userPassword = value;
    }

    public Configuraiton()
    {
    }

    public Configuraiton(String connectionName, String connectionPassword)
    {
        ConnectionName = connectionName;
        ConnectionPassword = connectionPassword;
    }

    public Configuraiton(string connectionName, string connectionPassword, string userName, string userPassword)
    {
        ConnectionName = connectionName;
        ConnectionPassword = connectionPassword;
        UserName = userName;
        UserPassword = userPassword;
    }

    public bool CheckConnection()
    {
        if (ConnectionName == null || ConnectionPassword == null)
            return false;
        return true;
    }

    public bool CheckUser()
    {
        if (UserName == null || UserPassword == null)
            return false;
        return true;
    }
}