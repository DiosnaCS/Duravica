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
        //public static ReportModel RVM;
        public void DBConnnection()
        {
            string DB = string.Empty;
            string lang = string.Empty;
            int plcID = 1;
            foreach (string key in Session.Keys)
            {
                if (key.Contains("dbName" + Request.QueryString["name"] + Request.QueryString["plc"]))
                {
                    DB = Session[key].ToString();
                }
            }
            Session["DB"] = DB;
        }
        // GET: Report
        public ActionResult Index()
        {
            DBConnnection();
            //ReportModel RVM = new ReportModel();
            //VM = SelectReports(RVM);
            //ViewBag.RVM = RVM;
            ReportModel model = new ReportModel();
            ViewBag.firstinit = true;
            Session["model"] = model;
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
                csv = reportHelper.ToCSV(batchIds, Session["DB"].ToString());

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
            //DBConnnection();
            ViewBag.firstinit = false;
            ReportHelper reportHelper = new ReportHelper();
            ReportModel RVM = (ReportModel)Session["model"];

            RVM = reportHelper.SelectReports(model, Session["DB"].ToString());
            int index = 0;
            uint[] batchIds = new uint[RVM.Batches.Count];
            foreach (Batch batch in RVM.Batches)
            {
                batchIds[index] = batch.Id;
                index++;
            }
            Session["batchesIds"] = batchIds;
            ViewBag.RVM = RVM;
            Session["model"] = RVM;
            return View(RVM);
        }

        public ActionResult getBatch()
        {
            ViewBag.firstinit = false;
            int batchId = int.Parse(Request.QueryString["batchid"].ToString());
            ReportHelper reportHelper = new ReportHelper();
            ReportModel RVM = (ReportModel)Session["model"];
            ViewBag.Steps = reportHelper.getBatchData(batchId, Session["DB"].ToString());
            //they are returned in the list
            ViewBag.traceNumbers = ReportHelper.getTraceNumbers(batchId, Session["DB"].ToString());
            Session["model"] = RVM;
            return View("Index", RVM);
        }

    }
}