using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class DispatcherController : Controller
    {
        //
        // GET: /Dispatcher/

        [Authorize]
        public ActionResult Index()
        {
            return View(Provider.GetDispatchers());
        }

        [Authorize]
        public ViewResult Edit(string dispatcherId)
        {
            Dispatcher dispatcher = Provider.GetDispatcher(dispatcherId);
            return View(dispatcher);
        }

        [Authorize]
        [HttpPost]
        public ViewResult Edit(Dispatcher dispatcher)
        {
            Provider.UpdateDispatcher(dispatcher);
            return View("Index", Provider.GetDispatchers());
        }

        [Authorize]
        public ViewResult Create()
        {
            return View(new Dispatcher());
        }

        [Authorize]
        [HttpPost]
        public ViewResult Create(Dispatcher dispatcher)
        {
            Provider.CreateDispatcher(dispatcher);
            return View("Index", Provider.GetDispatchers());
        }

        [Authorize]
        public ViewResult Delete(string dispatcherId)
        {
            Provider.DeleteDispatcher(dispatcherId);
            return View("Index", Provider.GetDispatchers());
        }

    }
}
