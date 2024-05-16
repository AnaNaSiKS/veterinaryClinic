using System.Configuration;
using System.Windows;
using Npgsql;
using veterinaryClinic.DataBaseClasses;
using veterinaryClinic.Model;
using veterinaryClinic.ViewModel;

namespace veterinaryClinic;

public partial class ConnectionWindows : Window
{
    public ConnectionWindows()
    {
        InitializeComponent();
    }
}