using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolRouteDSOracleImporter.Models
{
    public class Crime : IQueryGenerator
    {
        public int Id { get; set; }
        public int? TotalFeminicide { get; set; }
        public int? TotalHomicide { get; set; }
        public int? TotalFelonyMurder { get; set; }
        public int? TotalBodilyHarm { get; set; }
        public int? TotalTheftCellphone { get; set; }
        public int? TotalArmedRobberyCellphone { get; set; }
        public int? TotalTheftAuto { get; set; }
        public int? TotalArmedRobberyAuto { get; set; }
        public int? SegmentId { get; set; }
        public int? TimeId { get; set; }

        public string GenerateInsertQuery(OracleCommand command)
        {
            command.Parameters.Add(":ID", this.Id);
            command.Parameters.Add(":TOTALFEMINICIDE", this.TotalFeminicide);
            command.Parameters.Add(":TOTALHOMICIDE", this.TotalHomicide);
            command.Parameters.Add(":TOTALFELONYMURDER", this.TotalFelonyMurder);
            command.Parameters.Add(":TOTALBODILYHARM", this.TotalBodilyHarm);
            command.Parameters.Add(":TOTALTHEFTCELLPHONE", this.TotalTheftCellphone);
            command.Parameters.Add(":TOTALARMEDROBBERYCELLPHONE", this.TotalArmedRobberyCellphone);
            command.Parameters.Add(":TOTALTHEFTAUTO", this.TotalTheftAuto);
            command.Parameters.Add(":TOTALARMEDROBBERYAUTO", this.TotalArmedRobberyAuto);
            command.Parameters.Add(":SEGMENTID", this.SegmentId);
            command.Parameters.Add(":TIMEID", this.TimeId);
            return $"INSERT INTO PolRouteDS_crime VALUES (:ID,:TOTALFEMINICIDE,:TOTALHOMICIDE,:TOTALFELONYMURDER,:TOTALBODILYHARM,:TOTALTHEFTCELLPHONE,:TOTALARMEDROBBERYCELLPHONE,:TOTALTHEFTAUTO,:TOTALARMEDROBBERYAUTO,:SEGMENTID,:TIMEID)";
        }
    }
}



