using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;
using Mayhem.WebUI.Models;

namespace Mayhem.WebUI.Controllers
{
    public class SiteUserController : Controller
    {
        //
        // GET: /SiteUser/

        [Authorize]
        public ActionResult Create(string dispatcherId)
        {
            LoginCredentials model = new LoginCredentials();
            model.Dispatcher = Provider.GetDispatcher(dispatcherId);
            model.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();


            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LoginCredentials model)
        {
            Provider.AddUser(model.Username, model.Password, model.IsValidUser, model.Dispatcher.DispatcherId);

            return View("../Dispatcher/Index", Logic.Provider.GetDispatchers());
        }

    }
}
