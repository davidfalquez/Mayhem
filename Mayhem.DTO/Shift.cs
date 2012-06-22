using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Mayhem.DTO
{
    public class Shift
    {
        #region Fields

        private int _ShiftId;
        private string _ShiftName;
        private string _ShiftAbbreviation;

        #endregion
        #region Properties

        public int ShiftId
        {
            get { return _ShiftId; }
            set { _ShiftId = value; }
        }

        [Required(ErrorMessage = "Shift Name is required.")]
        public string ShiftName
        {
            get { return _ShiftName;}
            set { _ShiftName = value; }
        }

        [Required(ErrorMessage="Shift Abbreviation is required.")]
        public string ShiftAbbreviation
        {
            get { return _ShiftAbbreviation; }
            set { _ShiftAbbreviation = value; }
        }

        #endregion
    }
}
