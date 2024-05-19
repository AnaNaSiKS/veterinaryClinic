namespace veterinaryClinic.Model;

public class CheckAppointmentModel
{
    private DateTime _dateStart;
    private DateTime _dateEnd;
    private int emplId;

    public DateTime DateStart
    {
        get => _dateStart;
        set => _dateStart = value;
    }

    public DateTime DateEnd
    {
        get => _dateEnd;
        set => _dateEnd = value;
    }

    public int EmplId
    {
        get => emplId;
        set => emplId = value;
    }

    public string CheckAppointment()
    {
        if (_dateStart != null || _dateEnd != null || emplId != null)
        {
            int response = ExecuteCommandToDataBase.CheckAppointment(_dateStart, _dateEnd, emplId);
            if (response == 1)
            {
                return "Запись возможна";
            }
            return "Запись не возможна";
        }
        return "Enter date";
    }

    public CheckAppointmentModel()
    {
    }
}