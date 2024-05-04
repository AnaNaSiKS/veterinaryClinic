namespace veterinaryClinic;

public class OpenConnectionDataBase
{
    private static PostgresContext _INSTANCE;
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
                    _INSTANCE = new PostgresContext();
            }
            
        }
        return _INSTANCE;
    }
}