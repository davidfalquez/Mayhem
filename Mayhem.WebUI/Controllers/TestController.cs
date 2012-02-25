using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.WebUI.Models;

namespace Mayhem.WebUI.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        

        public ActionResult Index()
        {
            return View(TestModelManager.GetTestModels());
        }

        public ViewResult Edit(string id)
        {
            return View(TestModelManager.GetTestModels()[0]);
        }

        [HttpPost]
        public ViewResult Edit(TestModel m)
        {
            List<TestModel> list = new List<TestModel>();
            list.Add(m);
            return View("Index", list);
        }

    }
}
