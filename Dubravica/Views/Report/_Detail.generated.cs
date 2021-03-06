﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Dubravica;
    
    #line 1 "..\..\Views\Report\_Detail.cshtml"
    using Dubravica.Report.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/_Detail.cshtml")]
    public partial class _Views_Report__Detail_cshtml : System.Web.Mvc.WebViewPage<ReportModel>
    {
        public _Views_Report__Detail_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Report\_Detail.cshtml"
  
    ViewBag.TitleDetail = "Batch detail:";
    string unit = "";
    string statusClass = "";
    string traceToolpit = "";
    int tracePos = 0;
    int futureSteps = ViewBag.Steps.StepsCount - ViewBag.Steps.BatchSteps.Count;
    int doneSteps = ViewBag.Steps.BatchSteps.Count;
    double prePercent = (double)doneSteps / (double)ViewBag.Steps.StepsCount;
    double percent = prePercent*100;
    List<RecipeStep> steps = ViewBag.Steps.BatchSteps;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h4>");

            
            #line 16 "..\..\Views\Report\_Detail.cshtml"
Write(ViewBag.TitleDetail);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 17 "..\..\Views\Report\_Detail.cshtml"
   if (ViewBag.Steps != null)
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\"det-header\"");

WriteLiteral(">\r\n    <p>Batch ID:<span>");

            
            #line 20 "..\..\Views\Report\_Detail.cshtml"
                 Write(ViewBag.Steps.Id);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>Bowl ID:<span>");

            
            #line 21 "..\..\Views\Report\_Detail.cshtml"
                Write(ViewBag.Steps.BowlId);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>Recipe:<span>");

            
            #line 22 "..\..\Views\Report\_Detail.cshtml"
               Write(ViewBag.Steps.RecipeNo);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 22 "..\..\Views\Report\_Detail.cshtml"
                                         Write(ViewBag.Steps.RecipeName);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>\r\n        Time:<span");

