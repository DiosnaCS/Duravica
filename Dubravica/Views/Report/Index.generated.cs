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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/Index.cshtml")]
    public partial class _Views_Report_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Report_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Report\Index.cshtml"
  
    ViewBag.TitleReport = "Report of dough production";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"bootstrap-overrides\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(" data-spy=\"affix\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n\r\n            <h4>");

            
            #line 10 "..\..\Views\Report\Index.cshtml"
           Write(ViewBag.TitleReport);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

WriteLiteral("            ");

            
            #line 11 "..\..\Views\Report\Index.cshtml"
       Write(Html.Partial("_Form"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <br>\r\n            <br>\r\n        </div>\r\n    </div>\r\n");

            
            #line 16 "..\..\Views\Report\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Report\Index.cshtml"
     if (ViewBag.Steps != null)
    {
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Report\Index.cshtml"
   Write(Html.Partial("_Detail"));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Report\Index.cshtml"
                                
    }

            
            #line default
            #line hidden
WriteLiteral("    <hr>\r\n");

WriteLiteral("    ");

            
            #line 21 "..\..\Views\Report\Index.cshtml"
Write(Html.Partial("_Overview"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591
