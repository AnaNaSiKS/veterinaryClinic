using System.Windows.Controls;
using veterinaryClinic.ViewModel;

namespace veterinaryClinic.ApplicationPages;

public partial class TablesPage : Page
{
    public TablesPage()
    {
        InitializeComponent();
        TablesPageVM avm = new TablesPageVM();
        DataContext = avm;
    }
}