using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text.Json;

namespace veterinaryClinic.Model;

public class ConfigurationHelper
{
    private static readonly String _filePath = "configuration.Json";
    public static Configuraiton ReadFromJson()
    {
        if (CheckFileExists(_filePath))
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                Configuraiton? conf = JsonSerializer.Deserialize<Configuraiton>(fs);
                if (conf == null)
                    throw new ArgumentException($"в файле {_filePath} не оказалось необходимого значения");
                return conf;
            }
            
        }
        throw new ArgumentException($"Файл {_filePath} не удалось найти.");
    }

    public static void WriteToJson(Configuraiton conf)
    {
        using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<Configuraiton>(fs, conf);
        }
    }

    public static bool CheckFileExists(String filePath)
    {
        return File.Exists(filePath);
    }
}