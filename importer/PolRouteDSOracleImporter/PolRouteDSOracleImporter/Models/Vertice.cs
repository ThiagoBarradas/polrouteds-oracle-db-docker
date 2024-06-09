using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public class Vertice : IQueryGenerator
    {
        public int Id { get; set; }

        public string? Label { get; set; }

        public int? DistrictId { get; set; }

        public int? NeighborhoodId { get; set; }

        public int? ZoneId { get; set; }

        public string GenerateInsertQuery(OracleCommand command)
        {
            command.Parameters.Add(":ID", this.Id);
            command.Parameters.Add(":LABEL", this.Label);
            command.Parameters.Add(":DISTRICTID", this.DistrictId);
            command.Parameters.Add(":NEIGHBORHOODID", this.NeighborhoodId);
            command.Parameters.Add(":ZONEID", this.ZoneId);
            return $"INSERT INTO PolRouteDS_vertice VALUES (:ID,:LABEL,:DISTRICTID,:NEIGHBORHOODID,:ZONEID)";
        }
    }
}
