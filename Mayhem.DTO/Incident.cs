using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class Incident
    {
        #region Fields

        private string _IncidentId;
        private PrimaryIncident _PrimaryIncidentId;
        private SecondaryIncident _SecondaryIncidentId;
        //To which table does the FK EvaluatorID belong?
        private string _EvaluatorId;
        private DateTime _EntryDate;
        private DateTime _LastUpdated;
        private int _PrimaryIncidentScore;
        private float _PrimaryIncidentScorePercent;
        private int _SecondaryIncidentScore;
        private float _SecondaryIncidentScorePercent;

        #endregion
        #region Properties

        public string IncidentId
        {
            get { return _IncidentId; }
            set { _IncidentId = value; }
        }

        public PrimaryIncident PrimaryIncidentId
        {
            get { return _PrimaryIncidentId; }
            set { _PrimaryIncidentId = value; }
        }

        public SecondaryIncident SecondaryIncidentId
        {
            get { return _SecondaryIncidentId; }
            set { _SecondaryIncidentId = value; }
        }

        //Change this to proper type
        public string EvaluatorId
        {
            get { return _EvaluatorId; }
            set { _EvaluatorId = value; }
        }

        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }

        public DateTime LastUpdated
        {
            get { return _LastUpdated; }
            set { _LastUpdated = value; }
        }

        public int PrimaryIncidentScore
        {
            get { return _PrimaryIncidentScore; }
            set { _PrimaryIncidentScore = value; }
        }

        public float PrimaryIncidentScorePercent
        {
            get { return _PrimaryIncidentScorePercent; }
            set { _PrimaryIncidentScorePercent = value; }
        }

        public int SecondaryIncidentScore
        {
            get { return _SecondaryIncidentScore; }
            set { _SecondaryIncidentScore = value; }
        }

        public float SecondaryIncidentScorePercent
        {
            get { return _SecondaryIncidentScorePercent; }
            set { _SecondaryIncidentScorePercent = value; }
        }

        #endregion
    }
}
