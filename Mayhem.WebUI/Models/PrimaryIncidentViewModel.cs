using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mayhem.WebUI.Models
{
    public class PrimaryIncidentViewModel : IncidentViewModel
    {
        public bool ToneAlertUsed { get; set; }
        public bool Priority { get; set; }
        public bool SSTacChannel { get; set; }
        public bool PertinentIntRouting { get; set; }
        public bool InfoGivenOutOfOrder { get; set; }
    }
}