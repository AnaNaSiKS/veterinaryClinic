using System.Runtime.InteropServices.JavaScript;

namespace veterinaryClinic.Model;

public class TotalCostPerTimeModel
{
    private string _address;
    private DateTime _start;
    private DateTime _end;
    private decimal _totalCost;
    
    public decimal TotalCost
    {
        get => _totalCost;
        set => _totalCost = value;
    }

    public string Address
    {
        get => _address;
        set => _address = value;
    }

    public DateTime Start
    {
        get => _start;
        set => _start = value;
    }

    public DateTime End
    {
        get => _end;
        set => _end = value;
    }
    
    public void GetTotalCost()
    {
        if (_address == null || _start == null || _end == null)
        {
            throw new Exception("Адрес или время не введен");
        }
        TotalCost = ExecuteCommandToDataBase.TotalCostPerTime(_address, _start, _end);
    }
    
    public TotalCostPerTimeModel()
    {
    }
}