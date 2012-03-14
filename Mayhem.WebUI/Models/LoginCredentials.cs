using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mayhem.DTO;
using System.Web.Mvc;

namespace Mayhem.WebUI.Models
{
    public class LoginCredentials
    {
        public Dispatcher Dispatcher { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValidUser { get; set; }
        public bool Create { get; set; }
    }
}