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

        public ActionResult Index()
        {
            return View(new PrimaryIncidentDispatcherReport());
        }

        public ActionResult ViewDispatcherReport(PrimaryIncidentDispatcherReport reportInfo)
        {
            reportInfo = Provider.GetPrimaryIncidentDispatcherReport(reportInfo.BeginDate, reportInfo.EndDate);

            return View(reportInfo);
        }

    }
}
