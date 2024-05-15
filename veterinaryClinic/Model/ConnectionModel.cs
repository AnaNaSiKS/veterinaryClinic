using veterinaryClinic.DataBaseClasses;

namespace veterinaryClinic.Model;

public class ConnectionModel
{
    private Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();
    
    public bool GetConnection(string? connName, string? connPassword)
    {
        if (_configuraiton.CheckConnection())
        {
            return true;
            //TODO Доделать проверку на подключение к БД
        }
        WriteNewConfig(connName, connPassword);
        return false;
}
    
    public void WriteNewConfig(string? connName, string? connPassword)
    {
        _configuraiton.ConnectionName = connName;
        _configuraiton.ConnectionPassword = connPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }

    public ConnectionModel()
    {
        //GetConnection(connName, connPassword);
    }
}