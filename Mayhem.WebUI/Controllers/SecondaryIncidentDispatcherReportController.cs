using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class SecondaryIncidentDispatcherReportController : Controller
    {
        //
        // GET: /SecondaryIncidentDispatcherReport/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewDispatcherReport(DateTime beginDate, DateTime endDate)
        {
            SecondaryIncidentDispatcherReport reportInfo = Provider.GetSecondaryIncidentDispatcherReport(beginDate, endDate);

            return View(reportInfo);
        }
    }
}
