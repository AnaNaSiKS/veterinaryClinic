using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class TeblesPageVM: ViewModelBase
{
    private TableList _tableModel;

    public List<dynamic> DisplayTable
    {
        get
        {
            return _tableModel.animalsList;
        }
        set
        {
            _tableModel.animalsList = value; OnPropertyChanged();
        }
    }

    public TeblesPageVM()
    {
        _tableModel = new TableList(new Animal());
    }
}