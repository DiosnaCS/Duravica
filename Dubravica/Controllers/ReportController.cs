﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Dubravica.Report.Models;
using Dubravica.Handlers;
using System.Linq;
using System.Text.RegularExpressions;

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
            ReportHelper reportHelper = new ReportHelper();
            ReportModel model = new ReportModel();
            model.RecipesNames = reportHelper.getRecipesNames(Session["DB"].ToString());
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(ReportModel model) {
            ViewBag.firstinit = false;
            ReportHelper reportHelper = new ReportHelper();
            ReportModel RVM; //(ReportModel)Session["model"];

            RVM = reportHelper.SelectReports(model, Session["DB"].ToString());
            int index = 0;
            uint[] batchIds = new uint[RVM.Batches.Count];
            //Check if there are some ranges of recipes numbers
            if (model.RecipesRanges != null)
            {
                if (model.RecipesNumbers == null) {
                    model.RecipesNumbers = new List<int>();
                }
                string[] ranges = model.RecipesRanges.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string range in ranges)
                {
                    string rangeTrimed = range.Trim();
                    int onlyNumber;
                    //solve single item if is it number
                    
                    if (int.TryParse(rangeTrimed, out onlyNumber) == true)
                    {
                        model.RecipesNumbers.Add(onlyNumber);
                    }
                    else
                    {
                        string[] twoNumbersString =  Regex.Split(rangeTrimed, @"\D");
                        int from, to;
                        if (int.TryParse(twoNumbersString[0], out from) == true && int.TryParse(twoNumbersString[1], out to) == true)
                        {
                            model.RecipesNumbers = Extension.AddRangeOfValues(model.RecipesNumbers, from, to);
                        }                        
                    }
                }
            }
            //Check if is set some recipe number which should be filtered
            if (model.RecipesNumbers != null || model.RecipesRanges != null)
            {
                if (model.RecipesNumbers == null)
                    model.RecipesNumbers = new List<int>();
                RVM.Batches = RVM.Batches.Where(p =>model.RecipesNumbers.Contains(p.RecipeNo) == true).ToList();
            }
            model.RecipesNumbers = null;
            ReportModel reportModelhHelper = (ReportModel)Session["model"];
            RVM.RecipesNames = reportModelhHelper.RecipesNames;
           
            foreach (Batch batch in RVM.Batches)
            {
                batchIds[index] = batch.Id;
                index++;
            }
            Session["batchesIds"] = batchIds;
            //ViewBag.RVM = RVM;
            Session["model"] = RVM;
            return View(RVM);
        }

        public ActionResult getBatch()
        {
            ViewBag.firstinit = false;
            int batchId = int.Parse(Request.QueryString["batchid"].ToString());
            ReportHelper reportHelper = new ReportHelper();
            ReportModel RVM = (ReportModel)Session["model"];
            //they are returned in the list of steps - BatchSteps
            ViewBag.Steps = reportHelper.getBatchData(batchId, Session["DB"].ToString());
            //they are returned in the list
            ViewBag.traceNumbers = ReportHelper.getTraceNumbers(batchId, Session["DB"].ToString());
            Session["model"] = RVM;
            return View("Index", RVM);
        }

    }
}