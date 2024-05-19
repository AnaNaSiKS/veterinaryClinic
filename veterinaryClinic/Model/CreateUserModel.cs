using veterinaryClinic.ValidationRules;

namespace veterinaryClinic.Model;

public class CreateUserModel
{
    private string? _login;
    private string? _password;
    private string? _employee;

    public string? Login
    {
        get => _login;
        set => _login = value;
    }

    public string? Password
    {
        get => _password;
        set => _password = value;
    }

    public string? Employee
    {
        get => _employee;
        set => _employee = value;
    }

    public void CreateUser()
    {
        if (_employee != null && _login != null && _password != null)
        {
            try
            {
                if (MinLenghtValidationRule.Validate(_password, 8) && MinLenghtValidationRule.Validate(_login, 4))
                                ExecuteCommandToDataBase.AddUser(_login, _password, int.Parse(_employee));
            }
            catch (FormatException)
            {
                throw new ArgumentException("Код сотрудника должен быть числом.");
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ошибка при создании пользователя.");
            }
            
        }
    }

    public CreateUserModel()
    {

    }
}