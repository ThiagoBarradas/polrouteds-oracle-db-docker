using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public class Segment : IQueryGenerator
    {
        public int Id { get; set; }

        public string? Geometry { get; set; }

        public string? Oneway { get; set; }

        public double? Length { get; set; }

        public int? FinalVerticeId { get; set; }

        public int? StartVerticeId { get; set; }

        public string GenerateInsertQuery(OracleCommand command)
        {
            command.Parameters.Add(":ID", this.Id);
            command.Parameters.Add(":GEOMETRY", this.Geometry);
            command.Parameters.Add(":ONEWAY", this.Oneway);
            command.Parameters.Add(":LENGTH", this.Length);
            command.Parameters.Add(":FINALVERTICEID", this.FinalVerticeId);
            command.Parameters.Add(":STARTVERTICEID", this.StartVerticeId);
            return $"INSERT INTO PolRouteDS_segment VALUES (:ID,:GEOMETRY,:ONEWAY,:LENGTH,:FINALVERTICEID,:STARTVERTICEID)";
        }
    }
}
