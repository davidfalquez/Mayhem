using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Mayhem.DTO;

namespace Mayhem.Data
{
    public class Provider
    {
        SqlConnection _Connection;
        SqlCommand _Command;

        public void Dispatcher_Insert(Dispatcher input)
        {
            _Connection = new SqlConnection(@"Data Source=ZIBUDAB1\ZIBUDAB_SQL;Initial Catalog=Mayhem;User ID=sa;Password=king");
            _Connection.Open();

            _Command = new SqlCommand("Dispatcher_Insert", _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            _Command.Parameters.Add(new SqlParameter("@DispatcherId", input.DispatcherId));
            _Command.Parameters.Add(new SqlParameter("@FirstName", input.FirstName));
            _Command.Parameters.Add(new SqlParameter("@LastName", input.LastName));
            _Command.Parameters.Add(new SqlParameter("@PositionTypeId", input.PositionTypeId));
            _Command.Parameters.Add(new SqlParameter("@LoginId", input.LoginId));
            _Command.Parameters.Add(new SqlParameter("@LoginPassword", input.LoginPassword));
            _Command.Parameters.Add(new SqlParameter("@ValidUser", input.ValidUser));



            _Connection.Close();
        }

        public void Dispatcher_SelectByDispatcher(Dispatcher input)
        {
            _Connection = new SqlConnection(@"Data Source=ZIBUDAB1\ZIBUDAB_SQL;Initial Catalog=Mayhem;User ID=sa;Password=king");
            _Connection.Open();

            _Command = new SqlCommand("Dispatcher_SelectByDispatcherId", _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            _Command.Parameters.Add(new SqlParameter("@DispatcherId", input.DispatcherId));

            _Connection.Close();
        }

        public void Dispatcher_Update(Dispatcher input)
        {
            _Connection = new SqlConnection(@"Data Source=ZIBUDAB1\ZIBUDAB_SQL;Initial Catalog=Mayhem;User ID=sa;Password=king");
            _Connection.Open();

            _Command = new SqlCommand("Dispatcher_Update", _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            _Command.Parameters.Add(new SqlParameter("@DispatcherId", input.DispatcherId));
            _Command.Parameters.Add(new SqlParameter("@FirstName", input.FirstName));
            _Command.Parameters.Add(new SqlParameter("@LastName", input.LastName));
            _Command.Parameters.Add(new SqlParameter("@PositionTypeId", input.PositionTypeId));
            _Command.Parameters.Add(new SqlParameter("@LoginId", input.LoginId));
            _Command.Parameters.Add(new SqlParameter("@LoginPassword", input.LoginPassword));
            _Command.Parameters.Add(new SqlParameter("@ValidUser", input.ValidUser));

            _Connection.Close();
        }

    }
}
