using veterinaryClinic.Model;

namespace veterinaryClinic.DataBaseClasses;

public class OpenConnectionDataBase
{
    private static PostgresContext? _INSTANCE;
    private static Configuraiton _configuraiton;
    private static string _connectionName;
    private static object _locker = new object();

    public OpenConnectionDataBase()
    {
    }

    public static PostgresContext GetInstance()
    {
        var conf = ConfigurationHelper.ReadFromJson();
        if (_connectionName != conf.ConnectionName)
        {
            _INSTANCE = null;
            _configuraiton = conf;
        }
        if (_INSTANCE == null)
        {
            lock (_locker)
            {
                if (_INSTANCE == null)
                {
                    _connectionName = _configuraiton.ConnectionName;
                    _INSTANCE = new PostgresContext(_configuraiton.ConnectionName, _configuraiton.ConnectionPassword);
                }
            }
            
        }
        return _INSTANCE;
    }
}