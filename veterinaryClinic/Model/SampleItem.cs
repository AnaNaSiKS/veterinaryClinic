using MaterialDesignThemes.Wpf;

namespace veterinaryClinic.Model;

public class SampleItem
{
    public string Title { get; set; }
    public string Notification { get; set; }
    public PackIconKind SelectedIcon { get; set; }
    public PackIconKind UnselectedIcon { get; set; }
}