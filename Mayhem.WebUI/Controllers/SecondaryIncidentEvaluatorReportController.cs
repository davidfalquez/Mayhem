using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mayhem.DTO;
using Mayhem.Logic;

namespace Mayhem.WebUI.Controllers
{
    public class SecondaryIncidentEvaluatorReportController : Controller
    {
        //
        // GET: /SecondaryIncidentEvaluatorReport/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewEvaluatorReport(DateTime beginDate, DateTime endDate)
        {
            SecondaryIncidentDispatcherReport reportInfo = Provider.GetSecondaryIncidentEvaluatorReport(beginDate, endDate);

            return View(reportInfo);
        }
    }
}
