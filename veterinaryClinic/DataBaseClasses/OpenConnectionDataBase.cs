using veterinaryClinic.Model;

namespace veterinaryClinic.DataBaseClasses;

public class OpenConnectionDataBase
{
    private static PostgresContext? _INSTANCE;
    private static readonly Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();
    private static object _locker = new object();

    public OpenConnectionDataBase()
    {
    }

    public static PostgresContext GetInstance()
    {
        if (_INSTANCE == null)
        {
            lock (_locker)
            {
                if (_INSTANCE == null)
                    _INSTANCE = new PostgresContext(_configuraiton.ConnectionName, _configuraiton.ConnectionPassword);
            }
            
        }
        return _INSTANCE;
    }
}