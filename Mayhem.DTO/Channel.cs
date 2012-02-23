using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class Channel
    {
        #region Fields

        private int _ChannelId;
        private string _ChannelName;

        #endregion
        #region Properties

        public int ChannelId
        {
            get { return _ChannelId; }
            set { _ChannelId = value; }
        }

        public string ChannelName
        {
            get { return _ChannelName; }
            set { _ChannelName = value; }
        }

        #endregion
    }
}
