using Autossential.Configuration.Core;
using System.Data;

namespace Autossential.Configuration.Core.Resolvers
{
    public class DataTableSectionResolver : ISectionResolver
    {
        private readonly DataTable _dataTable;
        private readonly string _keyColumn;
        private readonly string _valueColumn;

        public DataTableSectionResolver(DataTable dataTable, string keyColumn, string valueColumn)
        {
            _dataTable = dataTable;
            _keyColumn = keyColumn;
            _valueColumn = valueColumn;
        }
        public void Resolve(ConfigSection config)
        {
            foreach (DataRow row in _dataTable.Rows)
                config[row[_keyColumn].ToString()] = row[_valueColumn];
        }
    }
}
