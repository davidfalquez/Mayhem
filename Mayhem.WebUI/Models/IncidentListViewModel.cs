using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mayhem.DTO;

namespace Mayhem.WebUI.Models
{
    public class IncidentListViewModel
    {
        public List<Incident> Incidents { get; set; }
        public bool ContainsPrimaryIncident { get; set; }
        public bool ContainsSecondaryIncident { get; set; }
    }
}