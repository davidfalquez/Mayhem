using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mayhem.WebUI.Models
{
    public class IncidentViewModel
    {
        public string CaseNumber { get; set; }
        public Guid IncidentId { get; set; }
        public string EvaluatorId { get; set; }
        public SelectList EvaluatorDropDown { get; set; }
        public int ChannelId { get; set; }
        public SelectList ChannelDropDown { get; set; }
        public string DispatcherId { get; set; }
        public SelectList DispatcherDropDown { get; set; }
        public int ShiftId { get; set; }
        public SelectList ShiftDropDown { get; set; }
        public DateTime IncidentDate { get; set; }
        public bool Sunstar3DigitUnit { get; set; }
        public bool NatureOfCall { get; set; }
        public bool Location { get; set; }
        public bool MapGrid { get; set; }
        public string DisplayedServiceAttitude { get; set; }
        public SelectList DisplayedServiceAttitudeDropDown { get; set; }
        public string UsedCorrectVolumeTone { get; set; }
        public SelectList UsedCorrectVolumeToneDropDown { get; set; }
        public bool UsedProhibitedBehavior { get; set; }
    }
}