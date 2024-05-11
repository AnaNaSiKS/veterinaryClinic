using System.Data;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace veterinaryClinic.Model;

public class TableList
{
    private List<dynamic> _tableList;

    public List<dynamic> animalsList
    {
        get { return _tableList; }
        set { _tableList = animalsList; }
    }

    public TableList(object nameTable)
    {
        switch (nameTable)
        {
            case Animal: _tableList =  new List<dynamic>(ExecuteCommandToDataBase.GetAnimals()); break;
            case Analysisresult: _tableList = new List<dynamic>(ExecuteCommandToDataBase.GetAnalysisresults()); break;
            default: throw new ArgumentException("Неверный тип таблицы"); break;
        }
    }
}