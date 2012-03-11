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
            IncidentListViewModel model = IncidentUtility.GetIncidentListViewModel(ref incident, this);

            return View("Create", model);
        }

        [Authorize]
        public ActionResult List(Incident incident)
        {
            IncidentListViewModel model = IncidentUtility.GetIncidentListViewModel(ref incident, this);

            return View("Create", model);
        }

        [Authorize]
        public ActionResult ListById(string incidentId)
        {
            Incident incident = Provider.GetIncident(incidentId);
            IncidentListViewModel model = IncidentUtility.GetIncidentListViewModel(ref incident, this);

            return View("Create", model);
        }


        [Authorize]
        public ActionResult Delete(string incidentId)
        {
            Provider.DeleteIncident(incidentId);

            return RedirectToAction("Index");

        }

    }
}
