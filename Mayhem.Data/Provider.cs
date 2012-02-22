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
        private static readonly string _ConnectionString = ConfigurationManager.AppSettings["MayhemDatabase"];

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

        public static void Dispatcher_Delete(string dispatcherId)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);

            SqlCommand command = new SqlCommand("Dispatcher_Delete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@DispatcherId", dispatcherId);

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
    }
}
