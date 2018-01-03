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
WriteLiteral(@"<script>
    function getBatch(id) {
        //var batchId = document.getElementById(""batchid"").textContent;
        console.log(id);
        //var recipeno = document.getElementById(""recipeno"").textContent;
        window.location = ""/Report/getBatch?batchid="" + id; //+ ""&recipeno="" + recipeno;
    }
</script>
<div");

WriteLiteral(" class=\"ov-tab\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"table table-bordered thin-row\"");

WriteLiteral(">\r\n");

            
            #line 13 "..\..\Views\Report\_Overview.cshtml"
 
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Report\_Overview.cshtml"
   if (Model.Batches != null)
     {

            
            #line default
            #line hidden
WriteLiteral("        <tr>\r\n            <th");

WriteLiteral(" style=\"width: 65px\"");

WriteLiteral(">ID</th>\r\n            <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">Start</th>\r\n            <th");

WriteLiteral(" style=\"width: 155px\"");

WriteLiteral(">End</th>\r\n            <th>Product</th>\r\n            <th");

WriteLiteral(" style=\"width: 55px;\"");

WriteLiteral(">Recipe</th>\r\n            <th");

WriteLiteral(" style=\"width: 150px\"");

WriteLiteral(">Status</th>\r\n        </tr>\r\n");

            
            #line 23 "..\..\Views\Report\_Overview.cshtml"
            foreach (Batch batch in Model.Batches)
            {

            
            #line default
            #line hidden
WriteLiteral("        <tr");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 863), Tuple.Create("\"", 892)
, Tuple.Create(Tuple.Create("", 873), Tuple.Create("getBatch(", 873), true)
            
            #line 25 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 882), Tuple.Create<System.Object, System.Int32>(batch.Id
            
            #line default
            #line hidden
, 882), false)
, Tuple.Create(Tuple.Create("", 891), Tuple.Create(")", 891), true)
);

WriteLiteral(">\r\n            <td");

WriteLiteral(" id=\"\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Report\_Overview.cshtml"
                 Write(batch.Id);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 27 "..\..\Views\Report\_Overview.cshtml"
           Write(batch.StartTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 28 "..\..\Views\Report\_Overview.cshtml"
           Write(batch.EndTime);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td>");

            
            #line 29 "..\..\Views\Report\_Overview.cshtml"
           Write(batch.RecipeName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            <td");

WriteLiteral(" id=\"recipeno\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Report\_Overview.cshtml"
                         Write(batch.RecipeNo);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");

            
            #line 31 "..\..\Views\Report\_Overview.cshtml"
            
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Report\_Overview.cshtml"
               string title = ""; 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 32 "..\..\Views\Report\_Overview.cshtml"
            
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\Report\_Overview.cshtml"
             if (batch.maxDiffAM != 0) { title += " AmountMAXdiff: " + batch.maxDiffAM + " AmountMINdiff: " + batch.minDiffAM; }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 33 "..\..\Views\Report\_Overview.cshtml"
             if (batch.maxDiffTemp != 0) { title += " TempMAXdiff: " + batch.maxDiffTemp + " TempMINdiff: " + batch.minDiffTemp; }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 34 "..\..\Views\Report\_Overview.cshtml"
             if (batch.maxDiffST != 0) { title += "  StepTimeMAXdiff: " + batch.maxDiffST + " StepTimeMINdiff: " + batch.minDiffST; }

            
            #line default
            #line hidden
WriteLiteral("            ");

            
            #line 35 "..\..\Views\Report\_Overview.cshtml"
             if (batch.maxDiffIST != 0) { title += " InsterStepTimeMAXdiff: " + batch.maxDiffIST + " InterStepTimeMINdiff: " + batch.minDiffIST; }  

            
            #line default
            #line hidden
WriteLiteral("            <td");

WriteLiteral(" style=\"color: #ff0000;\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1725), Tuple.Create("\"", 1739)
            
            #line 36 "..\..\Views\Report\_Overview.cshtml"
, Tuple.Create(Tuple.Create("", 1733), Tuple.Create<System.Object, System.Int32>(title
            
            #line default
            #line hidden
, 1733), false)
);

WriteLiteral("><span><b>");

            
            #line 36 "..\..\Views\Report\_Overview.cshtml"
                                                           Write(batch.status);

            
            #line default
            #line hidden
WriteLiteral("</b></span></td>   \r\n        </tr>\r\n");

            
            #line 38 "..\..\Views\Report\_Overview.cshtml"
         }
        }
    
            
            #line default
            #line hidden
WriteLiteral("\r\n            ");

WriteLiteral("\r\n            ");

WriteLiteral("\r\n</table>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
