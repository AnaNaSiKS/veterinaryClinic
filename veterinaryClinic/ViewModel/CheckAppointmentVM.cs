using System.Windows;
using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class CheckAppointmentVM: ViewModelBase
{
    private CheckAppointmentModel _checkAppointmentModel;
    
    public DateTime DateStart
    {
        get => _checkAppointmentModel.DateStart;
        set => _checkAppointmentModel.DateStart = value;
    }
    
    public DateTime DateEnd
    {
        get => _checkAppointmentModel.DateEnd;
        set => _checkAppointmentModel.DateEnd = value;
    }
    
    public int EmplId
    {
        get => _checkAppointmentModel.EmplId;
        set => _checkAppointmentModel.EmplId = value;
    }
    
    public ICommand CheckAppointmentCommand { get; private set; }
    
    private void CheckAppointment(object obj)
    {
        MessageBox.Show(_checkAppointmentModel.CheckAppointment());
    }
    
    public CheckAppointmentVM()
    {
        _checkAppointmentModel = new CheckAppointmentModel();
        CheckAppointmentCommand = new RelayCommand(CheckAppointment);
    }
}