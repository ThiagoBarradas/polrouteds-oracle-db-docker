using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public interface IQueryGenerator
    {
        string GenerateInsertQuery(OracleCommand command);
    }
}
