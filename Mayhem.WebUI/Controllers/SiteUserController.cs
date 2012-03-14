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
        public ActionResult CreateOrUpdate(string dispatcherId)
        {
            string view = string.Empty;
            LoginCredentials model = new LoginCredentials();

            if (Provider.UserExists(dispatcherId))
            {
                view = "Edit";
                SystemUser user = Provider.GetUser(dispatcherId);
                model.Dispatcher = user.Dispatcher;
                model.IsValidUser = user.IsValid;
                model.Password = user.Password;
                model.Username = user.Username;
                model.Create = false;
            }
            else
            {
                view = "Create";
                model.Dispatcher = Provider.GetDispatcher(dispatcherId);
                model.IsValidUser = true;
                model.Create = true;
            }

            return View(view, model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateOrUpdate(LoginCredentials model)
        {
            if (model.Create)
            {
                Provider.AddUser(model.Username, model.Password, model.IsValidUser, model.Dispatcher.DispatcherId);
            }
            else
            {
                //This is an edit
                Provider.UpdateUser(model.Username, model.Password, model.IsValidUser);
            }
            return RedirectToAction("../Dispatcher/Index", DispatcherController.GetDispatcherViewModels());
        }

        [Authorize]
        public ActionResult Create(string dispatcherId)
        {
            LoginCredentials model = new LoginCredentials();
            model.Dispatcher = Provider.GetDispatcher(dispatcherId);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LoginCredentials model)
        {
            Provider.AddUser(model.Username, model.Password, model.IsValidUser, model.Dispatcher.DispatcherId);

            return RedirectToAction("../Dispatcher/Index", DispatcherController.GetDispatcherViewModels());
        }

        [Authorize]
        public ActionResult Edit(string dispatcherId)
        {
            LoginCredentials model = new LoginCredentials();
            model.Dispatcher = Provider.GetDispatcher(dispatcherId);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(LoginCredentials model)
        {
            Provider.UpdateUser(model.Username, model.Password, model.IsValidUser);
            return RedirectToAction("../Dispatcher/Index", DispatcherController.GetDispatcherViewModels());
        }

    }
}
