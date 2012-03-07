using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class PrimaryIncidentEvaluatorReportController : Controller
    {
        //
        // GET: /EvaluatorReport/

        public ActionResult Index()
        {
            return View(new PrimaryIncidentDispatcherReport());
        }

        public ActionResult ViewEvaluatorReport(PrimaryIncidentDispatcherReport reportInfo)
        {
            reportInfo = Provider.GetPrimaryIncidentEvaluatorReport(reportInfo.BeginDate, reportInfo.EndDate);

            return View(reportInfo);
        }
    }
}
