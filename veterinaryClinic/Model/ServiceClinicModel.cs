namespace veterinaryClinic.Model;

public class ServiceClinicModel
{
    private string _address;

    public string Address
    {
        get => _address;
        set => _address = value;
    }
    
    public string GetService()
    {
        if (_address == null)
        {
            throw new Exception("Address is empty");
        }
        
        var response =  ExecuteCommandToDataBase.GetServiceAbility(_address);
        string resultString = "";
        foreach (var row in response)
        {
            foreach (var item in row)
            {
                resultString += $"Service Name: {item}\n";
            }
        }

        return resultString;
    }

    public ServiceClinicModel()
    {
    }
}