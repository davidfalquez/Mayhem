using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class SecondaryIncident
    {
        #region Fields

        private int _SecondaryIncidentId;
        private Channel _Channel;
        private Dispatcher _Dispatcher;
        private Shift _Shift;
        private DateTime _DateTime;
        private bool _Sunstar3DigitUnit;
        private bool _NatureOfCall;
        private bool _Location;
        private bool _MapGrid;
        private bool _FDUnitsAndTacCh;
        private bool _ScriptingDocumented;
        private bool _SevenMin;
        private bool _TwelveMin;
        private bool _ETALocationAsked;
        private bool _ETADocumented;
        private string _ProactiveRoutingGiven;
        private string _CorrectRouting;
        private bool _RoutingDocumented;
        private bool _PreArrivalGiven;
        private bool _EMDDocumented;
        private string _DisplayedServiceAttitude;
        private string _UsedCorrectVolumeTone;
        private bool _UsedProhibitedBehavior;
        private bool _PatchedChannels;
        private bool _Phone;

        #endregion
        #region Properties

        public int SecondaryIncidentId
        {
            get { return _SecondaryIncidentId; }
            set { _SecondaryIncidentId = value; }
        }

        public Channel Channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }

        public Dispatcher Dispatcher
        {
            get { return _Dispatcher; }
            set { _Dispatcher = value; }
        }

        public Shift Shift
        {
            get { return _Shift; }
            set { _Shift = value; }
        }

        public DateTime DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        public bool Sunstar3DigitUnit
        {
            get { return _Sunstar3DigitUnit; }
            set { _Sunstar3DigitUnit = value; }
        }

        public bool NatureOfCall
        {
            get { return _NatureOfCall; }
            set { _NatureOfCall = value; }
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

        public bool FDUnitsAndTacCh
        {
            get { return _FDUnitsAndTacCh; }
            set { _FDUnitsAndTacCh = value; }
        }

        public bool ScriptingDocumented
        {
            get { return _ScriptingDocumented; }
            set { _ScriptingDocumented = value; }
        }

        public bool SevenMin
        {
            get { return _SevenMin; }
            set { _SevenMin = value; }
        }

        public bool TwelveMin
        {
            get { return _TwelveMin; }
            set { _TwelveMin = value; }
        }

        public bool ETALocationAsked
        {
            get { return _ETALocationAsked; }
            set { _ETALocationAsked = value; }
        }

        public bool ETADocumented
        {
            get { return _ETADocumented; }
            set { _ETADocumented = value; }
        }

        public string ProactiveRoutingGiven
        {
            get { return _ProactiveRoutingGiven; }
            set { _ProactiveRoutingGiven = value; }
        }

        public string CorrectRouting
        {
            get { return _CorrectRouting; }
            set { _CorrectRouting = value; }
        }

        public bool RoutingDocumented
        {
            get { return _RoutingDocumented; }
            set { _RoutingDocumented = value; }
        }

        public bool PreArrivalGiven
        {
            get { return _PreArrivalGiven; }
            set { _PreArrivalGiven = value; }
        }

        public bool EMDDocumented
        {
            get { return _EMDDocumented; }
            set { _EMDDocumented = value; }
        }

        public string DisplayedServiceAttitude
        {
            get { return _DisplayedServiceAttitude; }
            set { _DisplayedServiceAttitude = value; }
        }

        public string UsedCorrectVolumeTone
        {
            get { return _UsedCorrectVolumeTone; }
            set { _UsedCorrectVolumeTone = value; }
        }

        public bool UsedProhibitedBehavior
        {
            get { return _UsedProhibitedBehavior; }
            set { _UsedProhibitedBehavior = value; }
        }

        public bool PatchedChannels
        {
            get { return _PatchedChannels; }
            set { _PatchedChannels = value; }
        }

        public bool Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        #endregion
    }
}
