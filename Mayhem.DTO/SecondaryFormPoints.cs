using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class SecondaryFormPoints
    {
        #region Fields

        private bool _SunstarThreeDigitUnit;
        private bool _NatureOfCall;
        private bool _Location;
        private bool _MapGrid;
        private bool _FdUnitAndTacCh;
        private bool _Documented1;
        private bool _SevMin;
        private bool _TwelveMin;
        private bool _EtaLocationAsked;
        private bool _Documented2;
        private string _ProactiveRoutingGiven;
        private string _CorrectRouting;
        private bool _Documented3;
        private bool _PreArrivalGiven;
        private bool _Documented4;
        private string _DisplayedServiceAttitude;
        private string _UsedCorrectVolTone;
        private bool _UsedProhibitedBehavior;

        #endregion
        //TODO: Use Mediator Patterns
        public SecondaryFormPoints(SecondaryIncident secondaryIncident)
        {
            _SunstarThreeDigitUnit = secondaryIncident.Sunstar3DigitUnit;
            _NatureOfCall = secondaryIncident.NatureOfCall;
            _Location = secondaryIncident.Location;
            _MapGrid = secondaryIncident.MapGrid;
            _FdUnitAndTacCh = secondaryIncident.FDUnitsAndTacCh;
            _Documented1 = secondaryIncident.ScriptingDocumented;
            _SevMin = secondaryIncident.SevenMin;
            _TwelveMin = secondaryIncident.TwelveMin;
            _EtaLocationAsked = secondaryIncident.ETALocationAsked;
            _Documented2 = secondaryIncident.ETADocumented;
            _ProactiveRoutingGiven = secondaryIncident.ProactiveRoutingGiven;
            _CorrectRouting = secondaryIncident.CorrectRouting;
            _Documented3 = secondaryIncident.RoutingDocumented;
            _PreArrivalGiven = secondaryIncident.PreArrivalGiven;
            _Documented4 = secondaryIncident.EMDDocumented;
            _DisplayedServiceAttitude = secondaryIncident.DisplayedServiceAttitude;
            _UsedCorrectVolTone = secondaryIncident.UsedCorrectVolumeTone;
            _UsedProhibitedBehavior = secondaryIncident.UsedProhibitedBehavior;
        }

        public SecondaryFormPoints()
        { 
        }

        #region Properties

        public bool SunstarThreeDigitUnit
        {
            get { return _SunstarThreeDigitUnit; }
            set { _SunstarThreeDigitUnit = value; }
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

        public bool FdUnitAndTacCh
        {
            get { return _FdUnitAndTacCh; }
            set { _FdUnitAndTacCh = value; }
        }

        public bool Documented1
        {
            get { return _Documented1; }
            set { _Documented1 = value; }
        }

        public bool SevMin
        {
            get { return _SevMin; }
            set { _SevMin = value; }
        }

        public bool TwelveMin
        {
            get { return _TwelveMin; }
            set { _TwelveMin = value; }
        }

        public bool EtaLocationAsked
        {
            get { return _EtaLocationAsked; }
            set { _EtaLocationAsked = value; }
        }

        public bool Documented2
        {
            get { return _Documented2; }
            set { _Documented2 = value; }
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

        public bool Documented3
        {
            get { return _Documented3; }
            set { _Documented3 = value; }
        }

        public bool PreArrivalGiven
        {
            get { return _PreArrivalGiven; }
            set { _PreArrivalGiven = value; }
        }

        public bool Documented4
        {
            get { return _Documented4; }
            set { _Documented4 = value; }
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
