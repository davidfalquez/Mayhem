using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage="Name is required.")]
        public string ChannelName
        {
            get { return _ChannelName; }
            set { _ChannelName = value; }
        }

        #endregion
    }
}
