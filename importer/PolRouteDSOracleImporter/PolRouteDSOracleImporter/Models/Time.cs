using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public class Time : IQueryGenerator
    {
        public int Id { get; set; }

        public string? Period { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public string? Year { get; set; }

        public string? Weekday { get; set; }

        public string GenerateInsertQuery(OracleCommand command)
        {
            command.Parameters.Add(":ID", this.Id);
            command.Parameters.Add(":PERIOD", this.Period);
            command.Parameters.Add(":DAY", this.Day);
            command.Parameters.Add(":MONTH", this.Month);
            command.Parameters.Add(":YEAR", this.Year);
            command.Parameters.Add(":WEEKDAY", this.Weekday);
            return $"INSERT INTO PolRouteDS_time VALUES (:ID,:PERIOD,:DAY,:MONTH,:YEAR,:WEEKDAY)";
        }
    }
}
