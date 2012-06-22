using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.Logic;
using Mayhem.DTO;

namespace Mayhem.WebUI.Controllers
{
    public class ShiftController : Controller
    {
        //
        // GET: /Shift/

        [Authorize]
        public ActionResult Index()
        {
            return View(Provider.GetShifts());
        }

        
        [Authorize]
        public ViewResult Create()
        { 
            return View(new Shift());
        }

        [Authorize]
        [HttpPost]
        public ViewResult Create(Shift shift)
        {
            if (ModelState.IsValid)
            {
                Provider.CreateShift(shift);
                return View("Index", Provider.GetShifts());
            }
            else
            {
                return View(shift);
            }
        }

        [Authorize]
        public ViewResult Edit(int shiftId)
        {
            return View(Provider.GetShift(shiftId));
        }

        [Authorize]
        [HttpPost]
        public ViewResult Edit(Shift shift)
        {
            if (ModelState.IsValid)
            {
                Provider.UpdateShift(shift);
                return View("Index", Provider.GetShifts());
            }
            else
            {
                return View(shift);
            }
        }

        [Authorize]
        public ViewResult Delete(int shiftId)
        {
            Provider.DeleteShift(shiftId);
            return View("Index", Provider.GetShifts());
        }
    }
}
