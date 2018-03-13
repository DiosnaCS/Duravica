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
    
    #line 1 "..\..\Views\Report\_Overview.cshtml"
    using Dubravica.Report.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/_Overview.cshtml")]
    public partial class _Views_Report__Overview_cshtml : System.Web.Mvc.WebViewPage<ReportModel>
    {
        public _Views_Report__Overview_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Report\_Overview.cshtml"
  
    string statusClass = "status-default";
    string runningStyle = "";
    int i = 0;

            
            #line default
            #line hidden
WriteLiteral(@"
<script>
    function getBatch(id) {
        //var batchId = document.getElementById(""batchid"").textContent;
        //var recipeno = document.getElementById(""recipeno"").textContent;
        window.location = ""/Report/getBatch?batchid="" + id; //+ ""&recipeno="" + recipeno;
    }
</script>
");

WriteLiteral("\r\n");

            
            #line 16 "..\..\Views\Report\_Overview.cshtml"
 if (Model.Batches != null)
{
    if (Model.Batches.Count > 0)
    {
        int cancelledBatchesCount = Model.Batches.Count(p => p.batchStatus.HasFlag(StepStatus.Cancelled));
        int badBatchesCount = Model.Batches.Count(p => p.batchStatus.HasFlag(StepStatus.Error));

            
            #line default
            #line hidden
WriteLiteral("        <span>Batches filtered: ");

            
            #line 22 "..\..\Views\Report\_Overview.cshtml"
                           Write(Model.Batches.Count);

            
            #line default
            #line hidden
WriteLiteral("&ensp;</span>\r\n");

            
            #line 23 "..\..\Views\Report\_Overview.cshtml"
        
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Report\_Overview.cshtml"
         if (cancelledBatchesCount > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Cancelled batches: ");

            
            #line 25 "..\..\Views\Report\_Overview.cshtml"
                                Write(cancelledBatchesCount);

            
            #line default
            #line hidden
WriteLiteral(" </span>\r\n");

            
            #line 26 "..\..\Views\Report\_Overview.cshtml"
        }
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Report\_Overview.cshtml"
         
        
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Report\_Overview.cshtml"
         if (badBatchesCount > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <span>Cancelled batches: ");

            
            #line 29 "..\..\Views\Report\_Overview.cshtml"
                                Write(badBatchesCount);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 30 "..\..\Views\Report\_Overview.cshtml"
        }
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\Report\_Overview.cshtml"
         

            
            #line default
            #line hidden
WriteLiteral("        <table");

WriteLiteral(" class=\"table table-condensed table-bordered table-hover table-responsive\"");

WriteLiteral(">\r\n            <tr");

WriteLiteral(" style=\"background-color:silver;\"");

WriteLiteral(@">
                <th>Batch No.</th>
                <th>Start</th>
                <th>End</th>
                <th>Product</th>
                <th>Recipe</th>
                <th>Batch status</th>
                <th>Differences</th>
            </tr>

");

            
            #line 42 "..\..\Views\Report\_Overview.cshtml"
            
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Report\_Overview.cshtml"
             foreach (Batch batch in Model.Batches)
            {
                
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Report\_Overview.cshtml"
                                  
                if (batch.EndTime.Year < 2016 && !batch.batchStatus.HasFlag(StepStatus.Cancelled) &&
                    !batch.batchStatus.HasFlag(StepStatus.OK) && !batch.batchStatus.HasFlag(StepStatus.Error))
                {
                    runningStyle = "background-color: lightgreen;";
                }


            
            #line default
            #line hidden
WriteLiteral("                <tr");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1942), Tuple.Create("\"", 1971)
, Tuple.Create(Tuple.Create("", 1952), Tuple.Create("getBatch(", 1952), true)
            
            #line 51 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 1961), Tuple.Create<System.Object, System.Int32>(batch.Id
            
            #line default
            #line hidden
, 1961), false)
, Tuple.Create(Tuple.Create("", 1970), Tuple.Create(")", 1970), true)
);

WriteAttribute("style", Tuple.Create(" style=\"", 1972), Tuple.Create("\"", 2009)
, Tuple.Create(Tuple.Create("", 1980), Tuple.Create("cursor:", 1980), true)
, Tuple.Create(Tuple.Create(" ", 1987), Tuple.Create("pointer;", 1988), true)
            
            #line 51 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 1996), Tuple.Create<System.Object, System.Int32>(runningStyle
            
            #line default
            #line hidden
, 1996), false)
);

