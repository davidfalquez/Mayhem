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

            //If there is a user for this dispatcher, delete it
            if (Provider.UserExists(dispatcherId))
            {
                string username = Provider.GetUser(dispatcherId).Username;
                Data.Provider.User_Delete(username);
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
                if (incident.PrimaryIncident.PrimaryIncidentId != Guid.Empty)
                {
                    Data.Provider.PrimaryIncident_Update(incident.PrimaryIncident);
                }
                else
                {
                    incident.PrimaryIncident.PrimaryIncidentId = Guid.NewGuid();
                    Data.Provider.PrimaryIncident_Insert(incident.PrimaryIncident);
                }
            }
            if (null != incident.SecondaryIncident)
            {
                if (incident.SecondaryIncident.SecondaryIncidentId != Guid.Empty)
                {
                    Data.Provider.SecondaryIncident_Update(incident.SecondaryIncident);
                }
                else
                {
                    incident.SecondaryIncident.SecondaryIncidentId = Guid.NewGuid();
                    Data.Provider.SecondaryIncident_Insert(incident.SecondaryIncident);
                }
            }

            incident.LastUpdated = DateTime.Now;
            if (null != incident.PrimaryIncident && incident.PrimaryIncident.PrimaryIncidentId != Guid.Empty)
            {
                incident.PrimaryIncidentScore = PointSystem.PointTabulationTotalScore(new PrimaryFormPoints(incident.PrimaryIncident));
                incident.PrimaryIncidentScorePercent = (float)PointSystem.PointTabulation(new PrimaryFormPoints(incident.PrimaryIncident));
            }
            if (null != incident.SecondaryIncident && incident.SecondaryIncident.SecondaryIncidentId != Guid.Empty)
            {
                incident.SecondaryIncidentScore = PointSystem.PointTabulationTotalScore(new SecondaryFormPoints(incident.SecondaryIncident));
                incident.SecondaryIncidentScorePercent = (float)PointSystem.PointTabulation(new SecondaryFormPoints(incident.SecondaryIncident));
            }

            Data.Provider.Incident_Update(incident);
        }

        public static Incident GetIncident(string incidentId)
        {
            Incident returnValue = new Incident();
            DataSet incidentDataSet = Data.Provider.Incident_SelectById(incidentId);

            if (incidentDataSet.Tables[0].Rows.Count > 0)
            {
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
                if (null != incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScore"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScore"].ToString()))
                {
                    returnValue.PrimaryIncidentScore = int.Parse(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScore"].ToString());
                }
                if (null != incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScorePercent"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScorePercent"].ToString()))
                {
                    returnValue.PrimaryIncidentScorePercent = float.Parse(incidentDataSet.Tables[0].Rows[0]["PrimaryIncidentScorePercent"].ToString());
                }
                if (null != incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScore"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScore"].ToString()))
                {
                    returnValue.SecondaryIncidentScore = int.Parse(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScore"].ToString());
                }
                if (null != incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScorePercent"] && !string.IsNullOrEmpty(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScorePercent"].ToString()))
                {
                    returnValue.SecondaryIncidentScorePercent = float.Parse(incidentDataSet.Tables[0].Rows[0]["SecondaryIncidentScorePercent"].ToString());
                }
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

        public static PrimaryIncidentDispatcherReport GetPrimaryIncidentDispatcherReport(DateTime beginDate, DateTime endDate)
        {
            PrimaryIncidentDispatcherReport returnValue = new PrimaryIncidentDispatcherReport();
            returnValue.DispatcherTotals = new List<PrimaryIncidentReportTotals>();
            returnValue.DispatcherBottomLineTotals = new PrimaryIncidentReportTotals();
            DataSet reportDataSet = Data.Provider.PrimaryIncidentReport_Dispatcher_SelectByDateRange(beginDate, endDate);

            BuildReport(returnValue, reportDataSet, beginDate, endDate);
            returnValue.ReportName = "Protocol Compliance Report (Dispatchers)";
            returnValue.ScriptInfo = "Channel A Script";

            return returnValue;
        }

        public static PrimaryIncidentDispatcherReport GetPrimaryIncidentEvaluatorReport(DateTime beginDate, DateTime endDate)
        {
            PrimaryIncidentDispatcherReport returnValue = new PrimaryIncidentDispatcherReport();
            returnValue.DispatcherTotals = new List<PrimaryIncidentReportTotals>();
            returnValue.DispatcherBottomLineTotals = new PrimaryIncidentReportTotals();
            DataSet reportDataSet = Data.Provider.PrimaryIncidentReport_Evaluator_SelectByDateRange(beginDate, endDate);

            BuildReport(returnValue, reportDataSet, beginDate, endDate);
            returnValue.ReportName = "Protocol Compliance Report (Evaluators)";
            returnValue.ScriptInfo = "Channel A Script";

            return returnValue;
        }

        private static void BuildReport(PrimaryIncidentDispatcherReport returnValue, DataSet reportDataSet, DateTime beginDate, DateTime endDate)
        {
            foreach (DataRow row in reportDataSet.Tables[0].Rows)
            {
                PrimaryIncidentReportTotals incident = new PrimaryIncidentReportTotals();
                incident.Dispatcher = new Dispatcher();
                incident.Dispatcher.DispatcherId = row["DispatcherId"].ToString();
                incident.Dispatcher.FirstName = row["FirstName"].ToString();
                incident.Dispatcher.LastName = row["LastName"].ToString();
                incident.ToneAlertUsed = 100 * (decimal.Parse(row["ToneAlertUsed"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.ToneAlertUsed += incident.ToneAlertUsed;
                incident.Priority = 100 * (decimal.Parse(row["Priority"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Priority += incident.Priority;
                incident.Sunstar3DigitUnit = 100 * (decimal.Parse(row["Sunstar3DigitNumber"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Sunstar3DigitUnit += incident.Sunstar3DigitUnit;
                incident.Location = 100 * (decimal.Parse(row["Location"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Location += incident.Location;
                incident.MapGrid = 100 * (decimal.Parse(row["MapGrid"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.MapGrid += incident.MapGrid;
                incident.NatureOfCall = 100 * (decimal.Parse(row["NatureOfCall"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.NatureOfCall += incident.NatureOfCall;
                incident.SsTacChannel = 100 * (decimal.Parse(row["SsTacChannel"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.SsTacChannel += incident.SsTacChannel;
                incident.PertinentIntRouting = 100 * (decimal.Parse(row["PertinentIntRouting"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.PertinentIntRouting += incident.PertinentIntRouting;
                incident.InfoGivenOutOfOrder = 100 * (decimal.Parse(row["InfoGivenOutOfOrder"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.InfoGivenOutOfOrder += incident.InfoGivenOutOfOrder;
                incident.UsedProhibitedBehavior = 100 * (decimal.Parse(row["UsedProhibitedBehavior"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.UsedProhibitedBehavior += incident.UsedProhibitedBehavior;
                incident.DisplayedServiceAttitude = 100 * TertiaryReceptor(
                    int.Parse(row["DisplayedServiceAttitude_Correct"].ToString()),
                    int.Parse(row["DisplayedServiceAttitude_Incorrect"].ToString()),
                    int.Parse(row["DisplayedServiceAttitude_Minor"].ToString()),
                    25,
                    10,
                    0,
                    false);
                returnValue.DispatcherBottomLineTotals.DisplayedServiceAttitude += incident.DisplayedServiceAttitude;
                incident.UsedCorrectVolumeTone = 100 * TertiaryReceptor(
                    int.Parse(row["UsedCorrectVolumeTone_Correct"].ToString()),
                    int.Parse(row["UsedCorrectVolumeTone_Incorrect"].ToString()),
                    int.Parse(row["UsedCorrectVolumeTone_Minor"].ToString()),
                    25,
                    10,
                    0,
                    false);
                returnValue.DispatcherBottomLineTotals.UsedCorrectVolumeTone += incident.UsedCorrectVolumeTone;
                incident.CallCount = int.Parse(row["CallCount"].ToString());
                returnValue.DispatcherBottomLineTotals.CallCount += incident.CallCount;
                incident.TotalScore = decimal.Parse(row["TotalScore"].ToString()) / decimal.Parse(row["CallCount"].ToString());
                returnValue.DispatcherBottomLineTotals.TotalScore += incident.TotalScore;

                returnValue.DispatcherTotals.Add(incident);
            }
            if (reportDataSet.Tables[0].Rows.Count > 0)
            {
                returnValue.DispatcherBottomLineTotals.DisplayedServiceAttitude /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.InfoGivenOutOfOrder /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Location /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.MapGrid /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.NatureOfCall /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.PertinentIntRouting /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Priority /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.SsTacChannel /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Sunstar3DigitUnit /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.ToneAlertUsed /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.TotalScore /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.UsedCorrectVolumeTone /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.UsedProhibitedBehavior /= returnValue.DispatcherTotals.Count;
            }
            returnValue.BeginDate = beginDate;
            returnValue.EndDate = endDate;
        }

        private static void BuildReport(SecondaryIncidentDispatcherReport returnValue, DataSet reportDataSet, DateTime beginDate, DateTime endDate)
        {

            foreach (DataRow row in reportDataSet.Tables[0].Rows)
            {
                SecondaryIncidentReportTotals incident = new SecondaryIncidentReportTotals();
                incident.Dispatcher = new Dispatcher();
                incident.Dispatcher.DispatcherId = row["DispatcherId"].ToString();
                incident.Dispatcher.FirstName = row["FirstName"].ToString();
                incident.Dispatcher.LastName = row["LastName"].ToString();
                incident.Sunstar3DigitUnit = 100 * (decimal.Parse(row["Sunstar3DigitNumber"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Sunstar3DigitUnit += incident.Sunstar3DigitUnit;
                incident.NatureOfCall = 100 * (decimal.Parse(row["NatureOfCall"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.NatureOfCall += incident.NatureOfCall;
                incident.Location = 100 * (decimal.Parse(row["Location"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Location += incident.Location;
                incident.MapGrid = 100 * (decimal.Parse(row["MapGrid"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.MapGrid += incident.MapGrid;
                incident.FDUnitsAndTacCh = 100 * (decimal.Parse(row["FDUnitsAndTacCh"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.FDUnitsAndTacCh += incident.FDUnitsAndTacCh;
                incident.ScriptingDocumented = 100 * (decimal.Parse(row["ScriptingDocumented"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.ScriptingDocumented += incident.ScriptingDocumented;
                incident.SevenMin = 100 * (decimal.Parse(row["SevenMin"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.SevenMin += incident.SevenMin;
                incident.TwelveMin = 100 * (decimal.Parse(row["TwelveMin"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.TwelveMin += incident.TwelveMin;
                incident.ETALocationAsked = 100 * (decimal.Parse(row["ETALocationAsked"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.ETALocationAsked += incident.ETALocationAsked;
                incident.ETADocumented = 100 * (decimal.Parse(row["ETADocumented"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.ETADocumented += incident.ETADocumented;
                incident.RoutingDocumented = 100 * (decimal.Parse(row["RoutingDocumented"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.RoutingDocumented += incident.RoutingDocumented;
                incident.PreArrivalGiven = 100 * (decimal.Parse(row["PreArrivalGiven"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.PreArrivalGiven += incident.PreArrivalGiven;
                incident.EMDDocumented = 100 * (decimal.Parse(row["EMDDocumented"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.EMDDocumented += incident.EMDDocumented;
                incident.UsedProhibitedBehavior = 100 * (decimal.Parse(row["UsedProhibitedBehavior"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.UsedProhibitedBehavior += incident.UsedProhibitedBehavior;
                incident.PatchedChannels = 100 * (decimal.Parse(row["PatchedChannels"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.PatchedChannels += incident.PatchedChannels;
                incident.Phone = 100 * (decimal.Parse(row["Phone"].ToString()) / decimal.Parse(row["CallCount"].ToString()));
                returnValue.DispatcherBottomLineTotals.Phone += incident.Phone;

                incident.ProactiveRoutingGiven = 100 * TertiaryReceptor(
                    int.Parse(row["ProactiveRoutingGiven_Yes"].ToString()),
                    int.Parse(row["ProactiveRoutingGiven_No"].ToString()),
                    int.Parse(row["ProactiveRoutingGiven_NA"].ToString()),
                    5,
                    0,
                    0,
                    true);
                returnValue.DispatcherBottomLineTotals.ProactiveRoutingGiven += incident.ProactiveRoutingGiven;
                incident.CorrectRouting = 100 * TertiaryReceptor(
                    int.Parse(row["CorrectRouting_Yes"].ToString()),
                    int.Parse(row["CorrectRouting_No"].ToString()),
                    int.Parse(row["CorrectRouting_NA"].ToString()),
                    5,
                    0,
                    0,
                    true);
                incident.DisplayedServiceAttitude = 100 * TertiaryReceptor(
                int.Parse(row["DisplayedServiceAttitude_Correct"].ToString()),
                int.Parse(row["DisplayedServiceAttitude_Incorrect"].ToString()),
                int.Parse(row["DisplayedServiceAttitude_Minor"].ToString()),
                25,
                10,
                0,
                false);
                returnValue.DispatcherBottomLineTotals.DisplayedServiceAttitude += incident.DisplayedServiceAttitude;
                incident.UsedCorrectVolumeTone = 100 * TertiaryReceptor(
                    int.Parse(row["UsedCorrectVolumeTone_Correct"].ToString()),
                    int.Parse(row["UsedCorrectVolumeTone_Incorrect"].ToString()),
                    int.Parse(row["UsedCorrectVolumeTone_Minor"].ToString()),
                    25,
                    10,
                    0,
                    false);
                returnValue.DispatcherBottomLineTotals.UsedCorrectVolumeTone += incident.UsedCorrectVolumeTone;
                incident.CallCount = int.Parse(row["CallCount"].ToString());
                returnValue.DispatcherBottomLineTotals.CallCount += incident.CallCount;
                incident.TotalScore = decimal.Parse(row["TotalScore"].ToString()) / decimal.Parse(row["CallCount"].ToString());
                returnValue.DispatcherBottomLineTotals.TotalScore += incident.TotalScore;

                returnValue.DispatcherTotals.Add(incident);
            }
            if (reportDataSet.Tables[0].Rows.Count > 0)
            {
                returnValue.DispatcherBottomLineTotals.CorrectRouting /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.DisplayedServiceAttitude /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.EMDDocumented /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.ETADocumented /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.ETALocationAsked /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.FDUnitsAndTacCh /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Location /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.MapGrid /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.NatureOfCall /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.PatchedChannels /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Phone /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.PreArrivalGiven /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.ProactiveRoutingGiven /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.RoutingDocumented /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.ScriptingDocumented /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.SevenMin /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.Sunstar3DigitUnit /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.TotalScore /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.TwelveMin /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.UsedCorrectVolumeTone /= returnValue.DispatcherTotals.Count;
                returnValue.DispatcherBottomLineTotals.UsedProhibitedBehavior /= returnValue.DispatcherTotals.Count;
            }
            returnValue.BeginDate = beginDate;
            returnValue.EndDate = endDate;
        }

        public static decimal TertiaryReceptor(int highCount, int midCount, int lowCount, int highValue, int midValue, int lowValue, bool lowValueNA)
        {
            decimal returnValue = 0;

            int totalCount = highCount + midCount;
            if (!lowValueNA)
            {
                totalCount += lowCount;
            }
            decimal highestValue = totalCount * highValue;
            int highScore = highCount * highValue;
            int midScore = midCount * midValue;
            int lowScore = 0;

            if (!lowValueNA)
            {
                lowScore = lowCount * lowValue;
            }

            if (highestValue > 0)
            {
                returnValue = (highScore + midScore + lowScore) / highestValue;
            }
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

        public static SecondaryIncidentDispatcherReport GetSecondaryIncidentDispatcherReport(DateTime beginDate, DateTime endDate)
        {
            SecondaryIncidentDispatcherReport returnValue = new SecondaryIncidentDispatcherReport();
            returnValue.DispatcherTotals = new List<SecondaryIncidentReportTotals>();
            returnValue.DispatcherBottomLineTotals = new SecondaryIncidentReportTotals();
            DataSet reportDataSet = Data.Provider.SecondaryIncidentReport_Dispatcher_SelectByDateRange(beginDate, endDate);

            BuildReport(returnValue, reportDataSet, beginDate, endDate);
            returnValue.ReportName = "Protocol Compliance Report (Dispatchers)";
            returnValue.ScriptInfo = "Secondary Channel Script";

            return returnValue;
        }

        public static SecondaryIncidentDispatcherReport GetSecondaryIncidentEvaluatorReport(DateTime beginDate, DateTime endDate)
        {
            SecondaryIncidentDispatcherReport returnValue = new SecondaryIncidentDispatcherReport();
            returnValue.DispatcherTotals = new List<SecondaryIncidentReportTotals>();
            returnValue.DispatcherBottomLineTotals = new SecondaryIncidentReportTotals();
            DataSet reportDataSet = Data.Provider.SecondaryIncidentReport_Evaluator_SelectByDateRange(beginDate, endDate);

            BuildReport(returnValue, reportDataSet, beginDate, endDate);
            returnValue.ReportName = "Protocol Compliance Report (Evaluators)";
            returnValue.ScriptInfo = "Secondary Channel Script";

            return returnValue;
        }

        public static List<Role> GetRoles()
        {

            List<Role> returnValue = new List<Role>();
            DataSet roleDataSet = Data.Provider.RoleType_SelectAll();

            foreach (DataRow row in roleDataSet.Tables[0].Rows)
            {
                Role role = new Role();
                role.RoleTypeId = int.Parse(row["RoleTypeId"].ToString());
                role.RoleTypeDescription = row["RoleDescription"].ToString();

                returnValue.Add(role);
            }

            return returnValue;
        }
        public static bool Login(string username, string password)
        {
            bool returnValue = false;

            DataSet loginUserDS = Data.Provider.User_SelectByUsername(username);

            if (loginUserDS.Tables[0].Rows.Count > 0)
            {
                DataRow row = loginUserDS.Tables[0].Rows[0];

                string usernameFromDB = row["Username"].ToString();
                string passwordFromDB = row["Password"].ToString();
                bool validUser = bool.Parse(row["ValidUser"].ToString());


                returnValue = (username.ToUpper() == usernameFromDB.ToUpper() && password == passwordFromDB && validUser);
            }

            return returnValue;
        }

        public static bool UserIsDeveloper(string username)
        {
            bool returnValue = false;

            DataSet loginUserDS = Data.Provider.User_SelectByUsername(username);

            if (loginUserDS.Tables[0].Rows.Count > 0)
            {
                DataRow row = loginUserDS.Tables[0].Rows[0];

                returnValue = int.Parse(row["RoleTypeId"].ToString()) == 4;
            }

            return returnValue;
        }

        public static bool UserIsAdministrator(string username)
        {
            bool returnValue = false;

            DataSet loginUserDS = Data.Provider.User_SelectByUsername(username);

            if (loginUserDS.Tables[0].Rows.Count > 0)
            {
                DataRow row = loginUserDS.Tables[0].Rows[0];

                returnValue = int.Parse(row["RoleTypeId"].ToString()) == 1;
            }

            return returnValue;
        }

        public static bool UserIsEvaluator(string username)
        {
            bool returnValue = false;

            DataSet loginUserDS = Data.Provider.User_SelectByUsername(username);

            if (loginUserDS.Tables[0].Rows.Count > 0)
            {
                DataRow row = loginUserDS.Tables[0].Rows[0];

                returnValue = int.Parse(row["RoleTypeId"].ToString()) == 2;
            }

            return returnValue;
        }

        public static bool UserIsDispatcher(string username)
        {
            bool returnValue = false;

            DataSet loginUserDS = Data.Provider.User_SelectByUsername(username);

            if (loginUserDS.Tables[0].Rows.Count > 0)
            {
                DataRow row = loginUserDS.Tables[0].Rows[0];

                returnValue = int.Parse(row["RoleTypeId"].ToString()) == 3;
            }

            return returnValue;
        }

        public static void AddUser(string username, string password, bool isValid, string dispatcherId)
        {
            Data.Provider.User_Insert(username, password, isValid, dispatcherId);
        }

        public static void UpdateUser(string username, string password, bool isValid)
        {
            Data.Provider.User_Update(username, password, isValid);
        }

        public static bool UserExists(string dispatcherId)
        {
            bool returnValue = false;

            DataSet userDS = Data.Provider.User_SelectByDispatcherId(dispatcherId);
            returnValue = userDS.Tables[0].Rows.Count > 0;

            return returnValue;
        }

        public static SystemUser GetUser(string dispatcherId)
        {
            SystemUser returnValue = new SystemUser();

            returnValue.Dispatcher = GetDispatcher(dispatcherId);
            DataSet userDS = Data.Provider.User_SelectByDispatcherId(dispatcherId);
            DataRow row = userDS.Tables[0].Rows[0];
            returnValue.Username = row["Username"].ToString();
            returnValue.Password = row["Password"].ToString();
            returnValue.IsValid = bool.Parse(row["ValidUser"].ToString());

            return returnValue;
        }

        public static Dispatcher GetDispatcherByUsername(string username)
        {
            Dispatcher returnValue = new Dispatcher();
            DataSet dispatcherDataSet = Data.Provider.Dispatcher_SelectByUsername(username);

            returnValue.DispatcherId = dispatcherDataSet.Tables[0].Rows[0]["DispatcherId"].ToString();
            returnValue.FirstName = dispatcherDataSet.Tables[0].Rows[0]["FirstName"].ToString();
            returnValue.LastName = dispatcherDataSet.Tables[0].Rows[0]["LastName"].ToString();
            returnValue.RoleTypeId = int.Parse(dispatcherDataSet.Tables[0].Rows[0]["RoleTypeId"].ToString());
            return returnValue;
        }

    }
}
