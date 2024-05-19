using System.Windows;
using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class ServiceClinicViewModel: ViewModelBase
{
    private ServiceClinicModel _serviceClinicModel;
    private string _ability;
    
    public string Ability
    {
        get => _ability; 
        set => _ability = value;
    }
    
    public string Address
    {
        get => _serviceClinicModel.Address; 
        set => _serviceClinicModel.Address = value;
    }
    
    public ICommand GetServiceCommand { get; private set; }
    
    private void GetService(object obj)
    {
        try
        {
            Ability =  _serviceClinicModel.GetService();
            OnPropertyChanged("Ability");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    
    public ServiceClinicViewModel()
    {
        _serviceClinicModel = new ServiceClinicModel();
        GetServiceCommand = new RelayCommand(GetService);
    }
}