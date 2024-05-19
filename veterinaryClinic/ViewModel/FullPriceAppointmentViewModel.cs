using System.Windows;
using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class FullPriceAppointmentViewModel: ViewModelBase
{
    private FullPriceAppointmentModel _fullPriceAppointmentModel;
    private decimal _getFullPrice;

    public ICommand CalculateFullPriceCommand { get; private set; }
    
    private void CalculateFullPrice(object obj)
    {
        try
        {
            GetFullPrice = _fullPriceAppointmentModel.GetFullPrice();
            OnPropertyChanged("GetFullPrice");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public int Id
    {
        get => _fullPriceAppointmentModel.Id;
        set
        {
            _fullPriceAppointmentModel.Id = value; 
        }
    }

    public decimal GetFullPrice
    {
        get
        {
            return _getFullPrice;
        }
        
        set
        {
            _getFullPrice = value;
        }
    }
    
    
    public FullPriceAppointmentViewModel()
    {
        _fullPriceAppointmentModel = new FullPriceAppointmentModel();
        CalculateFullPriceCommand = new RelayCommand(CalculateFullPrice);
    }
}