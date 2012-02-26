using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Mayhem.DTO;
using System.Configuration;

namespace Mayhem.Data
{
    public static class Provider
    {
        private static readonly string _ConnectionString = GetConnectionStringFromConfig();

        private static string GetConnectionStringFromConfig()
        {
            string connectionString = ConfigurationManager.AppSettings["MayhemDatabase"];

#if DEBUG
            connectionString = string.Format(connectionString, Environment.MachineName, Environment.MachineName.Replace("1", string.Empty));
#endif

            return connectionString;
        }

        public static void Channel_Delete(int channelId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Channel_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ChannelId", channelId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Channel_Insert(string channelName)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Channel_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ChannelName", channelName);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Channel_SelectAll()
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Channel_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void Channel_Update(Channel input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Channel_Update", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ChannelId", input.ChannelId);
            command.Parameters.AddWithValue("@ChannelName", input.ChannelName);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Channel_SelectById(int channelId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Channel_SelectById", connection);          
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ChannelId", channelId);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void Dispatcher_Delete(string dispatcherId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DispatcherId", dispatcherId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Dispatcher_Insert(Dispatcher input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DispatcherId", input.DispatcherId);
            command.Parameters.AddWithValue("@FirstName", input.FirstName);
            command.Parameters.AddWithValue("@LastName", input.LastName);
            command.Parameters.AddWithValue("@RoleTypeId", input.RoleTypeId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Dispatcher_SelectAll()
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static DataSet Dispatcher_SelectById(string dispatcherId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_SelectById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DispatcherId", dispatcherId);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void Dispatcher_Update(Dispatcher input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_Update", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DispatcherId", input.DispatcherId);
            command.Parameters.AddWithValue("@FirstName", input.FirstName);
            command.Parameters.AddWithValue("@LastName", input.LastName);
            command.Parameters.AddWithValue("@RoleTypeId", input.RoleTypeId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Incident_Delete(string incidentId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IncidentId", incidentId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Incident_Insert(Incident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IncidentId", input.IncidentId);

            if (null == input.PrimaryIncident)
            {
                command.Parameters.AddWithValue("@PrimaryIncidentId", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PrimaryIncidentId", input.PrimaryIncident.PrimaryIncidentId);
            }

            if (null == input.SecondaryIncident)
            {
                command.Parameters.AddWithValue("@SecondaryIncidentId", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SecondaryIncidentId", input.SecondaryIncident.SecondaryIncidentId);

            }
            command.Parameters.AddWithValue("@EvaluatorId", input.Evaluator.DispatcherId);
            command.Parameters.AddWithValue("@EntryDate", input.EntryDate);
            command.Parameters.AddWithValue("@LastUpdated", input.LastUpdated);
            command.Parameters.AddWithValue("@PrimaryIncidentScore", input.PrimaryIncidentScore);
            command.Parameters.AddWithValue("@PrimaryIncidentScorePercent", input.PrimaryIncidentScorePercent);
            command.Parameters.AddWithValue("@SecondaryIncidentScore", input.SecondaryIncidentScore);
            command.Parameters.AddWithValue("@SecondaryIncidentScorePercent", input.SecondaryIncidentScorePercent);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Incident_SelectAll()
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static DataSet Incident_SelectById(string incidentId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_SelectById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IncidentId", incidentId);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static DataSet Incident_SelectByDateRange(DateTime beginDate, DateTime endDate)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_SelectByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BeginDate", beginDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void Incident_Update(Incident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Incident_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IncidentId", input.IncidentId);
            command.Parameters.AddWithValue("@PrimaryIncidentId", input.PrimaryIncident.PrimaryIncidentId);
            command.Parameters.AddWithValue("@SecondaryIncidentId", input.SecondaryIncident.SecondaryIncidentId);
            command.Parameters.AddWithValue("@EvaluatorId", input.Evaluator.DispatcherId);
            command.Parameters.AddWithValue("@EntryDate", input.EntryDate);
            command.Parameters.AddWithValue("@LastUpdated", input.LastUpdated);
            command.Parameters.AddWithValue("@PrimaryIncidentScore", input.PrimaryIncidentScore);
            command.Parameters.AddWithValue("@PrimaryIncidentScorePercent", input.PrimaryIncidentScorePercent);
            command.Parameters.AddWithValue("@SecondaryIncidentScore", input.SecondaryIncidentScore);
            command.Parameters.AddWithValue("@SecondaryIncidentScorePercent", input.SecondaryIncidentScorePercent);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void PrimaryIncident_Delete(Guid primaryIncidentId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("PrimaryIncident_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PrimaryIncidentId", primaryIncidentId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void PrimaryIncident_Insert(PrimaryIncident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("PrimaryIncident_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PrimaryIncidentId", input.PrimaryIncidentId);
            command.Parameters.AddWithValue("@ChannelId", input.Channel.ChannelId);
            command.Parameters.AddWithValue("@DispatcherId", input.Dispatcher.DispatcherId);
            command.Parameters.AddWithValue("@ShiftId", input.Shift.ShiftId);
            command.Parameters.AddWithValue("@DateTime", input.DateTime);
            command.Parameters.AddWithValue("@ToneAlertUsed", input.ToneAlertUsed);
            command.Parameters.AddWithValue("@Priority", input.Priority);
            command.Parameters.AddWithValue("@Sunstar3DigitNumber", input.Sunstar3DigitUnit);
            command.Parameters.AddWithValue("@Location", input.Location);
            command.Parameters.AddWithValue("@MapGrid", input.MapGrid);
            command.Parameters.AddWithValue("@NatureOfCall", input.NatureOfCall);
            command.Parameters.AddWithValue("@SSTacChannel", input.SSTacChannel);
            command.Parameters.AddWithValue("@PertinentIntRouting", input.PertinentIntRouting);
            command.Parameters.AddWithValue("@InfoGivenOutOfOrder", input.InfoGivenOutOfOrder);
            command.Parameters.AddWithValue("@DisplayedServiceAttitude", input.DisplayedServiceAttitude);
            command.Parameters.AddWithValue("@UsedCorrectVolumeTone", input.UsedCorrectVolumeTone);
            command.Parameters.AddWithValue("@UsedProhibitedBehavior", input.UsedProhibitedBehavior);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet PrimaryIncident_SelectByDateRange(DateTime beginDate, DateTime endDate)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("PrimaryIncident_SelectByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BeginDate", beginDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static DataSet PrimaryIncident_SelectById(Guid primaryIncidentId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("PrimaryIncident_SelectById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PrimaryIncidentId", primaryIncidentId);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void PrimaryIncident_Update(PrimaryIncident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("PrimaryIncident_Update", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("PrimaryIncidentId", input.PrimaryIncidentId);
            command.Parameters.AddWithValue("@ChannelId", input.Channel.ChannelId);
            command.Parameters.AddWithValue("@DispatcherId", input.Dispatcher.DispatcherId);
            command.Parameters.AddWithValue("@ShiftId", input.Shift.ShiftId);
            command.Parameters.AddWithValue("@DateTime", input.DateTime);
            command.Parameters.AddWithValue("@ToneAlertUsed", input.ToneAlertUsed);
            command.Parameters.AddWithValue("@Priority", input.Priority);
            command.Parameters.AddWithValue("@Sunstar3DigitNumber", input.Sunstar3DigitUnit);
            command.Parameters.AddWithValue("@Location", input.Location);
            command.Parameters.AddWithValue("@MapGrid", input.MapGrid);
            command.Parameters.AddWithValue("@NatureOfCall", input.NatureOfCall);
            command.Parameters.AddWithValue("@SSTacChannel", input.SSTacChannel);
            command.Parameters.AddWithValue("@PertinentIntRouting", input.PertinentIntRouting);
            command.Parameters.AddWithValue("@InfoGivenOutOfOrder", input.InfoGivenOutOfOrder);
            command.Parameters.AddWithValue("@DisplayedServiceAttitude", input.DisplayedServiceAttitude);
            command.Parameters.AddWithValue("@UsedCorrectVolumeTone", input.UsedCorrectVolumeTone);
            command.Parameters.AddWithValue("@UsedProhibitedBehavior", input.UsedProhibitedBehavior);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet RoleType_SelectAll()
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("RoleType_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void SecondaryIncident_Delete(Guid secondaryIncidentId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("SecondaryIncident_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@SecondaryIncidentId", secondaryIncidentId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void SecondaryIncident_Insert(SecondaryIncident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("SecondaryIncident_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@SecondaryIncidentId", input.SecondaryIncidentId);
            command.Parameters.AddWithValue("@ChannelId", input.Channel.ChannelId);
            command.Parameters.AddWithValue("@DispatcherId", input.Dispatcher.DispatcherId);
            command.Parameters.AddWithValue("@ShiftId", input.Shift.ShiftId);
            command.Parameters.AddWithValue("@DateTime", input.DateTime);
            command.Parameters.AddWithValue("@Sunstar3DigitNumber", input.Sunstar3DigitUnit);
            command.Parameters.AddWithValue("@NatureOfCall", input.NatureOfCall);
            command.Parameters.AddWithValue("@Location", input.Location);
            command.Parameters.AddWithValue("@MapGrid", input.MapGrid);
            command.Parameters.AddWithValue("@FDUnitsAndTacCh", input.FDUnitsAndTacCh);
            command.Parameters.AddWithValue("@ScriptingDocumented", input.ScriptingDocumented);
            command.Parameters.AddWithValue("@SevenMin", input.SevenMin);
            command.Parameters.AddWithValue("@TwelveMin", input.TwelveMin);
            command.Parameters.AddWithValue("@ETALocationAsked", input.ETALocationAsked);
            command.Parameters.AddWithValue("@ETADocumented", input.EMDDocumented);
            command.Parameters.AddWithValue("@ProactiveRoutingGiven", input.ProactiveRoutingGiven);
            command.Parameters.AddWithValue("@CorrectRouting", input.CorrectRouting);
            command.Parameters.AddWithValue("@RoutingDocumented", input.RoutingDocumented);
            command.Parameters.AddWithValue("@PreArrivalGiven", input.PreArrivalGiven);
            command.Parameters.AddWithValue("@EMDDocumented", input.EMDDocumented);
            command.Parameters.AddWithValue("@DisplayedServiceAttitude", input.DisplayedServiceAttitude);
            command.Parameters.AddWithValue("@UsedCorrectVolumeTone", input.UsedCorrectVolumeTone);
            command.Parameters.AddWithValue("@UsedProhibitedBehavior", input.UsedProhibitedBehavior);
            command.Parameters.AddWithValue("@PatchedChannels", input.PatchedChannels);
            command.Parameters.AddWithValue("@Phone", input.Phone);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet SecondaryIncident_SelectByDateRange(DateTime beginDate, DateTime endDate)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("SecondaryIncident_SelectByDateRange", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BeginDate", beginDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static DataSet SecondaryIncident_SelectById(Guid secondaryIncidentId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("SecondaryIncident_SelectById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@SecondaryIncidentId", secondaryIncidentId);

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;

        }

        public static void SecondaryIncident_Update(SecondaryIncident input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("SecondaryIncident_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@SecondaryIncidentId", input.SecondaryIncidentId);
            command.Parameters.AddWithValue("@ChannelId", input.Channel.ChannelId);
            command.Parameters.AddWithValue("@DispatcherId", input.Dispatcher.DispatcherId);
            command.Parameters.AddWithValue("@ShiftId", input.Shift.ShiftId);
            command.Parameters.AddWithValue("@DateTime", input.DateTime);
            command.Parameters.AddWithValue("@Sunstar3DigitNumber", input.Sunstar3DigitUnit);
            command.Parameters.AddWithValue("@NatureOfCall", input.NatureOfCall);
            command.Parameters.AddWithValue("@Location", input.Location);
            command.Parameters.AddWithValue("@MapGrid", input.MapGrid);
            command.Parameters.AddWithValue("@FDUnitsAndTacCh", input.FDUnitsAndTacCh);
            command.Parameters.AddWithValue("@ScriptingDocumented", input.ScriptingDocumented);
            command.Parameters.AddWithValue("@SevenMin", input.SevenMin);
            command.Parameters.AddWithValue("@TwelveMin", input.TwelveMin);
            command.Parameters.AddWithValue("@ETALocationAsked", input.ETALocationAsked);
            command.Parameters.AddWithValue("@ETADocumented", input.EMDDocumented);
            command.Parameters.AddWithValue("@ProactiveRoutingGiven", input.ProactiveRoutingGiven);
            command.Parameters.AddWithValue("@CorrectRouting", input.CorrectRouting);
            command.Parameters.AddWithValue("@RoutingDocumented", input.RoutingDocumented);
            command.Parameters.AddWithValue("@PreArrivalGiven", input.PreArrivalGiven);
            command.Parameters.AddWithValue("@EMDDocumented", input.EMDDocumented);
            command.Parameters.AddWithValue("@DisplayedServiceAttitude", input.DisplayedServiceAttitude);
            command.Parameters.AddWithValue("@UsedCorrectVolumeTone", input.UsedCorrectVolumeTone);
            command.Parameters.AddWithValue("@UsedProhibitedBehavior", input.UsedProhibitedBehavior);
            command.Parameters.AddWithValue("@PatchedChannels", input.PatchedChannels);
            command.Parameters.AddWithValue("@Phone", input.Phone);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Shift_Delete(int shiftId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Shift_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ShiftId", shiftId);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static void Shift_Insert(Shift input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Shift_Insert", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ShiftName", input.ShiftName);
            command.Parameters.AddWithValue("@ShiftAbbreviation", input.ShiftAbbreviation);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Shift_SelectAll()
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Shift_SelectAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }

        public static void Shift_Update(Shift input)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Shift_Update", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ShiftId", input.ShiftId);
            command.Parameters.AddWithValue("@ShiftName", input.ShiftName);
            command.Parameters.AddWithValue("@ShiftAbbreviation", input.ShiftAbbreviation);

            SqlUtility.ExecuteNonQuery(command);
        }

        public static DataSet Shift_SelectById(int shiftId)
        {
            DataSet returnValue = null;
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Shift_SelectById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ShiftId", shiftId);
            returnValue = SqlUtility.ExecuteQuery(command);

            return returnValue;
        }
    }
}
