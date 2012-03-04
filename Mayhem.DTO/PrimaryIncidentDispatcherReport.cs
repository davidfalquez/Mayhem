using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class PrimaryIncidentDispatcherReport
    {
        #region Properties

        public string ReportName { get; set; }
        public string ScriptInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PrimaryIncidentReportTotals> DispatcherTotals { get; set; }
        public PrimaryIncidentReportTotals DispatcherBottomLineTotals { get; set; }

        #endregion
    }
}
