using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mayhem.WebUI.Models
{
    public class IncidentCreateViewModel
    {
        IncidentViewModel NewIncident { get; set; }
        IncidentListViewModel ExistingIncidents { get; set; }
    }
}