WriteLiteral(" id=\"startBatchDT\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Report\_Detail.cshtml"
                                Write(ViewBag.Steps.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</span>-\r\n");

            
            #line 25 "..\..\Views\Report\_Detail.cshtml"
        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Report\_Detail.cshtml"
         if (ViewBag.Steps.EndTime.Year < 2016)
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>No end</span>\r\n");

            
            #line 28 "..\..\Views\Report\_Detail.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <span");

WriteLiteral(" id=\"endBatchDT\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Report\_Detail.cshtml"
                             Write(ViewBag.Steps.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 32 "..\..\Views\Report\_Detail.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </p>\r\n");

            
            #line 34 "..\..\Views\Report\_Detail.cshtml"
    
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\Report\_Detail.cshtml"
     if (steps.Exists(p => p.EndTime.Year < 2016))
    {
        
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Report\_Detail.cshtml"
          
            List<RecipeStep> notEndedSteps = steps.Where(p => p.EndTime.Year < 2016).ToList();
            RecipeStep currentStep = notEndedSteps[0];
        
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Report\_Detail.cshtml"
         

            
            #line default
            #line hidden
WriteLiteral("        <p>\r\n            Current step: <b>");

            
            #line 41 "..\..\Views\Report\_Detail.cshtml"
                        Write(currentStep.OperationNr.ToString());

            
            #line default
            #line hidden
WriteLiteral("</b>\r\n");

            
            #line 42 "..\..\Views\Report\_Detail.cshtml"
            
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Report\_Detail.cshtml"
             if (currentStep.OperationNr == OperationType.Ripping)
            {
                TimeSpan timeFromRcpStart = DateTime.Now - ViewBag.Steps.StartTime;
                TimeSpan timeToStepEnd = DateTime.Now - currentStep.StartTime;
                double elapsedMinutes = currentStep.Need - timeToStepEnd.TotalSeconds;
                percent = (elapsedMinutes / timeToStepEnd.TotalSeconds)*100;
                TimeSpan timeSpan = DateTime.Now - currentStep.StartTime;

                if (timeSpan.Ticks > 0 || currentStep.Need > Math.Abs(timeSpan.TotalSeconds))
                {

            
            #line default
            #line hidden
WriteLiteral("                          <div>Time elapsing:<span> ");

            
            #line 52 "..\..\Views\Report\_Detail.cshtml"
                                               Write(timeSpan.Hours);

            
            #line default
            #line hidden
WriteLiteral(" h ");

            
            #line 52 "..\..\Views\Report\_Detail.cshtml"
                                                                 Write(timeSpan.Minutes);

            
            #line default
            #line hidden
WriteLiteral(" min</span></div>\r\n");

            
            #line 53 "..\..\Views\Report\_Detail.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <span");

WriteLiteral(" style=\"color: orangered;\"");

WriteLiteral(">Batch is over time: ");

            
            #line 56 "..\..\Views\Report\_Detail.cshtml"
                                                                   Write(timeSpan.Hours);

            
            #line default
            #line hidden
WriteLiteral(" h ");

            
            #line 56 "..\..\Views\Report\_Detail.cshtml"
                                                                                     Write(timeSpan.Minutes);

            
            #line default
            #line hidden
WriteLiteral(" min</span>\r\n");

            
            #line 57 "..\..\Views\Report\_Detail.cshtml"
                }
            }

            
            #line default
            #line hidden
WriteLiteral("        </p>\r\n");

            
            #line 60 "..\..\Views\Report\_Detail.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 61 "..\..\Views\Report\_Detail.cshtml"
     if (ViewBag.steps.EndTime.Year < 2016 && Model.Batches.Exists(p => p.RecipeNo == ViewBag.Steps.RecipeNo))
    {
            
            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Report\_Detail.cshtml"
                var lastSameRcp = Model.Batches.First(p => p.RecipeNo == ViewBag.Steps.RecipeNo).EndTime;
                TimeSpan lastTimeSpan = Model.Batches.First(p => p.RecipeNo == ViewBag.Steps.RecipeNo).EndTime - Model.Batches.First(p => p.RecipeNo == ViewBag.Steps.RecipeNo).StartTime;
                TimeSpan currElepsingTime = DateTime.Now - ViewBag.steps.StartTime;
                TimeSpan predictedTime = currElepsingTime - lastTimeSpan;    
            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\Report\_Detail.cshtml"
                                                                              

            
            #line default
            #line hidden
WriteLiteral("        <p>Estimated time elapsing: <span>");

            
            #line 67 "..\..\Views\Report\_Detail.cshtml"
                                     Write(predictedTime.Hours);

            
            #line default
            #line hidden
WriteLiteral(" h ");

            
            #line 67 "..\..\Views\Report\_Detail.cshtml"
                                                            Write(predictedTime.Minutes);

            
            #line default
            #line hidden
WriteLiteral(" min ");

            
            #line 67 "..\..\Views\Report\_Detail.cshtml"
                                                                                       Write(predictedTime.Seconds);

            
            #line default
            #line hidden
WriteLiteral(" s   (according to last batch with this recipe number)</span></p>\r\n");

            
            #line 68 "..\..\Views\Report\_Detail.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 70 "..\..\Views\Report\_Detail.cshtml"
} 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n<div");

WriteLiteral(" class=\"progress\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"progress-bar\"");

WriteLiteral(" role=\"progressbar\"");

WriteAttribute("style", Tuple.Create(" style=\"", 3219), Tuple.Create("\"", 3256)
, Tuple.Create(Tuple.Create("", 3227), Tuple.Create("width:", 3227), true)
            
            #line 73 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create(" ", 3233), Tuple.Create<System.Object, System.Int32>(Math.Round(percent)
            
            #line default
            #line hidden
, 3234), false)
, Tuple.Create(Tuple.Create("", 3254), Tuple.Create("%;", 3254), true)
);

WriteLiteral(" aria-valuenow=\"0\"");

WriteLiteral(" aria-valuemin=\"0\"");

WriteLiteral(" aria-valuemax=\"100\"");

WriteLiteral(">");

            
            #line 73 "..\..\Views\Report\_Detail.cshtml"
                                                                                                                                          Write(Math.Round(percent));

            
            #line default
            #line hidden
WriteLiteral(" %</div>\r\n</div>\r\n<table");

WriteLiteral(" class=\"table table-bordered thin-row det-tab\"");

WriteLiteral(">\r\n    <tr>\r\n        <th");

WriteLiteral(" style=\"width: 40px;\"");

WriteLiteral(">Step</th>\r\n        <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">Start</th>\r\n        <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">End</th>\r\n        <th");

WriteLiteral(" style=\"width: 100px\"");

WriteLiteral(">Operation</th>\r\n        <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Device ID</th>\r\n        <th");

WriteLiteral(" style=\"min-width: 160px\"");

WriteLiteral(">Device Name</th>\r\n        <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Need</th>\r\n        <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Done</th>\r\n        <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Diff</th>\r\n        <th");

WriteLiteral(" style=\"width: 100px\"");

WriteLiteral(">Status</th>\r\n    </tr>\r\n");

            
            #line 88 "..\..\Views\Report\_Detail.cshtml"
    
            
            #line default
            #line hidden
            
            #line 88 "..\..\Views\Report\_Detail.cshtml"
      
        if (ViewBag.Steps != null)
        {
            int toElementUnits = 1;
            int id = 0;
            foreach (RecipeStep step in ViewBag.Steps.BatchSteps)
            {
                traceToolpit = "";
                switch (step.OperationNr)
                {
                    case OperationType.Dosing:
                        if (ViewBag.traceNumbers.Count > tracePos && ViewBag.traceNumbers.Count > 0)
                        {
                            traceToolpit = "Trace ID:" + ViewBag.traceNumbers[tracePos];
                            tracePos++;
                        }
                        unit = "kg";
                        toElementUnits = 1000;
                        break;
                    case OperationType.Kneading:
                        unit = "°C";
                        toElementUnits = 10;
                        break;
                    case OperationType.Ripping:
                        unit = "min";
                        toElementUnits = 60;
                        break;
                }
                double need = (double)step.Need / (double)toElementUnits;
                need = Math.Round(need, 2);
                double done = (double)step.Done / (double)toElementUnits;
                done = Math.Round(done, 2);
                double diff = (double)(step.Done - step.Need) / (double)toElementUnits;
                diff = Math.Round(diff, 2);
                if (step.Status.HasFlag(StepStatus.OK))
                {
                    statusClass = "status-ok";
                }
                if (step.Status.HasFlag(StepStatus.Skipped) || step.Status.HasFlag(StepStatus.ForcedStart))
                {
                    statusClass = "status-warning";
                }
                if (step.Status.HasFlag(StepStatus.Cancelled) || step.Status.HasFlag(StepStatus.Error))
                {
                    statusClass = "status-error";
                }

            
            #line default
            #line hidden
WriteLiteral("                <tr");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5965), Tuple.Create("\"", 5986)
            
            #line 134 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create("", 5973), Tuple.Create<System.Object, System.Int32>(traceToolpit
            
            #line default
            #line hidden
, 5973), false)
);

