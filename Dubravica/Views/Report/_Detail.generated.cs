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

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h4>");

            
            #line 8 "..\..\Views\Report\_Detail.cshtml"
Write(ViewBag.TitleDetail);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 9 "..\..\Views\Report\_Detail.cshtml"
   if (ViewBag.Steps != null)
{

            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\"det-header\"");

WriteLiteral(">    \r\n    <p>Batch ID:<span>");

            
            #line 12 "..\..\Views\Report\_Detail.cshtml"
                 Write(ViewBag.Steps.Id);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>Bowl ID:<span>");

            
            #line 13 "..\..\Views\Report\_Detail.cshtml"
                Write(ViewBag.Steps.BowlId);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>Recipe:<span>");

            
            #line 14 "..\..\Views\Report\_Detail.cshtml"
               Write(ViewBag.Steps.RecipeNo);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 14 "..\..\Views\Report\_Detail.cshtml"
                                         Write(ViewBag.Steps.RecipeName);

            
            #line default
            #line hidden
WriteLiteral("</span></p>\r\n    <p>Time:<span>");

            
            #line 15 "..\..\Views\Report\_Detail.cshtml"
             Write(ViewBag.Steps.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</span>-<span>");

            
            #line 15 "..\..\Views\Report\_Detail.cshtml"
                                                   Write(ViewBag.Steps.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</span></p>    \r\n</div>\r\n");

            
            #line 17 "..\..\Views\Report\_Detail.cshtml"
} 
            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n    <table");

WriteLiteral(" class=\"table table-bordered thin-row det-tab\"");

WriteLiteral(">\r\n        <tr>\r\n            <th");

WriteLiteral(" style=\"width: 40px;\"");

WriteLiteral(">Step</th>            \r\n            <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">Start</th>\r\n            <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">End</th>\r\n            <th");

WriteLiteral(" style=\"width: 100px\"");

WriteLiteral(">Operation</th>\r\n            <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Device ID</th>\r\n            <th");

WriteLiteral(" style=\"min-width: 160px\"");

WriteLiteral(">Device Name</th>\r\n            <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Need</th>\r\n            <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Done</th>\r\n            <th");

WriteLiteral(" style=\"width: 105px\"");

WriteLiteral(">Diff</th>            \r\n            <th");

WriteLiteral(" style=\"width: 100px\"");

WriteLiteral(">Status</th>\r\n        </tr>\r\n");

            
            #line 32 "..\..\Views\Report\_Detail.cshtml"
   
    if (ViewBag.Steps != null) {
        int toElementUnits = 1;
        foreach (RecipeStep step in ViewBag.Steps.BatchSteps)
        {
            switch (step.OperationNr)
            {
                case OperationType.Dosing:
                    ViewBag.unit = "kg";
                    toElementUnits = 1000;
                    break;
                case OperationType.Kneading:
                    ViewBag.unit = "°C";
                    toElementUnits = 10;
                    break;
                case OperationType.Ripping:
                    ViewBag.unit = "min";
                    toElementUnits = 10;
                    break;
            }
            ViewBag.Need = step.Need /toElementUnits;
            ViewBag.Done = step.Done / toElementUnits;
            ViewBag.Diff = (step.Done - step.Need) / toElementUnits;
            switch (step.Status) {
                case StepStatus.OK:
                    ViewBag.statusClass = "status-ok";
                break;
                case StepStatus.Error:
                    ViewBag.statusClass = "status-nok";
                break;
            }

            
            #line default
            #line hidden
WriteLiteral("        <tr");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"left\"");

WriteLiteral(" title=\"Trace ID\"");

WriteLiteral(">\r\n            <td>");

            
            #line 64 "..\..\Views\Report\_Detail.cshtml"
           Write(step.step);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 65 "..\..\Views\Report\_Detail.cshtml"
           Write(step.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 66 "..\..\Views\Report\_Detail.cshtml"
           Write(step.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 67 "..\..\Views\Report\_Detail.cshtml"
           Write(step.OperationNr);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 68 "..\..\Views\Report\_Detail.cshtml"
           Write(step.DeviceId);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 69 "..\..\Views\Report\_Detail.cshtml"
           Write(step.Device);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(">");

            
            #line 70 "..\..\Views\Report\_Detail.cshtml"
                                                                         Write(ViewBag.Need);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 70 "..\..\Views\Report\_Detail.cshtml"
                                                                                       Write(ViewBag.unit);

            
            #line default
            #line hidden
WriteLiteral("&ensp;</td>\r\n            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\Report\_Detail.cshtml"
                              Write(ViewBag.Done);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 71 "..\..\Views\Report\_Detail.cshtml"
                                            Write(ViewBag.unit);

            
            #line default
            #line hidden
WriteLiteral("&ensp;</td>\r\n            <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 72 "..\..\Views\Report\_Detail.cshtml"
                              Write(ViewBag.Diff);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 72 "..\..\Views\Report\_Detail.cshtml"
                                            Write(ViewBag.unit);

            
            #line default
            #line hidden
WriteLiteral("&nbsp;</td>\r\n            <td");

WriteAttribute("class", Tuple.Create(" class=\"", 2859), Tuple.Create("\"", 2887)
            
            #line 73 "..\..\Views\Report\_Detail.cshtml"
, Tuple.Create(Tuple.Create("", 2867), Tuple.Create<System.Object, System.Int32>(ViewBag.statusClass
            
            #line default
            #line hidden
, 2867), false)
);

WriteLiteral(">");

            
            #line 73 "..\..\Views\Report\_Detail.cshtml"
                                        Write(step.Status);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        </tr>\r\n");

            
            #line 75 "..\..\Views\Report\_Detail.cshtml"
        }
        for (int i = 0; i<(ViewBag.Steps.StepsCount-ViewBag.Steps.BatchSteps.Count);i++)
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"left\"");

WriteLiteral(" title=\"Trace ID\"");

WriteLiteral(">\r\n                <td>&ensp;</td>\r\n                <td>&ensp;</td>\r\n            " +
"    <td>&ensp;</td>\r\n                <td>&ensp;</td>\r\n                <td>&ensp;" +
"</td>\r\n                <td>&ensp;</td>\r\n                <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteLiteral(">&ensp;</td>\r\n                <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n                <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">&ensp;</td>\r\n                <td");

WriteLiteral(" class=\"status-ok\"");

WriteLiteral(">&ensp;</td>\r\n            </tr>\r\n");

            
            #line 90 "..\..\Views\Report\_Detail.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");

WriteLiteral("\r\n    </table>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
