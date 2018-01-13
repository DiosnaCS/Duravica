using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dubravica.Report.Models;
using Dubravica.Handlers;

namespace Dubravica.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public static ReportModel RVM;
        // GET: Report
        public ActionResult Index()
        {
            //ReportModel RVM = new ReportModel();
            //VM = SelectReports(RVM);
            //ViewBag.RVM = RVM;
            ReportModel model = new ReportModel();
            ViewBag.firstinit = true;
            return View(model);
        }

        public void exportCSV()
        {
            string csv;
            uint[] batchIds = null;
            if (Session["batchesIds"] !=null)
            {
                batchIds = (uint[])Session["batchesIds"];
            }
            ReportHelper reportHelper = new ReportHelper();
            if (batchIds != null)
            {
                csv = reportHelper.ToCSV(batchIds);

                Response.AddHeader("Content-Length", csv.Length.ToString());
                Response.ContentType = "text/csv";
                Response.AppendHeader("content-disposition", "attachment;filename=\"exported_CSV.csv\"");

                Response.Write(csv);
                Response.End();
            } else
            {
                RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Index(ReportModel model) {
            ViewBag.firstinit = false;
            ReportHelper reportHelper = new ReportHelper();
            RVM = reportHelper.SelectReports(model);
            int index = 0;
            uint[] batchIds = new uint[RVM.Batches.Count];
            foreach (Batch batch in RVM.Batches)
            {
                batchIds[index] = batch.Id;
                index++;
            }
            Session["batchesIds"] = batchIds;
            ViewBag.RVM = RVM;
            return View(RVM);
        }

        public ActionResult getBatch()
        {
            ViewBag.firstinit = false;
            int batchId = int.Parse(Request.QueryString["batchid"].ToString());
            ReportHelper reportHelper = new ReportHelper();
            
            ViewBag.Steps = reportHelper.getBatchData(batchId);
            //they are returned in the list
            ViewBag.traceNumbers = ReportHelper.getTraceNumbers(batchId);
            return View("Index", RVM);
        }

    }
}