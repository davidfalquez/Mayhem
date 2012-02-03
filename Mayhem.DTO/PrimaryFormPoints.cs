using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    //Git!!!
    public class PrimaryFormPoints
    {
        #region Fields

        private bool _ToneAlertUsed;
        private bool _Priority;
        private bool _SunstarThreeDigitUnit;
        private bool _Location;
        private bool _MapGrid;
        private bool _NatureOfCall;
        private bool _SsTacChannel;
        private string _DisplayedServiceAttitude;
        private string _UsedCorrectVolTone;
        private bool _UsedProhibitedBehavior;

        #endregion
        #region Properties

        public bool ToneAlertUsed
        {
            get { return _ToneAlertUsed; }
            set { _ToneAlertUsed = value; }
        }

        public bool SunstarThreeDigitUnit
        {
            get { return _SunstarThreeDigitUnit; }
            set { _SunstarThreeDigitUnit = value; }
        }

        public bool Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        public bool Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        public bool MapGrid
        {
            get { return _MapGrid; }
            set { _MapGrid = value; }
        }

        public bool NatureOfCall
        {
            get { return _NatureOfCall; }
            set { _NatureOfCall = value; }
        }

        public bool SsTacChannel
        {
            get { return _SsTacChannel; }
            set { _SsTacChannel = value; }
        }

        public string DisplayedServiceAttitude
        {
            get { return _DisplayedServiceAttitude; }
            set { _DisplayedServiceAttitude = value; }
        }

        public string UsedCorrectVolTone
        {
            get { return _UsedCorrectVolTone; }
            set { _UsedCorrectVolTone = value; }
        }

        public bool UsedProhibitedBehavior
        {
            get { return _UsedProhibitedBehavior; }
            set { _UsedProhibitedBehavior = value; }
        }

        #endregion
    }
}
