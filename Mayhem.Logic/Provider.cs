using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mayhem.DTO;
using System.Data;

namespace Mayhem.Logic
{
    public static class Provider
    {
        private static string _InvalidMessage = "{0} cannot be null.";
        private static string _InvalidIdMessage = "{0} cannot be null, empty, or 0.";

        public static void CreateChannel(string channelName)
        {
            if (channelName == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Channel"));
            }
            Data.Provider.Channel_Insert(channelName);
        }

        public static void UpdateChannel(Channel channel)
        {
            if (channel == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Channel"));
            }
            Data.Provider.Channel_Update(channel);
        }

        public static Channel GetChannel(int channelId)
        {
            Channel returnValue = new Channel();
            DataSet channelDataSet = Data.Provider.Channel_SelectById(channelId);

            returnValue.ChannelId = int.Parse(channelDataSet.Tables[0].Rows[0]["ChannelId"].ToString());
            returnValue.ChannelName = channelDataSet.Tables[0].Rows[0]["ChannelName"].ToString();

            return returnValue;
        }

        public static List<Channel> GetChannels()
        {
            List<Channel> returnValue = new List<Channel>();
            DataSet channelDataSet = Data.Provider.Channel_SelectAll();

            foreach (DataRow row in channelDataSet.Tables[0].Rows)
            {
                Channel channel = new Channel();
                channel.ChannelId = int.Parse(row["ChannelId"].ToString());
                channel.ChannelName = row["ChannelName"].ToString();
                returnValue.Add(channel);
            }
            return returnValue;
        }

