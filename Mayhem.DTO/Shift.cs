using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string ShiftName
        {
            get { return _ShiftName;}
            set { _ShiftName = value; }
        }

        public string ShiftAbbreviation
        {
            get { return _ShiftAbbreviation; }
            set { _ShiftAbbreviation = value; }
        }

        #endregion
    }
}
