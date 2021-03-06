﻿using System;
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

        [Authorize]
        public ActionResult Index()
        {
            List<PrimaryIncidentViewModel> models = new List<PrimaryIncidentViewModel>();
            GetPrimaryIncidentViewModelList(models);
            return View(models);
        }

        private static void GetPrimaryIncidentViewModelList(List<PrimaryIncidentViewModel> models)
        {
            List<Incident> incidents = Provider.GetIncidents();
            foreach (Incident incident in incidents)
            {
                if (incident.PrimaryIncident.PrimaryIncidentId != Guid.Empty)
                {
                    PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();
                    model.CaseNumber = incident.IncidentId;
                    model.IncidentId = incident.PrimaryIncident.PrimaryIncidentId;
                    model.IncidentDate = incident.PrimaryIncident.DateTime;

                    models.Add(model);
                }
            }
        }

        [Authorize]
        public ViewResult Create(string incidentId)
        {
            PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();
            model.CaseNumber = incidentId;
            model.IncidentDate = DateTime.Now;

            //Fill Drop Downs
            model.DispatcherDropDown = DropDownUtility.GetDispatcherDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(PrimaryIncidentViewModel model)
        {
            IncidentListViewModel output = CreateOrUpdatePrimaryIncident(model);

            return View("../Incident/Create", output);
        }

        private IncidentListViewModel CreateOrUpdatePrimaryIncident(PrimaryIncidentViewModel model)
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

            Incident incidentResult = Provider.GetIncident(model.CaseNumber);
            if (null != incidentResult && !string.IsNullOrEmpty(incidentResult.IncidentId))
            {
                incidentResult.SecondaryIncident = null;
                incidentResult.PrimaryIncident = incident.PrimaryIncident;
                Provider.UpdateIncident(incidentResult);
            }
            else
            {
                incidentResult.SecondaryIncident = null;
                Provider.CreateIncident(incident);
            }

            IncidentListViewModel output = IncidentUtility.GetIncidentListViewModel(ref incident, this);
            return output;
        }

        [Authorize]
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

        [Authorize]
        public ViewResult Edit(string incidentId)
        {
            PrimaryIncidentViewModel model = new PrimaryIncidentViewModel();

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

            //Fill Drop Downs
            model.DispatcherDropDown = DropDownUtility.GetDispatcherDropDown();
            model.ShiftDropDown = DropDownUtility.GetShiftDropDown();
            model.DisplayedServiceAttitudeDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();
            model.UsedCorrectVolumeToneDropDown = DropDownUtility.GetCorrectMinorIncorrectDropDown();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(PrimaryIncidentViewModel incident)
        {
            IncidentListViewModel output = CreateOrUpdatePrimaryIncident(incident);

            return View("../Incident/Create", output);
        }

        [Authorize]
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
