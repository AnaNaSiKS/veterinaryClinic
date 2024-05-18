using MaterialDesignThemes.Wpf.Converters;

namespace veterinaryClinic.Model;

public class ComboBoxTablesItem
{
    public string Title { get; set; }
    public object TableName { get; set; }
    
    public override string ToString()
    {
        return Title;
    }
}