WriteLiteral(">\r\n                    <td>");

            
            #line 135 "..\..\Views\Report\_Detail.cshtml"
                   Write(step.step);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteAttribute("id", Tuple.Create(" id=\"", 6054), Tuple.Create("\"", 6072)
, Tuple.Create(Tuple.Create("", 6059), Tuple.Create("startStep_", 6059), true)
            
            #line 136 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create("", 6069), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 6069), false)
);

WriteLiteral(">");

            
            #line 136 "..\..\Views\Report\_Detail.cshtml"
                                      Write(step.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 137 "..\..\Views\Report\_Detail.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\Report\_Detail.cshtml"
                     if (step.EndTime.Year < 2016)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td><b>No end</b></td>\r\n");

            
            #line 140 "..\..\Views\Report\_Detail.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteAttribute("id", Tuple.Create(" id=\"", 6318), Tuple.Create("\"", 6334)
, Tuple.Create(Tuple.Create("", 6323), Tuple.Create("endStep_", 6323), true)
            
            #line 143 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create("", 6331), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 6331), false)
);

WriteLiteral(">");

            
            #line 143 "..\..\Views\Report\_Detail.cshtml"
                                        Write(step.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 144 "..\..\Views\Report\_Detail.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <td>");

            
            #line 145 "..\..\Views\Report\_Detail.cshtml"
                   Write(step.OperationNr);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 146 "..\..\Views\Report\_Detail.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 146 "..\..\Views\Report\_Detail.cshtml"
                     if (step.DeviceId != 0)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td>");

            
            #line 148 "..\..\Views\Report\_Detail.cshtml"
                       Write(step.DeviceId);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 149 "..\..\Views\Report\_Detail.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td></td>\r\n");

            
            #line 153 "..\..\Views\Report\_Detail.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <td>");

            
            #line 154 "..\..\Views\Report\_Detail.cshtml"
                   Write(step.Device);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 155 "..\..\Views\Report\_Detail.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 155 "..\..\Views\Report\_Detail.cshtml"
                     if (step.OperationNr == OperationType.Tipping)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n");

            
            #line 158 "..\..\Views\Report\_Detail.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 161 "..\..\Views\Report\_Detail.cshtml"
                                          Write(need);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 161 "..\..\Views\Report\_Detail.cshtml"
                                                Write(unit);

            
            #line default
            #line hidden
