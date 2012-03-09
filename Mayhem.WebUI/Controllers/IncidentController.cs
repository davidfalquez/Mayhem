using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;
using Mayhem.WebUI.Models;

namespace Mayhem.WebUI.Controllers
{
    public class IncidentController : Controller
    {
        //
        // GET: /Incident/

        [Authorize]
        public ActionResult Index()
        {
            return View(new Incident());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(Incident incident)
        {
            IncidentListViewModel model = GetIncidentListViewModel(ref incident);

            return View("Create", model);
        }

        [Authorize]
        public ActionResult List(Incident incident)
        {
            IncidentListViewModel model = GetIncidentListViewModel(ref incident);

            return View("Create", model);
        }

        [Authorize]
        public ActionResult ListById(string incidentId)
        {
            Incident incident = Provider.GetIncident(incidentId);
            IncidentListViewModel model = GetIncidentListViewModel(ref incident);

            return View("Create", model);
        }

        [Authorize]
        internal static IncidentListViewModel GetIncidentListViewModel(ref Incident incident)
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

                //TODO: Get this from logged in user
                incident.Evaluator = Provider.GetDispatchers()[0];
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

        [Authorize]
        public ActionResult Delete(string incidentId)
        {
            Provider.DeleteIncident(incidentId);

            return RedirectToAction("Index");

        }

    }
}
