using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class PrimaryIncidentDispatcherReportController : Controller
    {
        //
        // GET: /DispatcherReport/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewDispatcherReport(DateTime beginDate, DateTime endDate)
        {
           PrimaryIncidentDispatcherReport reportInfo = Provider.GetPrimaryIncidentDispatcherReport(beginDate, endDate);

            return View(reportInfo);
        }

    }
}