WriteLiteral("&ensp;</td>\r\n");

            
            #line 162 "..\..\Views\Report\_Detail.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 163 "..\..\Views\Report\_Detail.cshtml"
                     if (step.EndTime.Year < 2016)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral("><b>Not done yet</b></td>\r\n");

            
            #line 166 "..\..\Views\Report\_Detail.cshtml"
                    }
                    else
                    {
                        if (step.OperationNr == OperationType.Tipping) {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n");

            
            #line 171 "..\..\Views\Report\_Detail.cshtml"
                        } else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 173 "..\..\Views\Report\_Detail.cshtml"
                                              Write(done);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 173 "..\..\Views\Report\_Detail.cshtml"
                                                    Write(unit);

            
            #line default
            #line hidden
WriteLiteral("&ensp;</td>\r\n");

            
            #line 174 "..\..\Views\Report\_Detail.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 176 "..\..\Views\Report\_Detail.cshtml"
                     if (step.EndTime.Year < 2016)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral("><b>Not done yet</b></td>\r\n");

            
            #line 179 "..\..\Views\Report\_Detail.cshtml"
                    }
                    else
                    {
                        if (diff != 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 184 "..\..\Views\Report\_Detail.cshtml"
                                              Write(diff);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 184 "..\..\Views\Report\_Detail.cshtml"
                                                    Write(unit);

            
            #line default
            #line hidden
WriteLiteral("&nbsp;</td>\r\n");

            
            #line 185 "..\..\Views\Report\_Detail.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral("></td>\r\n");

            
            #line 189 "..\..\Views\Report\_Detail.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 8151), Tuple.Create("\"", 8171)
            
            #line 191 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create("", 8159), Tuple.Create<System.Object, System.Int32>(statusClass
            
            #line default
            #line hidden
, 8159), false)
);

WriteLiteral(">");

            
            #line 191 "..\..\Views\Report\_Detail.cshtml"
                                        Write(step.Status);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                </tr>\r\n");

            
            #line 193 "..\..\Views\Report\_Detail.cshtml"
                id++;
            }
            for (int j = 0; j < (futureSteps); j++)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(" title=\"Expected step\"");

