using System.Windows;
using veterinaryClinic.ApplicationWindows;

namespace veterinaryClinic.Model;

public class NavigationController
{
    public static void GoToAuthorizationWindow()
    {
        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        authorizationWindow.Show();
        
        Application.Current.Windows[0].Close();
    }

    public static void GoToConnectionWindow()
    {
        ConnectionWindows connectionWindows = new ConnectionWindows();
        connectionWindows.Show();
        
        Application.Current.Windows[0].Close();
    }

    public static void GoToMainWindow()
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        
        Application.Current.Windows[0].Close();
    }
    
}