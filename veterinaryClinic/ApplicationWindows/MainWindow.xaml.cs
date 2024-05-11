using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using veterinaryClinic.ApplicationPages;
using veterinaryClinic.Model;

namespace veterinaryClinic;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ConfigurationHelper.WriteToJson(new Configuraiton("asdad","sad"));
        Configuraiton conf =  ConfigurationHelper.ReadFromJson();
        Console.WriteLine(conf.ConnectionName);
        Frame.Navigate(new Uri("ApplicationPages/TablesPage.xaml", UriKind.Relative));
    }
}