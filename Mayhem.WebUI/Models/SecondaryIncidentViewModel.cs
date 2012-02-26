using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mayhem.WebUI.Models
{
    public class SecondaryIncidentViewModel : IncidentViewModel
    {
        public bool FDUnitsAndTacCh { get; set; }
        public bool ScriptingDocumented { get; set; }
        public bool SevenMin { get; set; }
        public bool TwelveMin { get; set; }
        public bool ETALocationAsked { get; set; }
        public bool ETADocumented { get; set; }
        public string ProactiveRoutingGiven { get; set; }
        public SelectList ProactiveRoutingGivenDropDown { get; set; }
        public string CorrectRouting { get; set; }
        public SelectList CorrectRoutingDropDown { get; set; }
        public bool RoutingDocumented { get; set; }
        public bool PreArrivalGiven { get; set; }
        public bool EMDDocumented { get; set; }
        public bool PatchedChannels { get; set; }
        public bool Phone { get; set; }
    }
}