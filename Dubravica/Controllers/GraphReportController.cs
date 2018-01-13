using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dubravica.GraphReport.Models;

namespace Dubravica.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GraphReportController : Controller
    {
        // GET: GraphReport
        public ActionResult Index()
        {
            return View();
        }
    }
}