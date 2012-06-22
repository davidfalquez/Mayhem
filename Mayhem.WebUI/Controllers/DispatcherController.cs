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
    public class DispatcherController : Controller
    {
        //
        // GET: /Dispatcher/

        [Authorize]
        public ActionResult Index()
        {
            List<DispatcherViewModel> modelList = GetDispatcherViewModels();
            return View(modelList);
        }

        internal static List<DispatcherViewModel> GetDispatcherViewModels()
        {
            List<DispatcherViewModel> returnValue = new List<DispatcherViewModel>();
            List<Dispatcher> dispatchers = Provider.GetDispatchers();

            foreach (Dispatcher dispatcher in dispatchers)
            {
                DispatcherViewModel viewModel = GetDispatcherViewModelFrom(dispatcher);
                //viewModel.RoleTypeDescription = Provider.GetRoleTypeDescription();
                returnValue.Add(viewModel);
            }
            

            return returnValue;
        }

        internal static DispatcherViewModel GetDispatcherViewModelFrom(Dispatcher dispatcher)
        {
            DispatcherViewModel returnValue = new DispatcherViewModel();

            returnValue.DispatcherId = dispatcher.DispatcherId;
            returnValue.FirstName = dispatcher.FirstName;
            returnValue.LastName = dispatcher.LastName;
            returnValue.RoleTypeId = dispatcher.RoleTypeId;
            returnValue.RoleTypeDescription = GetRoleTypeDescription(dispatcher.RoleTypeId, Provider.GetRoles());

            return returnValue;
        }

        internal static string GetRoleTypeDescription(int roleId, List<Role> list)
        {
            string returnValue = string.Empty;
            foreach (Role role in list)
            {
                if (role.RoleTypeId == roleId)
                {
                    returnValue = role.RoleTypeDescription;
                    break;
                }
            }

            return returnValue;
        }

        [Authorize]
        public ViewResult Edit(string dispatcherId)
        {
            DispatcherViewModel model = GetDispatcherViewModelFrom(Provider.GetDispatcher(dispatcherId));
            model.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ViewResult Edit(Dispatcher dispatcher)
        {
            //TODO: If we're going from a non-dispatcher role to a dispatcher, we should set IsValid = false for any login credentials this person has
            //And Vice-Versa
            if (ModelState.IsValid)
            {
                Provider.UpdateDispatcher(dispatcher);
                return View("Index", GetDispatcherViewModels());
            }
            else
            {
                DispatcherViewModel model = GetDispatcherViewModelFrom(dispatcher);
                model.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();
                return View(model);
            }
        }


        [Authorize]
        public ViewResult Create()
        {
            DispatcherViewModel model = new DispatcherViewModel();
            model.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ViewResult Create(DispatcherViewModel dispatcher)
        {
            //make sure the dispatcher doesn't already exist
            if (null != dispatcher && !string.IsNullOrEmpty(dispatcher.DispatcherId))
            {
                Dispatcher existingDispatcher = Provider.GetDispatcher(dispatcher.DispatcherId);
                if (null != existingDispatcher)
                {
                    ModelState.AddModelError("", "Dispatcher exists. Please enter a new Dispatcher ID.");
                    dispatcher.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();
                    return View(dispatcher);
                }
            }
            if (ModelState.IsValid)
            {
                Provider.CreateDispatcher((Dispatcher)dispatcher);
                return View("Index", GetDispatcherViewModels());
            }
            else
            {

                dispatcher.RoleTypeDropDown = DropDownUtility.GetRoleTypeDropDown();
                return View(dispatcher);
            }
        }

        [Authorize]
        public ViewResult Delete(string dispatcherId)
        {
            Provider.DeleteDispatcher(dispatcherId);
            return View("Index", GetDispatcherViewModels());
        }

    }
}
