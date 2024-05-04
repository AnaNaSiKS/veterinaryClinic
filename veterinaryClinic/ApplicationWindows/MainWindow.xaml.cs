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

namespace veterinaryClinic;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var animals = OpenConnectionDataBase.GetInstance().Animals.ToList();
        foreach (var VARIABLE in animals)
        {
            Console.WriteLine(VARIABLE.Idanimals);
        }
        Frame.Navigate(new Uri("ApplicationPages/AnimalsPage.xaml", UriKind.Relative));
    }
}