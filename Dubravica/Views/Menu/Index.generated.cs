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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Menu/Index.cshtml")]
    public partial class _Views_Menu_Index_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<UsersDiosna.Controllers.Notification>>
    {
        public _Views_Menu_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Menu\Index.cshtml"
  
    string alarmName = string.Empty;
    string graphName = string.Empty;
    ViewBag.Title = "Menu center";
    ViewBag.names = Session["names"];
    ViewBag.plc = Session["plc"];
    foreach (string name in ViewBag.names) {
        if(name.ToLower().Contains("alarm"))
        {
            alarmName = name;
        }
        if (name.ToLower().Contains("graph"))
        {
            graphName = name;
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<h4");

WriteLiteral(" id=\"instruction\"");

WriteLiteral(">&lAarr; Choose one link from the menu</h4>");

        }
    }
}
#pragma warning restore 1591