        public static void DeleteChannel(int channelId)
        {
            if (channelId <= 0)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "Channel"));
            }
            Data.Provider.Channel_Delete(channelId);
        }

        public static void CreateDispatcher(Dispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Dispatcher"));
            }
            if (dispatcher.DispatcherId == null)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "DispatcherId"));
            }
            Data.Provider.Dispatcher_Insert(dispatcher);
        }

        public static void UpdateDispatcher(Dispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Dispatcher"));
            }
            if (dispatcher.DispatcherId == null)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "DispatcherId"));
            }
            Data.Provider.Dispatcher_Update(dispatcher);
        }

        public static Dispatcher GetDispatcher(string dispatcherId)
        {
            Dispatcher returnValue = new Dispatcher();
            DataSet dispatcherDataSet = Data.Provider.Dispatcher_SelectById(dispatcherId);

            returnValue.DispatcherId = dispatcherDataSet.Tables[0].Rows[0]["DispatcherId"].ToString();
            returnValue.FirstName = dispatcherDataSet.Tables[0].Rows[0]["FirstName"].ToString();
            returnValue.LastName = dispatcherDataSet.Tables[0].Rows[0]["LastName"].ToString();
            returnValue.RoleTypeId = int.Parse(dispatcherDataSet.Tables[0].Rows[0]["RoleTypeId"].ToString());
            return returnValue;
        }

        public static List<Dispatcher> GetDispatchers()
        {
            List<Dispatcher> returnValue = new List<Dispatcher>();
            DataSet dispatcherDataSet = Data.Provider.Dispatcher_SelectAll();

            foreach (DataRow row in dispatcherDataSet.Tables[0].Rows)
            {
                Dispatcher dispatcher = new Dispatcher();
                dispatcher.DispatcherId = row["DispatcherId"].ToString();
                dispatcher.FirstName = row["FirstName"].ToString();
                dispatcher.LastName = row["LastName"].ToString();
                dispatcher.RoleTypeId = int.Parse(row["RoleTypeId"].ToString());
                returnValue.Add(dispatcher);
            }
            return returnValue;
        }

        public static void DeleteDispatcher(string dispatcherId)
        {
            if (dispatcherId == null)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "DispatcherId"));
            }
            Data.Provider.Dispatcher_Delete(dispatcherId);
        }

        public static void CreateShift(Shift shift)
        {
            if (shift == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Shift"));
            }
            Data.Provider.Shift_Insert(shift);
        }

        public static void UpdateShift(Shift shift)
        {
            if (shift == null)
            {
                throw new Exception(string.Format(_InvalidMessage, "Shift"));
            }
            if (shift.ShiftId <= 0)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "ShiftId"));
            }
            Data.Provider.Shift_Update(shift);
        }

        public static void DeleteShift(int shiftId)
        {
            if (shiftId <= 0)
            {
                throw new Exception(string.Format(_InvalidIdMessage, "ShiftId"));
            }
            Data.Provider.Shift_Delete(shiftId);
        }

        public static Shift GetShift(int shiftId)
        {
            Shift shift = new Shift();
            DataSet shiftDataset = Data.Provider.Shift_SelectById(shiftId);

            shift.ShiftId = int.Parse(shiftDataset.Tables[0].Rows[0]["ShiftId"].ToString());
            shift.ShiftName = shiftDataset.Tables[0].Rows[0]["ShiftName"].ToString();
            shift.ShiftAbbreviation = shiftDataset.Tables[0].Rows[0]["ShiftAbbreviation"].ToString();

            return shift;
        }

        public static List<Shift> GetShifts()
        {
            List<Shift> returnValue = new List<Shift>();
            DataSet shiftDataset = Data.Provider.Shift_SelectAll();

            foreach (DataRow row in shiftDataset.Tables[0].Rows)
            {
                Shift shift = new Shift();
                shift.ShiftId = int.Parse(row["ShiftId"].ToString());
                shift.ShiftName = row["ShiftName"].ToString();
                shift.ShiftAbbreviation = row["ShiftAbbreviation"].ToString();

                returnValue.Add(shift);
            }
            return returnValue;
        }

        public static void CreateIncident(Incident incident)
        {
            //Make sure the incident does not exist, if it does throw an exception
            //TODO: 
            if (null != incident.PrimaryIncident)
            {
                incident.PrimaryIncident.PrimaryIncidentId = Guid.NewGuid();
                Data.Provider.PrimaryIncident_Insert(incident.PrimaryIncident);
                incident.PrimaryIncidentScore = PointSystem.PointTabulationTotalScore(new PrimaryFormPoints(incident.PrimaryIncident));
                incident.PrimaryIncidentScorePercent = (float)PointSystem.PointTabulation(new PrimaryFormPoints(incident.PrimaryIncident));
            }
            if (null != incident.SecondaryIncident)
            {
                incident.SecondaryIncident.SecondaryIncidentId = Guid.NewGuid();
                Data.Provider.SecondaryIncident_Insert(incident.SecondaryIncident);
                incident.SecondaryIncidentScore = PointSystem.PointTabulationTotalScore(new SecondaryFormPoints(incident.SecondaryIncident));
                incident.SecondaryIncidentScorePercent = (float)PointSystem.PointTabulation(new SecondaryFormPoints(incident.SecondaryIncident));
            }

            incident.EntryDate = DateTime.Now;
            incident.LastUpdated = DateTime.Now;

            Data.Provider.Incident_Insert(incident);
        }

        public static void UpdateIncident(Incident incident)
        {
            if (null != incident.PrimaryIncident)
            {
                Data.Provider.PrimaryIncident_Update(incident.PrimaryIncident);
            }
            if (null != incident.SecondaryIncident)
            {
                Data.Provider.SecondaryIncident_Update(incident.SecondaryIncident);
            }

            incident.LastUpdated = DateTime.Now;
            incident.PrimaryIncidentScore = PointSystem.PointTabulationTotalScore(new PrimaryFormPoints(incident.PrimaryIncident));
            incident.PrimaryIncidentScorePercent = (float)PointSystem.PointTabulation(new PrimaryFormPoints(incident.PrimaryIncident));
            incident.SecondaryIncidentScore = PointSystem.PointTabulationTotalScore(new SecondaryFormPoints(incident.SecondaryIncident));
            incident.SecondaryIncidentScorePercent = (float)PointSystem.PointTabulation(new SecondaryFormPoints(incident.SecondaryIncident));

            Data.Provider.Incident_Update(incident);
        }

        public static Incident GetIncident(string incidentId)
        {
            Incident returnValue = new Incident();
            DataSet incidentDataSet = Data.Provider.Incident_SelectById(incidentId);

            returnValue.IncidentId = incidentDataSet.Tables[0].Rows[0]["IncidentId"].ToString();
            returnValue.PrimaryIncident = new PrimaryIncident();
            if (null != incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentId"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentId"].ToString()))
            {
                returnValue.PrimaryIncident.PrimaryIncidentId = new Guid(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentId"].ToString());
                returnValue.PrimaryIncident = GetPrimaryIncident(returnValue.PrimaryIncident.PrimaryIncidentId);
            }
            returnValue.SecondaryIncident = new SecondaryIncident();
            if (null != incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentId"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentId"].ToString()))
            {
                returnValue.SecondaryIncident.SecondaryIncidentId = new Guid(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentId"].ToString());
                returnValue.SecondaryIncident = GetSecondaryIncident(returnValue.SecondaryIncident.SecondaryIncidentId);
            }
            returnValue.Evaluator = new Dispatcher();
            returnValue.Evaluator.DispatcherId = incidentDataSet.Tables[0].Rows[0]["EvaluatorId"].ToString();
            returnValue.Evaluator = GetDispatcher(returnValue.Evaluator.DispatcherId);
            returnValue.EntryDate = DateTime.Parse(incidentDataSet.Tables[0].Rows[0]["EntryDate"].ToString());
            returnValue.LastUpdated = DateTime.Parse(incidentDataSet.Tables[0].Rows[0]["LastUpdated"].ToString());
            if (null != incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScore"])
            {
                returnValue.PrimaryIncidentScore = int.Parse(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScore"].ToString());
            }
            if (null != incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScorePercent"])
            {
                returnValue.PrimaryIncidentScorePercent = float.Parse(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScorePercent"].ToString());
            }
            if (null != incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScore"])
            {
                returnValue.SecondaryIncidentScore = int.Parse(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScore"].ToString());
            }
            if (null != incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScorePercent"])
            {
                returnValue.SecondaryIncidentScorePercent = float.Parse(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScorePercent"].ToString());
            }

            return returnValue;
        }

        public static void DeleteIncident(string incidentId)
        {
            Incident incident = GetIncident(incidentId);
            Guid p = incident.PrimaryIncident.PrimaryIncidentId;
            Guid s = incident.SecondaryIncident.SecondaryIncidentId;
            Data.Provider.Incident_Delete(incidentId);
            Data.Provider.PrimaryIncident_Delete(p);
            Data.Provider.SecondaryIncident_Delete(s);
        }

        public static List<Incident> GetIncidents()
        {
            List<Incident> incidentList = new List<Incident>();
            DataSet incidentDataSet = Data.Provider.Incident_SelectAll();

            foreach (DataRow row in incidentDataSet.Tables[0].Rows)
            {
                string incidentId = row["IncidentId"].ToString();
                Incident incident = GetIncident(incidentId);

                incidentList.Add(incident);
            }

            return incidentList;
        }

        public static PrimaryIncident GetPrimaryIncident(Guid incidentId)
        {
            PrimaryIncident returnValue = new PrimaryIncident();
            DataSet primaryIncidentDataSet = Data.Provider.PrimaryIncident_SelectById(incidentId);

            returnValue.PrimaryIncidentId = new Guid(primaryIncidentDataSet.Tables[0].Rows[0]["PrimaryIncidentId"].ToString());
            returnValue.Channel = GetChannel(int.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ChannelId"].ToString()));
            returnValue.Dispatcher = GetDispatcher(primaryIncidentDataSet.Tables[0].Rows[0]["DispatcherId"].ToString());
            returnValue.Shift = GetShift(int.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ShiftId"].ToString()));
            returnValue.DateTime = DateTime.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["DateTime"].ToString());
            returnValue.ToneAlertUsed = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ToneAlertUsed"].ToString());
            returnValue.Priority = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Priority"].ToString());
            returnValue.Sunstar3DigitUnit = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Sunstar3DigitNumber"].ToString());
            returnValue.Location = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Location"].ToString());
            returnValue.MapGrid = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["MapGrid"].ToString());
            returnValue.NatureOfCall = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["NatureOfCall"].ToString());
            returnValue.SSTacChannel = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["SSTacChannel"].ToString());
            returnValue.PertinentIntRouting = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["PertinentIntRouting"].ToString());
            returnValue.InfoGivenOutOfOrder = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["InfoGivenOutOfOrder"].ToString());
            returnValue.DisplayedServiceAttitude = primaryIncidentDataSet.Tables[0].Rows[0]["DisplayedServiceAttitude"].ToString();
            returnValue.UsedCorrectVolumeTone = primaryIncidentDataSet.Tables[0].Rows[0]["UsedCorrectVolumeTone"].ToString();
            returnValue.UsedProhibitedBehavior = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["UsedProhibitedBehavior"].ToString());

            return returnValue;
        }

        public static SecondaryIncident GetSecondaryIncident(Guid incidentId)
        {
            SecondaryIncident returnValue = new SecondaryIncident();
            DataSet secondaryIncidentDataSet = Data.Provider.SecondaryIncident_SelectById(incidentId);

            returnValue.SecondaryIncidentId = new Guid(secondaryIncidentDataSet.Tables[0].Rows[0]["SecondaryIncidentId"].ToString());
            returnValue.Channel = GetChannel(int.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["ChannelId"].ToString()));
            returnValue.Dispatcher = GetDispatcher(secondaryIncidentDataSet.Tables[0].Rows[0]["DispatcherId"].ToString());
            returnValue.Shift = GetShift(int.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["ShiftId"].ToString()));
            returnValue.DateTime = DateTime.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["DateTime"].ToString());
            returnValue.Sunstar3DigitUnit = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["Sunstar3DigitNumber"].ToString());
            returnValue.Location = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["Location"].ToString());
            returnValue.MapGrid = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["MapGrid"].ToString());
            returnValue.NatureOfCall = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["NatureOfCall"].ToString());
            returnValue.FDUnitsAndTacCh = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["FDUnitsAndTacCh"].ToString());
            returnValue.ScriptingDocumented = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["ScriptingDocumented"].ToString());
            returnValue.SevenMin = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["SevenMin"].ToString());
            returnValue.TwelveMin = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["TwelveMin"].ToString());
            returnValue.ETALocationAsked = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["ETALocationAsked"].ToString());
            returnValue.ETADocumented = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["ETADocumented"].ToString());
            returnValue.ProactiveRoutingGiven = secondaryIncidentDataSet.Tables[0].Rows[0]["ProactiveRoutingGiven"].ToString();
            returnValue.CorrectRouting = secondaryIncidentDataSet.Tables[0].Rows[0]["CorrectRouting"].ToString();
            returnValue.RoutingDocumented = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["RoutingDocumented"].ToString());
            returnValue.PreArrivalGiven = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["PreArrivalGiven"].ToString());
            returnValue.EMDDocumented = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["EMDDocumented"].ToString());
            returnValue.DisplayedServiceAttitude = secondaryIncidentDataSet.Tables[0].Rows[0]["DisplayedServiceAttitude"].ToString();
            returnValue.UsedCorrectVolumeTone = secondaryIncidentDataSet.Tables[0].Rows[0]["UsedCorrectVolumeTone"].ToString();
            returnValue.UsedProhibitedBehavior = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["UsedProhibitedBehavior"].ToString());
            returnValue.PatchedChannels = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["PatchedChannels"].ToString());
            returnValue.Phone = bool.Parse(secondaryIncidentDataSet.Tables[0].Rows[0]["Phone"].ToString());

            return returnValue;
        }
    }
}
