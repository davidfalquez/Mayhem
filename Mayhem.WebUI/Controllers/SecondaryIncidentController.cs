using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.WebUI.Models;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class SecondaryIncidentController : Controller
    {
        //
        // GET: /SecondaryIncident/

        public ActionResult Index()
        {
            List<SecondaryIncidentViewModel> models = new List<SecondaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident incident in incidents)
            {
                SecondaryIncidentViewModel model = new SecondaryIncidentViewModel();
                model.CaseNumber = incident.IncidentId;
                model.IncidentId = incident.SecondaryIncident.SecondaryIncidentId;
                model.IncidentDate = incident.SecondaryIncident.DateTime;

                models.Add(model);
            }
            return View(models);
        }

        public ViewResult Create()
        {
            SecondaryIncidentViewModel model = new SecondaryIncidentViewModel();

            model.EvaluatorDropDown = DropDownUtility.GetDispatcherDropDown();
            model.DispatcherDropDown = DropDownUtility.GetDispatcherDropDown();
            model.ChannelDropDown = DropDownUtility.GetChannelDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            return View(model);
        }

        [HttpPost]
        public ViewResult Create(SecondaryIncidentViewModel model)
        {
            Incident incident = new Incident();
            incident.SecondaryIncident = new SecondaryIncident();
            incident.IncidentId = model.CaseNumber;
            incident.Evaluator = new Dispatcher();
            incident.Evaluator.DispatcherId = model.EvaluatorId;
            incident.SecondaryIncident.SecondaryIncidentId = model.IncidentId;
            incident.SecondaryIncident.Channel = new Channel();
            incident.SecondaryIncident.Channel.ChannelId = model.ChannelId;
            incident.SecondaryIncident.DateTime = model.IncidentDate;
            incident.SecondaryIncident.Sunstar3DigitUnit = model.Sunstar3DigitUnit;
            incident.SecondaryIncident.NatureOfCall = model.NatureOfCall;
            incident.SecondaryIncident.Location = model.Location;
            incident.SecondaryIncident.MapGrid = model.MapGrid;
            incident.SecondaryIncident.FDUnitsAndTacCh = model.FDUnitsAndTacCh;
            incident.SecondaryIncident.ScriptingDocumented = model.ScriptingDocumented;
            incident.SecondaryIncident.SevenMin = model.SevenMin;
            incident.SecondaryIncident.TwelveMin = model.TwelveMin;
            incident.SecondaryIncident.ETALocationAsked = model.ETALocationAsked;
            incident.SecondaryIncident.ETADocumented = model.ETADocumented;
            incident.SecondaryIncident.ProactiveRoutingGiven = model.ProactiveRoutingGiven;
            incident.SecondaryIncident.CorrectRouting = model.CorrectRouting;
            incident.SecondaryIncident.RoutingDocumented = model.RoutingDocumented;
            incident.SecondaryIncident.PreArrivalGiven = model.PreArrivalGiven;
            incident.SecondaryIncident.EMDDocumented = model.EMDDocumented;
            incident.SecondaryIncident.DisplayedServiceAttitude = model.DisplayedServiceAttitude;
            incident.SecondaryIncident.UsedCorrectVolumeTone = model.UsedCorrectVolumeTone;
            incident.SecondaryIncident.UsedProhibitedBehavior = model.UsedProhibitedBehavior;
            incident.SecondaryIncident.PatchedChannels = model.PatchedChannels;
            incident.SecondaryIncident.Phone = model.Phone;

            Provider.CreateIncident(incident);

            List<SecondaryIncidentViewModel> models = new List<SecondaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident result in incidents)
            {
                SecondaryIncidentViewModel indexModel = new SecondaryIncidentViewModel();
                indexModel.CaseNumber = result.IncidentId;
                indexModel.IncidentId = result.PrimaryIncident.PrimaryIncidentId;
                indexModel.IncidentDate = result.PrimaryIncident.DateTime;

                models.Add(indexModel);
            }
            return View("Index", models);
        }

        public ViewResult Edit(string incidentId)
        {
            SecondaryIncidentViewModel model = new SecondaryIncidentViewModel();

            Incident incident = Provider.GetIncident(incidentId);

            model.CaseNumber = incident.IncidentId;
            model.ChannelName = incident.SecondaryIncident.Channel.ChannelName;
            model.DispatcherId = incident.SecondaryIncident.Dispatcher.DispatcherId;
            model.CorrectRouting = incident.SecondaryIncident.CorrectRouting;
            model.DisplayedServiceAttitude = incident.SecondaryIncident.DisplayedServiceAttitude;
            model.EMDDocumented = incident.SecondaryIncident.EMDDocumented;
            model.ETADocumented = incident.SecondaryIncident.ETADocumented;
            model.FDUnitsAndTacCh = incident.SecondaryIncident.FDUnitsAndTacCh;
            model.IncidentDate = incident.SecondaryIncident.DateTime;
            model.IncidentId = incident.SecondaryIncident.SecondaryIncidentId;
            model.Location = incident.SecondaryIncident.Location;
            model.MapGrid = incident.SecondaryIncident.MapGrid;
            model.NatureOfCall = incident.SecondaryIncident.NatureOfCall;
            model.PatchedChannels = incident.SecondaryIncident.PatchedChannels;
            model.Phone = incident.SecondaryIncident.Phone;
            model.PreArrivalGiven = incident.SecondaryIncident.PreArrivalGiven;
            model.ProactiveRoutingGiven = incident.SecondaryIncident.ProactiveRoutingGiven;
            model.RoutingDocumented = incident.SecondaryIncident.RoutingDocumented;
            model.ScriptingDocumented = incident.SecondaryIncident.ScriptingDocumented;
            model.SevenMin = incident.SecondaryIncident.SevenMin;
            model.TwelveMin = incident.SecondaryIncident.TwelveMin;
            model.UsedCorrectVolumeTone = incident.SecondaryIncident.UsedCorrectVolumeTone;
            model.UsedProhibitedBehavior = incident.SecondaryIncident.UsedProhibitedBehavior;

            model.EvaluatorDropDown = DropDownUtility.GetDispatcherDropDown();
            model.DispatcherDropDown = DropDownUtility.GetDispatcherDropDown();
            model.ChannelDropDown = DropDownUtility.GetChannelDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            return View(model);
        }

        public ViewResult Delete(string incidentId)
        {
            Provider.DeleteIncident(incidentId);
            List<SecondaryIncidentViewModel> models = new List<SecondaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident incident in incidents)
            {
                SecondaryIncidentViewModel model = new SecondaryIncidentViewModel();
                model.CaseNumber = incident.IncidentId;
                model.IncidentId = incident.SecondaryIncident.SecondaryIncidentId;
                model.IncidentDate = incident.SecondaryIncident.DateTime;

                models.Add(model);
            }
            return View("Index", models);
        }
    }
}