WriteLiteral(">\r\n");

            
            #line 52 "..\..\Views\Report\_Overview.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Report\_Overview.cshtml"
                      runningStyle = "";
            
            #line default
            #line hidden
WriteLiteral("\r\n                    <td");

WriteLiteral(" id=\"BatchNo\"");

WriteLiteral(">");

            
            #line 53 "..\..\Views\Report\_Overview.cshtml"
                                Write(batch.Id);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteAttribute("id", Tuple.Create(" id=\"", 2132), Tuple.Create("\"", 2147)
, Tuple.Create(Tuple.Create("", 2137), Tuple.Create("startDT_", 2137), true)
            
            #line 54 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 2145), Tuple.Create<System.Object, System.Int32>(i
            
            #line default
            #line hidden
, 2145), false)
);

WriteLiteral(">");

            
            #line 54 "..\..\Views\Report\_Overview.cshtml"
                                   Write(batch.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 55 "..\..\Views\Report\_Overview.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 55 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.EndTime.Year < 2016)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td>No end</td>\r\n");

            
            #line 58 "..\..\Views\Report\_Overview.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <td");

WriteAttribute("id", Tuple.Create(" id=\"", 2388), Tuple.Create("\"", 2401)
, Tuple.Create(Tuple.Create("", 2393), Tuple.Create("endDT_", 2393), true)
            
            #line 61 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 2399), Tuple.Create<System.Object, System.Int32>(i
            
            #line default
            #line hidden
, 2399), false)
);

WriteLiteral(">");

            
            #line 61 "..\..\Views\Report\_Overview.cshtml"
                                     Write(batch.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 62 "..\..\Views\Report\_Overview.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <td>");

            
            #line 63 "..\..\Views\Report\_Overview.cshtml"
                   Write(batch.RecipeName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" id=\"recipeno\"");

WriteLiteral(">");

            
            #line 64 "..\..\Views\Report\_Overview.cshtml"
                                 Write(batch.RecipeNo);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 65 "..\..\Views\Report\_Overview.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.batchStatus.HasFlag(StepStatus.OK))
                    {
                        statusClass = "status-ok";
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 69 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.batchStatus.HasFlag(StepStatus.Skipped) || batch.batchStatus.HasFlag(StepStatus.ForcedStart))
                    {
                        statusClass = "status-skipped";
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 73 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.batchStatus.HasFlag(StepStatus.Error) || batch.batchStatus.HasFlag(StepStatus.Cancelled))
                    {
                        statusClass = "status-nok";
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 77 "..\..\Views\Report\_Overview.cshtml"
                       string title = ""; 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 78 "..\..\Views\Report\_Overview.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 78 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.maxDiffAM != 0 || batch.minDiffAM != 0) { title += "Amount diff-" + "MAX: " + Math.Round((double)batch.maxDiffAM / 1000, 3) + "kg MIN: " + Math.Round((double)batch.minDiffAM / 1000, 3) + "kg \n"; }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 79 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.maxDiffTemp != 0 || batch.minDiffTemp != 0) { title += "Temperature diff-" + "MAX: " + Math.Round((double)batch.maxDiffTemp / 10, 1) + "°C MIN: " + Math.Round((double)batch.minDiffTemp / 10, 2) + "°C \n"; }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 80 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.maxDiffST != 0 || batch.minDiffST != 0) { title += "steptime diff- MAX: " + Math.Round((double)batch.maxDiffST / 60, 2) + "min MIN: " + Math.Round((double)batch.minDiffST / 60, 2) + "min \n"; }

            
            #line default
            #line hidden
WriteLiteral("                    ");

            
            #line 81 "..\..\Views\Report\_Overview.cshtml"
                     if (batch.maxDiffIST != 0 || batch.minDiffIST != 0) { title += "Inter step time diff- MAX: " + Math.Round((double)batch.maxDiffIST / 60, 2) + "min MIN: " + Math.Round((double)batch.minDiffIST / 60, 2) + "min \n"; }

            
            #line default
            #line hidden
WriteLiteral("                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 4171), Tuple.Create("\"", 4191)
            
            #line 82 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 4179), Tuple.Create<System.Object, System.Int32>(statusClass
            
            #line default
            #line hidden
, 4179), false)
);

WriteLiteral(">");

            
            #line 82 "..\..\Views\Report\_Overview.cshtml"
                                        Write(batch.batchStatus);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" data-toggle=\"tooltip\"");

