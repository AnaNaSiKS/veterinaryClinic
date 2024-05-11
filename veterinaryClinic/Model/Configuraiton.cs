namespace veterinaryClinic.Model;

public class Configuraiton
{
    private static String? connectionName;
    private static String? connectionPassword;
    private static String? userName;
    private static String? userPassword;

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
        ConnectionName = null;
        ConnectionPassword = null;
        UserName = null;
        UserPassword = null;
    }

    public Configuraiton(String connectionName, String connectionPassword)
    {
        ConnectionName = connectionName;
        ConnectionPassword = connectionName;
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