WriteLiteral(">\r\n                    <td>&ensp;</td>\r\n                    <td>&ensp;</td>\r\n    " +
"                <td>&ensp;</td>\r\n                    <td>&ensp;</td>\r\n          " +
"          <td>&ensp;</td>\r\n                    <td>&ensp;</td>\r\n                " +
"    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(">&ensp;</td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n                    <td");

WriteLiteral(" class=\"status-ok\"");

WriteLiteral(">&ensp;</td>\r\n                </tr>\r\n");

            
            #line 209 "..\..\Views\Report\_Detail.cshtml"
            }
        }
    
            
            #line default
            #line hidden
WriteLiteral(@"
</table>
<script>
    function DateTime(date) {
        var offset = date.getTimezoneOffset();
        console.log(offset);
        var offseted_miliseconds = date.getTime() - (offset * 60000);
        var DateTime = new Date(offseted_miliseconds);
        var localDateTime = DateTime.toLocaleString();
        return localDateTime;
    }
    var yearStartBatch = ");

            
            #line 222 "..\..\Views\Report\_Detail.cshtml"
                    Write(ViewBag.Steps.StartTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n    var monthStartBatch = ");

            
            #line 223 "..\..\Views\Report\_Detail.cshtml"
                     Write(ViewBag.Steps.StartTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n    var dayStartBatch = ");

            
            #line 224 "..\..\Views\Report\_Detail.cshtml"
                   Write(ViewBag.Steps.StartTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n    var hourStartBatch = ");

            
            #line 225 "..\..\Views\Report\_Detail.cshtml"
                    Write(ViewBag.Steps.StartTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n    var minuteStartBatch = ");

            
            #line 226 "..\..\Views\Report\_Detail.cshtml"
                      Write(ViewBag.Steps.StartTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n    var secondStartBatch = ");

            
            #line 227 "..\..\Views\Report\_Detail.cshtml"
                      Write(ViewBag.Steps.StartTime.Second);

            
            #line default
            #line hidden
WriteLiteral(@";
    var dateStartBatch = new Date(yearStartBatch, monthStartBatch - 1, dayStartBatch, hourStartBatch, minuteStartBatch, secondStartBatch, 0);
    var localStartBatch = DateTime(dateStartBatch);
    console.log(localStartBatch);
    document.getElementById(""startBatchDT"").innerHTML = localStartBatch;
</script>
");

            
            #line 233 "..\..\Views\Report\_Detail.cshtml"
 if (ViewBag.Steps.EndTime.Year > 2016)
{

            
            #line default
            #line hidden
WriteLiteral("<script>\r\n        var yearEndBatch = ");

            
            #line 236 "..\..\Views\Report\_Detail.cshtml"
                      Write(ViewBag.Steps.EndTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var monthEndBatch = ");

            
            #line 237 "..\..\Views\Report\_Detail.cshtml"
                       Write(ViewBag.Steps.EndTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var dayEndBatch = ");

            
            #line 238 "..\..\Views\Report\_Detail.cshtml"
                     Write(ViewBag.Steps.EndTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var hourEndBatch = ");

            
            #line 239 "..\..\Views\Report\_Detail.cshtml"
                      Write(ViewBag.Steps.EndTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var minuteEndBatch = ");

            
            #line 240 "..\..\Views\Report\_Detail.cshtml"
                        Write(ViewBag.Steps.EndTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var secondEndBatch = ");

            
            #line 241 "..\..\Views\Report\_Detail.cshtml"
                        Write(ViewBag.Steps.EndTime.Second);

            
            #line default
            #line hidden
WriteLiteral(@";
        var dateEndBatch = new Date(yearEndBatch, monthEndBatch - 1, dayEndBatch, hourEndBatch, minuteEndBatch, secondEndBatch, 0);
        var localEndBatch = DateTime(dateEndBatch);
        console.log(localEndBatch);
        document.getElementById(""endBatchDT"").innerHTML = localEndBatch;
</script>
");

            
            #line 247 "..\..\Views\Report\_Detail.cshtml"
}

            
            #line default
            #line hidden
            
            #line 248 "..\..\Views\Report\_Detail.cshtml"
  int i = 0; 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 249 "..\..\Views\Report\_Detail.cshtml"
 foreach (RecipeStep step in ViewBag.Steps.BatchSteps)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        var year = ");

            
            #line 252 "..\..\Views\Report\_Detail.cshtml"
              Write(step.StartTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var month = ");

            
            #line 253 "..\..\Views\Report\_Detail.cshtml"
               Write(step.StartTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var day = ");

            
            #line 254 "..\..\Views\Report\_Detail.cshtml"
             Write(step.StartTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var hour = ");

            
            #line 255 "..\..\Views\Report\_Detail.cshtml"
              Write(step.StartTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var minute = ");

            
            #line 256 "..\..\Views\Report\_Detail.cshtml"
                Write(step.StartTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var second = ");

            
            #line 257 "..\..\Views\Report\_Detail.cshtml"
                Write(step.StartTime.Second);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var date = new Date(year, month - 1, day, hour, minute, second, 0);\r\n " +
"       var localDateTime = DateTime(date);\r\n        console.log(localDateTime);\r" +
"\n        document.getElementById(\"startStep_\" + \"");

            
            #line 261 "..\..\Views\Report\_Detail.cshtml"
                                           Write(i);

            
            #line default
            #line hidden
WriteLiteral("\").innerHTML = localDateTime;\r\n    </script>\r\n");

            
            #line 263 "..\..\Views\Report\_Detail.cshtml"
    
            
            #line default
            #line hidden
            
            #line 263 "..\..\Views\Report\_Detail.cshtml"
     if (step.EndTime.Year > 2016)
    {

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        var yearExp = ");

            
            #line 266 "..\..\Views\Report\_Detail.cshtml"
                 Write(step.EndTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var monthExp = ");

            
            #line 267 "..\..\Views\Report\_Detail.cshtml"
                  Write(step.EndTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var dayExp = ");

            
            #line 268 "..\..\Views\Report\_Detail.cshtml"
                Write(step.EndTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var hourExp = ");

            
            #line 269 "..\..\Views\Report\_Detail.cshtml"
                 Write(step.EndTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var minuteExp = ");

            
            #line 270 "..\..\Views\Report\_Detail.cshtml"
                   Write(step.EndTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var secondExp = ");

            
            #line 271 "..\..\Views\Report\_Detail.cshtml"
                   Write(step.EndTime.Second);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var expDate = new Date(yearExp, monthExp - 1, dayExp, hourExp, minuteE" +
"xp, secondExp, 0);\r\n\r\n        var localExpDateTime = DateTime(expDate);\r\n       " +
" document.getElementById(\"endStep_\" + \"");

            
            #line 275 "..\..\Views\Report\_Detail.cshtml"
                                         Write(i);

            
            #line default
            #line hidden
WriteLiteral("\").innerHTML = localExpDateTime;\r\n    </script>\r\n");

            
            #line 277 "..\..\Views\Report\_Detail.cshtml"
    }
            
            #line default
            #line hidden
            
            #line 277 "..\..\Views\Report\_Detail.cshtml"
     
    i++;
}

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n<script>\r\n    var pxFromTop = document.getElementById(\"batchRow_\" + ");

            
            #line 282 "..\..\Views\Report\_Detail.cshtml"
                                                      Write(ViewBag.Steps.Id+1);

            
            #line default
            #line hidden
WriteLiteral(").offsetTop;\r\n    console.log(pxFromTop);\r\n    var absoulteOffset = pxFromTop + 5" +
"00;\r\n    console.log(absoulteOffset);\r\n    window.scrollTo(0, pxFromTop);\r\n</scr" +
"ipt>\r\n");

        }
    }
}
#pragma warning restore 1591
