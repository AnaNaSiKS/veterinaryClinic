using System.Windows;
using veterinaryClinic.ApplicationWindows;

namespace veterinaryClinic.Model;

public class AuthorizationModel
{
    private Configuraiton _configuraiton = ConfigurationHelper.ReadFromJson();

    public bool IsSaveMe
    {
        get { return _configuraiton.IsSaveUser; }
        set => _configuraiton.IsSaveUser = value;
    }

    public void GetUser(string? userName, string? userPassword)
    {
        try
        {


            if (userName == null || userPassword == null)
            {
                return;
            }

            if (ExecuteCommandToDataBase.CheckUser(userName, userPassword))
            {
                MessageBox.Show("Авторизация прошла успешно", "Авторизация");
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            WriteNewConfig(userName, userPassword);

            NavigationController.GoToMainWindow();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    
    public void WriteNewConfig(string? userName, string? userPassword)
    {
        _configuraiton.UserName = userName;
        _configuraiton.UserPassword = userPassword;
        
        ConfigurationHelper.WriteToJson(_configuraiton);
    }

    public AuthorizationModel()
    {
        if (_configuraiton.CheckUser() && _configuraiton.IsSaveUser)
        {
            NavigationController.GoToMainWindow();
            
        }
    }
    
    
}