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
    using UsersDiosna;
    using UsersDiosna.Controllers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/XML/Index.cshtml")]
    public partial class _Views_XML_Index_cshtml : System.Web.Mvc.WebViewPage<UsersDiosna.File.Models.FileFormModel>
    {
        public _Views_XML_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\XML\Index.cshtml"
   
    ViewBag.Title = "XML Managment System(FMS)";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 6 "..\..\Views\XML\Index.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n");

            
            #line 8 "..\..\Views\XML\Index.cshtml"
Write(Html.ActionLink("Create XML File", "preXMLForm", "XML"));

            
            #line default
            #line hidden
WriteLiteral("<br>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\XML\Index.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
