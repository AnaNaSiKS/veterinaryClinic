using veterinaryClinic.Model;

namespace veterinaryClinic.ViewModel;

public class TablesPageVM : ViewModelBase
{
    private TableList _tableModel;
    private string tableName;

    public List<dynamic> DisplayTable
    {
        get { return _tableModel.animalsList; }
        set
        {
            _tableModel.animalsList = value;
            OnPropertyChanged();
        }
    }

    public TablesPageVM()
    {
        _tableModel = new TableList(new Animal());
    }
    
    
}