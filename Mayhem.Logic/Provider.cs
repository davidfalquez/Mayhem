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

        public static List<PrimaryIncident> GetPrimaryIncident(int incidentId = 1)
        {
            List<PrimaryIncident> returnValue = new List<PrimaryIncident>();
            PrimaryIncident pI = new PrimaryIncident();
            DataSet primaryIncidentDataSet = Data.Provider.PrimaryIncident_SelectById(incidentId);

            pI.PrimaryIncidentId = int.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["PrimaryIncidentId"].ToString());
            pI.Channel = GetChannel(int.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ChannelId"].ToString()));
            pI.Dispatcher = GetDispatcher(primaryIncidentDataSet.Tables[0].Rows[0]["DispatcherId"].ToString());
            pI.Shift = GetShift(int.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ShiftId"].ToString()));
            pI.DateTime = DateTime.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["DateTime"].ToString());
            pI.ToneAlertUsed = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["ToneAlertUsed"].ToString());
            pI.Priority = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Priority"].ToString());
            pI.Sunstar3DigitUnit = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Sunstar3DigitNumber"].ToString());
            pI.Location = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["Location"].ToString());
            pI.MapGrid = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["MapGrid"].ToString());
            pI.NatureOfCall = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["NatureOfCall"].ToString());
            pI.SSTacChannel = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["SSTacChannel"].ToString());
            pI.PertinentIntRouting = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["PertinentIntRouting"].ToString());
            pI.InfoGivenOutOfOrder = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["InfoGivenOutOfOrder"].ToString());
            pI.DisplayedServiceAttitude = primaryIncidentDataSet.Tables[0].Rows[0]["DisplayedServiceAttitude"].ToString();
            pI.UsedCorrectVolumeTone = primaryIncidentDataSet.Tables[0].Rows[0]["UsedCorrectVolumeTone"].ToString();
            pI.UsedProhibitedBehavior = bool.Parse(primaryIncidentDataSet.Tables[0].Rows[0]["UsedProhibitedBehavior"].ToString());

            returnValue.Add(pI);
            return returnValue;
        }

    }
}
