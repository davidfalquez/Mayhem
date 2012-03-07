using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class SecondaryIncidentDispatcherReport
    {
        #region Properties

        public string ReportName { get; set; }
        public string ScriptInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SecondaryIncidentReportTotals> EvaluatorTotals { get; set; }
        public SecondaryIncidentReportTotals EvaluatorBottomLineTotals { get; set; }

        #endregion
    }
}
