using System.Windows.Input;
using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class TotalCostPerTimeViewModel: ViewModelBase
{
    private TotalCostPerTimeModel _totalCostPerTimeModel;

    public ICommand CalculateCommand { get; private set; }
    
    private void Calculate(object obj)
    {
        _totalCostPerTimeModel.GetTotalCost();
        OnPropertyChanged("TotalCost");
    }

    public decimal TotalCost
    {
        get
        {
            return _totalCostPerTimeModel.TotalCost;
        }
    }
    
    public string Address
    {
        get => _totalCostPerTimeModel.Address;
        set => _totalCostPerTimeModel.Address = value;
    }
    
    public DateTime Start
    {
        get => _totalCostPerTimeModel.Start;
        set => _totalCostPerTimeModel.Start = value;
    }
    
    public DateTime End
    {
        get => _totalCostPerTimeModel.End;
        set => _totalCostPerTimeModel.End = value;
    }
    
    
    public TotalCostPerTimeViewModel()
    {
        _totalCostPerTimeModel = new TotalCostPerTimeModel();
        CalculateCommand = new RelayCommand(Calculate);
    }
}