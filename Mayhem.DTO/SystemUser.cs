using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.DTO
{
    public class SystemUser
    {
        public Dispatcher Dispatcher { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValid { get; set; }
    }
}
