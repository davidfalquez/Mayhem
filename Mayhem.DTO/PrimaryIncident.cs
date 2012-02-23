using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class PrimaryIncident
    {
        #region Fields

        private int _PrimaryIncidentId;
        private Channel _ChannelId;
        private Dispatcher _DispatcherId;
        private Shift _ShiftId;
        private DateTime _DateTime;
        private bool _ToneAlertUsed;
        private bool _Priority;
        private bool _Sunstar3DigitUnit;
        private bool _Location;
        private bool _MapGrid;
        private bool _NatureOfCall;
        private bool _SsTacChannel;
        private bool _PertinentIntRouting;
        private bool _InfoGivenOutOfOrder;
        private string _DisplayedServiceAttitude;
        private string _UsedCorrectVolumeTone;
        private bool _UsedProhibitedBehavior;

        #endregion
        #region Properties

        public int PrimaryIncidentId
        {
            get { return _PrimaryIncidentId; }
            set { _PrimaryIncidentId = value; }
        }

        public Channel ChannelId
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }

        public Dispatcher DispatcherId
        {
            get { return _DispatcherId; }
            set { _DispatcherId = value; }
        }

        public Shift ShiftId
        {
            get { return _ShiftId; }
            set { _ShiftId = value; }
        }

        public DateTime DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        public bool ToneAlertUsed
        {
            get { return _ToneAlertUsed; }
            set { _ToneAlertUsed = value; }
        }

        public bool Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        public bool Sunstar3DigitUnit
        {
            get { return _Sunstar3DigitUnit; }
            set { _Sunstar3DigitUnit = value; }
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

        public bool SSTacChannel
        {
            get { return _SsTacChannel; }
            set { _SsTacChannel = value; }
        }

        public bool PertinentIntRouting
        {
            get { return _PertinentIntRouting; }
            set { _PertinentIntRouting = value; }
        }

        public bool InfoGivenOutOfOrder
        {
            get { return _InfoGivenOutOfOrder; }
            set { _InfoGivenOutOfOrder = value; }
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

        #endregion
    }
}
