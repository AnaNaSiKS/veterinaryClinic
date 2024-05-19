namespace veterinaryClinic.Model;

public class Configuraiton
{
    private string? connectionName;
    private string? connectionPassword;
    private bool isSaveConnection;
    private string? userName;
    private string? userPassword;
    private bool isSaveUser;

    public bool IsSaveConnection
    {
        get => isSaveConnection;
        set => isSaveConnection = value;
    }

    public bool IsSaveUser
    {
        get => isSaveUser;
        set => isSaveUser = value;
    }

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