﻿using System;
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

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewEvaluatorReport(DateTime beginDate, DateTime endDate)
        {
            PrimaryIncidentDispatcherReport reportInfo = Provider.GetPrimaryIncidentEvaluatorReport(beginDate, endDate);

            return View(reportInfo);
        }
    }
}
