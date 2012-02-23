using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Mayhem.Data
{
    public static class SqlUtility
    {
        public static int ExecuteNonQuery(SqlCommand command)
        {
            int result;
            try
            {
                command.Connection.Open();
                result = command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }

            return result;
        }

        public static DataSet ExecuteQuery(SqlCommand command)
        {
            DataSet returnValue = new DataSet();
            SqlDataAdapter dataAdaptor = new SqlDataAdapter();
            try
            {
                command.Connection.Open();
                dataAdaptor.SelectCommand = command;
                dataAdaptor.Fill(returnValue);
            }
            finally
            {
                command.Connection.Close();
                dataAdaptor.Dispose();
            }

            return returnValue;
        }
    }
}
