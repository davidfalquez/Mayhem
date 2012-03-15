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
    public class PrimaryIncidentEvaluatorReportController : Controller
    {
        //
        // GET: /EvaluatorReport/

        [Authorize]
        public ActionResult Index()
        {
            ReportDateRangeModel model = new ReportDateRangeModel();
            model.BeginDate = DateTime.Today;
            model.EndDate = DateTime.Today;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(ReportDateRangeModel model)
        {
            PrimaryIncidentDispatcherReport reportInfo = Provider.GetPrimaryIncidentEvaluatorReport(model.BeginDate, model.EndDate);

            return View("Report", reportInfo);
        }
    }
}
