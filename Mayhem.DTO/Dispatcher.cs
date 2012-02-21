using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class Dispatcher
    {
        #region Fields

        private string _DispatcherId;
        private string _FirstName;
        private string _LastName;
        private int _PositionTypeId;
        private string _LoginId;
        private string _LoginPassword;
        private bool _ValidUser;

        #endregion 
        #region Properties

        public string DispatcherId
        {
            get { return _DispatcherId; }
            set { _DispatcherId = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int PositionTypeId
        {
            get { return _PositionTypeId; }
            set { _PositionTypeId = value; }
        }

        public string LoginId
        {
            get { return _LoginId; }
            set { _LoginId = value; }
        }

        public string LoginPassword
        {
            get { return _LoginPassword; }
            set { _LoginPassword = value; }
        }

        public bool ValidUser
        {
            get { return _ValidUser; }
            set { _ValidUser = value; }
        }

        #endregion
    }
}
