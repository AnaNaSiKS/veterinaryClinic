using System.Data;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using veterinaryClinic.DataBaseClasses;

namespace veterinaryClinic.Model;

public class TableList
{
    private List<object> _tableList;
    private object _nameTable;

    public object NameTable
    {
        get { return _nameTable; }
    }

    public List<dynamic> animalsList
    {
        get { return _tableList; }
        set { _tableList = animalsList; }
    }

    public TableList(object nameTable)
    {
        switch (nameTable)
        {
            case Animal: 
                _tableList =  new List<object>(ExecuteCommandToDataBase.GetAnimals());
                _nameTable = new Animal(); 
                break;
            case Analysisresult: 
                _tableList = new List<object>(ExecuteCommandToDataBase.GetAnalysisresults()); 
                break;
            default: throw new ArgumentException("Неверный тип таблицы"); break;
        }
    }
    
    
}