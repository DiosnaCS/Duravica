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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Manage/AddPhoneNumber.cshtml")]
    public partial class _Views_Manage_AddPhoneNumber_cshtml : System.Web.Mvc.WebViewPage<Dubravica.Models.AddPhoneNumberViewModel>
    {
        public _Views_Manage_AddPhoneNumber_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Manage\AddPhoneNumber.cshtml"
  
    ViewBag.Title = "Phone Number";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 6 "..\..\Views\Manage\AddPhoneNumber.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n\r\n");

            
            #line 8 "..\..\Views\Manage\AddPhoneNumber.cshtml"
 using (Html.BeginForm("AddPhoneNumber", "Manage", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Manage\AddPhoneNumber.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Manage\AddPhoneNumber.cshtml"
                            

            
            #line default
            #line hidden
WriteLiteral("    <h4>Add a phone number</h4>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 13 "..\..\Views\Manage\AddPhoneNumber.cshtml"
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Manage\AddPhoneNumber.cshtml"
Write(Html.ValidationSummary("", new { @class = "text-danger" }));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Manage\AddPhoneNumber.cshtml"
                                                               

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 15 "..\..\Views\Manage\AddPhoneNumber.cshtml"
   Write(Html.LabelFor(m => m.Number, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Views\Manage\AddPhoneNumber.cshtml"
       Write(Html.TextBoxFor(m => m.Number, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Submit\"");

WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n");

            
            #line 25 "..\..\Views\Manage\AddPhoneNumber.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 28 "..\..\Views\Manage\AddPhoneNumber.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
