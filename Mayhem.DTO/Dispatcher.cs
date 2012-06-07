using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Mayhem.DTO
{
    public class Dispatcher
    {
        #region Fields

        private string _DispatcherId;
        private string _FirstName;
        private string _LastName;
        private int _RoleTypeId;

        #endregion 
        #region Properties

        [Required(ErrorMessage = "Dispatcher ID is required.")]
        public string DispatcherId
        {
            get { return _DispatcherId; }
            set { _DispatcherId = value; }
        }

        [Required(ErrorMessage="First Name is Required.")]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int RoleTypeId
        {
            get { return _RoleTypeId; }
            set { _RoleTypeId = value; }
        }

        #endregion
    }
}
