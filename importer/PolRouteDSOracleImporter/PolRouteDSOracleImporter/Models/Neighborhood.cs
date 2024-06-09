using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public class Neighborhood : IQueryGenerator
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Geometry { get; set; }

        public string GenerateInsertQuery(OracleCommand command)
        {
            command.Parameters.Add(":ID", this.Id);
            command.Parameters.Add(":NAME", this.Name);
            command.Parameters.Add(":GEOMETRY", this.Geometry);
            return $"INSERT INTO PolRouteDS_neighborhood VALUES (:ID,:NAME,:GEOMETRY)";
        }
    }
}
