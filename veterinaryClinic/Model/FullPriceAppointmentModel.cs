namespace veterinaryClinic.Model;

public class FullPriceAppointmentModel
{
    private int _id;

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
    public decimal GetFullPrice()
    {
        if (_id == null)
        {
            throw new Exception("Id не введен");
        }
        return ExecuteCommandToDataBase.GetFullPriceOfAppointment(_id);
    }
    
    public FullPriceAppointmentModel()
    {
    }
}