WriteLiteral(" data-placement=\"top\"");

WriteAttribute("title", Tuple.Create(" title=\"", 4284), Tuple.Create("\"", 4298)
            
            #line 83 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 4292), Tuple.Create<System.Object, System.Int32>(title
            
            #line default
            #line hidden
, 4292), false)
);

WriteLiteral("><span>");

            
            #line 83 "..\..\Views\Report\_Overview.cshtml"
                                                                                   Write(batch.diffStatus);

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n                </tr>\r\n");

            
            #line 85 "..\..\Views\Report\_Overview.cshtml"
                i++;
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n");

            
            #line 88 "..\..\Views\Report\_Overview.cshtml"
    }
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div>\r\n        No data are present\r\n    </div>\r\n");

            
            #line 95 "..\..\Views\Report\_Overview.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"<script>
    function DateTime(date) {
        var offset = date.getTimezoneOffset();
        //console.log(offset);
        var offseted_miliseconds = date.getTime() - (offset * 60000);
        var DateTime = new Date(offseted_miliseconds);
        var localDateTime = DateTime.toLocaleString();
        return localDateTime;
    }
</script>
");

            
            #line 106 "..\..\Views\Report\_Overview.cshtml"
 for (int j = 0; j < Model.Batches.Count; j++)
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n            var year = ");

            
            #line 109 "..\..\Views\Report\_Overview.cshtml"
                  Write(Model.Batches[j].StartTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var month = ");

            
            #line 110 "..\..\Views\Report\_Overview.cshtml"
                   Write(Model.Batches[j].StartTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var day = ");

            
            #line 111 "..\..\Views\Report\_Overview.cshtml"
                 Write(Model.Batches[j].StartTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var hour = ");

            
            #line 112 "..\..\Views\Report\_Overview.cshtml"
                  Write(Model.Batches[j].StartTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var minute = ");

            
            #line 113 "..\..\Views\Report\_Overview.cshtml"
                    Write(Model.Batches[j].StartTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var second = ");

            
            #line 114 "..\..\Views\Report\_Overview.cshtml"
                    Write(Model.Batches[j].StartTime.Second);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var date = new Date(year, month - 1, day, hour, minute, second, 0)" +
";\r\n            var localDateTime = DateTime(date);\r\n            document.getElem" +
"entById(\"startDT_\" + \"");

            
            #line 117 "..\..\Views\Report\_Overview.cshtml"
                                             Write(j);

            
            #line default
            #line hidden
WriteLiteral("\").innerHTML = localDateTime;\r\n    </script>\r\n");

            
            #line 119 "..\..\Views\Report\_Overview.cshtml"

    if (Model.Batches[j].EndTime.Year > 2016)
    {

            
            #line default
            #line hidden
WriteLiteral("        <script>\r\n            var yearExp = ");

            
            #line 123 "..\..\Views\Report\_Overview.cshtml"
                     Write(Model.Batches[j].EndTime.Year);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var monthExp = ");

            
            #line 124 "..\..\Views\Report\_Overview.cshtml"
                      Write(Model.Batches[j].EndTime.Month);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var dayExp = ");

            
            #line 125 "..\..\Views\Report\_Overview.cshtml"
                    Write(Model.Batches[j].EndTime.Day);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var hourExp = ");

            
            #line 126 "..\..\Views\Report\_Overview.cshtml"
                     Write(Model.Batches[j].EndTime.Hour);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var minuteExp = ");

            
            #line 127 "..\..\Views\Report\_Overview.cshtml"
                       Write(Model.Batches[j].EndTime.Minute);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var secondExp = ");

            
            #line 128 "..\..\Views\Report\_Overview.cshtml"
                       Write(Model.Batches[j].EndTime.Second);

            
            #line default
            #line hidden
WriteLiteral(";\r\n            var expDate = new Date(yearExp, monthExp - 1, dayExp, hourExp, min" +
"uteExp, secondExp, 0);\r\n\r\n            var localExpDateTime = DateTime(expDate);\r" +
"\n            document.getElementById(\"endDT_\" + \"");

            
            #line 132 "..\..\Views\Report\_Overview.cshtml"
                                           Write(j);

            
            #line default
            #line hidden
WriteLiteral("\").innerHTML = localExpDateTime;\r\n        </script>\r\n");

            
            #line 134 "..\..\Views\Report\_Overview.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
