using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class SecondaryIncidentReportTotals
    {
        #region Properties

        public Dispatcher Dispatcher { get; set; }
        public decimal Sunstar3DigitUnit { get; set; }
        public decimal NatureOfCall { get; set; }
        public decimal Location { get; set; }
        public decimal MapGrid { get; set; }
        public decimal FDUnitsAndTacCh { get; set; }
        public decimal ScriptingDocumented { get; set; }
        public decimal SevenMin { get; set; }
        public decimal TwelveMin { get; set; }
        public decimal ETALocationAsked { get; set; }
        public decimal ETADocumented { get; set; }
        public decimal RoutingDocumented { get; set; }
        public decimal PreArrivalGiven { get; set; }
        public decimal EMDDocumented { get; set; }
        public decimal UsedProhibitedBehavior { get; set; }
        public decimal PatchedChannels { get; set; }
        public decimal Phone { get; set; }
        public decimal ProactiveRoutingGiven { get; set; }
        public decimal CorrectRouting { get; set; }
        public decimal DisplayedServiceAttitude { get; set; }
        public decimal UsedCorrectVolumeTone { get; set; }
        public decimal TotalScore { get; set; }
        public int CallCount { get; set; }

        #endregion
    }
}
