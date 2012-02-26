using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.WebUI.Models;
using Mayhem.Logic;
using Mayhem.DTO;

namespace Mayhem.WebUI.Controllers
{
    public class PrimaryIncidentController : Controller
    {
        //
        // GET: /PrimaryIncident/

        public ActionResult Index()
        {
            List<PrimaryIncidentViewModel> models = new List<PrimaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident incident in incidents)
            {
                PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();
                model.CaseNumber = incident.IncidentId;
                model.IncidentId = incident.PrimaryIncident.PrimaryIncidentId;
                model.IncidentDate = incident.PrimaryIncident.DateTime;

                models.Add(model);
            }
            return View(models);
        }

        public ViewResult Create()
        {
            PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();

            //Fill Drop Downs
            model.EvaluatorDropDown = DropDownUtility.GetEvaluatorDropDown();
            model.DispatcherDropDown = DropDownUtility.GetEvaluatorDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            return View(model);
        }

        [HttpPost]
        public ViewResult Create(PrimaryIncidentViewModel model)
        {
            Incident incident = new Incident();
            incident.PrimaryIncident = new PrimaryIncident();
            incident.IncidentId = model.CaseNumber;
            incident.Evaluator = new Dispatcher();
            incident.Evaluator.DispatcherId = model.EvaluatorId;
            incident.PrimaryIncident.PrimaryIncidentId = model.IncidentId;
            incident.PrimaryIncident.Channel = new Channel();
            incident.PrimaryIncident.DateTime = model.IncidentDate;
            incident.PrimaryIncident.Dispatcher = new Dispatcher();
            incident.PrimaryIncident.Dispatcher.DispatcherId = model.DispatcherId;
            incident.PrimaryIncident.DisplayedServiceAttitude = model.DisplayedServiceAttitude;
            incident.PrimaryIncident.InfoGivenOutOfOrder = model.InfoGivenOutOfOrder;
            incident.PrimaryIncident.Location = model.Location;
            incident.PrimaryIncident.MapGrid = model.MapGrid;
            incident.PrimaryIncident.NatureOfCall = model.NatureOfCall;
            incident.PrimaryIncident.PertinentIntRouting = model.PertinentIntRouting;
            incident.PrimaryIncident.Priority = model.Priority;
            incident.PrimaryIncident.Shift = new Shift();
            incident.PrimaryIncident.Shift.ShiftId = model.ShiftId;
            incident.PrimaryIncident.SSTacChannel = model.SSTacChannel;
            incident.PrimaryIncident.Sunstar3DigitUnit = model.Sunstar3DigitUnit;
            incident.PrimaryIncident.ToneAlertUsed = model.ToneAlertUsed;
            incident.PrimaryIncident.UsedCorrectVolumeTone = model.UsedCorrectVolumeTone;
            incident.PrimaryIncident.UsedProhibitedBehavior = model.UsedProhibitedBehavior;

            //This is channel A
            incident.PrimaryIncident.Channel.ChannelId = GetChannelAId();


            Provider.CreateIncident(incident);

            List<PrimaryIncidentViewModel> models = new List<PrimaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident result in incidents)
            {
                PrimaryIncidentViewModel indexModel = new PrimaryIncidentViewModel();
                indexModel.CaseNumber = result.IncidentId;
                indexModel.IncidentId = result.PrimaryIncident.PrimaryIncidentId;
                indexModel.IncidentDate = result.PrimaryIncident.DateTime;

                models.Add(indexModel);
            }
            return View("Index", models);
        }

        private int GetChannelAId()
        {
            int channelAId = 0;

            List<Channel> channels = Provider.GetChannels();
            foreach (Channel channel in channels)
            {
                if (channel.ChannelName == "Channel A")
                {
                    channelAId = channel.ChannelId;
                    break;
                }
            }

            return channelAId;
        }

        public ViewResult Edit(string incidentId)
        {
            PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();
            //Fill Drop Downs
            model.EvaluatorDropDown = DropDownUtility.GetEvaluatorDropDown();
            model.DispatcherDropDown = DropDownUtility.GetEvaluatorDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            Incident incident = Provider.GetIncident(incidentId);

            model.CaseNumber = incident.IncidentId;
            model.ChannelId = incident.PrimaryIncident.Channel.ChannelId;
            model.DispatcherId = incident.PrimaryIncident.Dispatcher.DispatcherId;
            model.DisplayedServiceAttitude = incident.PrimaryIncident.DisplayedServiceAttitude;
            model.EvaluatorId = incident.PrimaryIncident.Dispatcher.DispatcherId.ToString();
            model.IncidentDate = incident.PrimaryIncident.DateTime;
            model.IncidentId = incident.PrimaryIncident.PrimaryIncidentId;
            model.InfoGivenOutOfOrder = incident.PrimaryIncident.InfoGivenOutOfOrder;
            model.Location = incident.PrimaryIncident.Location;
            model.MapGrid = incident.PrimaryIncident.MapGrid;
            model.NatureOfCall = incident.PrimaryIncident.NatureOfCall;
            model.PertinentIntRouting = incident.PrimaryIncident.PertinentIntRouting;
            model.Priority = incident.PrimaryIncident.Priority;
            model.ShiftId = incident.PrimaryIncident.Shift.ShiftId;
            model.SSTacChannel = incident.PrimaryIncident.SSTacChannel;
            model.Sunstar3DigitUnit = incident.PrimaryIncident.Sunstar3DigitUnit;
            model.ToneAlertUsed = incident.PrimaryIncident.ToneAlertUsed;
            model.UsedCorrectVolumeTone = incident.PrimaryIncident.UsedCorrectVolumeTone;
            model.UsedProhibitedBehavior = incident.PrimaryIncident.UsedProhibitedBehavior;

            return View(model);
        }

        //[HttpPost]
        //public ViewResult Edit(PrimaryIncidentViewModel dispatcher)
        //{
        //    Provider.UpdateDispatcher(dispatcher);
        //    return View("Index", Provider.GetDispatchers());
        //}



        public ViewResult Delete(string incidentId)
        {
            Provider.DeleteIncident(incidentId);
            List<PrimaryIncidentViewModel> models = new List<PrimaryIncidentViewModel>();
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident incident in incidents)
            {
                PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();
                model.CaseNumber = incident.IncidentId;
                model.IncidentId = incident.PrimaryIncident.PrimaryIncidentId;
                model.IncidentDate = incident.PrimaryIncident.DateTime;

                models.Add(model);
            }
            return View("Index", models);
        }
    }
}
