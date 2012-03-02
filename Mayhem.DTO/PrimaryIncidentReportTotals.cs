using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class PrimaryIncidentReportTotals
    {
        #region Properties

        public Dispatcher Dispatcher { get; set; }
        public decimal ToneAlertUsed { get; set; }
        public decimal Priority { get; set; }
        public decimal Sunstar3DigitUnit { get; set; }
        public decimal Location { get; set; }
        public decimal MapGrid { get; set; }
        public decimal NatureOfCall { get; set; }
        public decimal SsTacChannel { get; set; }
        public decimal PertinentIntRouting { get; set; }
        public decimal InfoGivenOutOfOrder { get; set; }
        public decimal DisplayedServiceAttitude { get; set; }
        public decimal UsedCorrectVolumeTone { get; set; }
        public decimal UsedProhibitedBehavior { get; set; }
        public int CallCount { get; set; }
        public decimal TotalScore { get; set; }
       
        #endregion
    }
}
