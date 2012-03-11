using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mayhem.WebUI.Models;
using Mayhem.DTO;
using System.Web.Mvc;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    internal class IncidentUtility
    {
        internal static IncidentListViewModel GetIncidentListViewModel(ref Incident incident, Controller controller)
        {
            IncidentListViewModel model = new IncidentListViewModel();
            string incidentId = incident.IncidentId;
            incident = Provider.GetIncident(incidentId);

            if (string.IsNullOrEmpty(incident.IncidentId))
            {
                model.ContainsPrimaryIncident = false;
                model.ContainsSecondaryIncident = false;

                incident = new Incident();
                incident.IncidentId = incidentId;


                if (controller.User.Identity.IsAuthenticated)
                {
                    incident.Evaluator = Provider.GetDispatcherByUsername(controller.User.Identity.Name);
                }
                else
                {
                    throw new Exception("Must be logged in.");
                }

                Provider.CreateIncident(incident);

                incident = Provider.GetIncident(incidentId);


            }
            else
            {
                if (null != incident.PrimaryIncident && incident.PrimaryIncident.PrimaryIncidentId != Guid.Empty)
                {
                    model.ContainsPrimaryIncident = true;
                }

                if (null != incident.SecondaryIncident && incident.SecondaryIncident.SecondaryIncidentId != Guid.Empty)
                {
                    model.ContainsSecondaryIncident = true;
                }
            }

            model.Incidents = new List<Incident>();
            model.Incidents.Add(incident);
            return model;
        }
    }
}