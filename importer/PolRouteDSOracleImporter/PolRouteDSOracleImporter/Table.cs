using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter
{
    public interface ITable
    {
        Type Type { get; }
        string Name { get; }
        string Filename { get; }
        string TableName { get; }
    }

    public class Table<T> : ITable
    {
        public Type Type => typeof(T);
        public string Name => typeof(T).Name;
        public string Filename => typeof(T).Name.ToLower() + ".csv";
        public string TableName => "PolRouteDS_" + typeof(T).Name.ToLower();
    }
}
