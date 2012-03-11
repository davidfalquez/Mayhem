using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mayhem.DTO;
using System.Web.Mvc;

namespace Mayhem.WebUI.Models
{
    public class DispatcherViewModel : Dispatcher
    {
        public SelectList RoleTypeDropDown { get; set; }
        public string RoleTypeDescription { get; set; }
    }
}