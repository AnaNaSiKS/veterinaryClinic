using System.Globalization;
using System.Windows.Controls;

namespace veterinaryClinic.ValidationRules;

public class MinLenghtValidationRule: ValidationRule
{
    public int MinLength { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var str = value as string;
        if (str != null && str.Length < MinLength)
        {
            return new ValidationResult(false, $"Поле не может быть меньше {MinLength} символов.");
        }
        return ValidationResult.ValidResult;
    }
    
    public static bool Validate(object value, int minLength)
    {
        var str = value as string;
        if (str != null && str.Length < minLength)
        {
            return false;
        }
        return true;
    }
}