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
    
    #line 1 "..\..\Views\Report\_Form.cshtml"
    using Dubravica.Report.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Report/_Form.cshtml")]
    public partial class _Views_Report__Form_cshtml : System.Web.Mvc.WebViewPage<ReportModel>
    {
        public _Views_Report__Form_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css\"");

WriteLiteral(">\r\n<script");

WriteLiteral(" src=\"//code.jquery.com/jquery-1.10.2.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"//code.jquery.com/ui/1.11.4/jquery-ui.js\"");

WriteLiteral("></script>\r\n<script>\r\n\r\n    var windowHeight;\r\n\r\n    function windowWidth() {\r\n  " +
"      return $(window).width();\r\n    }\r\n\r\n    function windowHeight() {\r\n       " +
" //return window.innerHeight;\r\n        return $(window).height() - 130;\r\n    }\r\n" +
"\r\n    // add Event onResize and define method\r\n    if (window.attachEvent) {\r\n  " +
"      window.attachEvent(\'onresize\', function () {\r\n            alert(\'attachEve" +
"nt - resize\');\r\n        });\r\n    }\r\n    else if (window.addEventListener) {\r\n   " +
"     window.addEventListener(\'resize\', function () {\r\n            var id;\r\n     " +
"       $(window).resize(function () {\r\n                clearTimeout(id);\r\n      " +
"          id = setTimeout(RecalcCount(25), 500);\r\n            });\r\n        }, tr" +
"ue);\r\n    }\r\n    else {\r\n        //The browser does not support Javascript event" +
" binding\r\n    }\r\n\r\n    // disable or enable input\r\n    function InputEnable(el_s" +
", el_d) {\r\n        if ($(el_s).prop(\'checked\') == true) {\r\n            $(el_d).p" +
"rop(\"disabled\", false);\r\n        }\r\n        else {\r\n            console.log(\'fal" +
"se\');\r\n            $(el_d).prop(\"disabled\", true);\r\n            $(el_d).prop(\"va" +
"lue\", 0);\r\n        }\r\n    }\r\n\r\n    function InitReportFilter() {\r\n        InputE" +
"nable();\r\n    }\r\n\r\n    function RecalcCount(rowHeight) {\r\n        var count;\r\n  " +
"      count = Math.round((windowHeight() - $(\'.navbar\').height() - $(\'#top_menu\'" +
").height() - $(\'.message\').height() - $(\'footer\').height() - 25) / rowHeight);\r\n" +
"        return count;\r\n    }\r\n    $(\'#date-time_from\').datepicker();\r\n\r\n</script" +
">\r\n\r\n\r\n\r\n\r\n\r\n<div");

WriteLiteral(" onload=\"InitReportFilter()\"");

WriteLiteral(">\r\n    <!-- pozdeji onclick tlacitka v menu -->\r\n    <section");

WriteLiteral(" id=\"reportForm\"");

WriteLiteral(">\r\n");

            
            #line 70 "..\..\Views\Report\_Form.cshtml"
        
            
            #line default
            #line hidden
            
            #line 70 "..\..\Views\Report\_Form.cshtml"
         using (Html.BeginForm("Index", "Report", new { ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, new { role = "form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div>\r\n");

WriteLiteral("                ");

            
            #line 73 "..\..\Views\Report\_Form.cshtml"
           Write(Html.HiddenFor(model => model.StartId, new { @id = "start_id", @value = 0 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 74 "..\..\Views\Report\_Form.cshtml"
           Write(Html.HiddenFor(model => model.Count, new { @id = "count", @value = 60 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 76 "..\..\Views\Report\_Form.cshtml"
                
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Report\_Form.cshtml"
                   
                    int month = DateTime.Now.Month;
                    string smonth = DateTime.Now.Month.ToString();
                    int day = DateTime.Now.Day;
                    string sday = DateTime.Now.Day.ToString();

                    if (month<10)
                    {
                        smonth = "0" + smonth;
                    }
                    if (day < 10)
                    {
                        sday = "0" + day;
                    }
                    if(day == 1)
                    {
                        sday = "28";
                    }

                    string datetimeToValue = DateTime.Now.Year + "-" + smonth + "-" + sday + "T" + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    day--;
                    if (day < 10)
                    {
                        sday = "0" + day;
                    }
                    if (day == 1)
                    {
                        sday = "28";
                    }
                    string datetimeFromValue = DateTime.Now.Year + "-" + smonth + "-" + sday + "T" + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <!-- time from -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 110 "..\..\Views\Report\_Form.cshtml"
               Write(Html.LabelFor(model => model.DateTimeFormFrom));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 111 "..\..\Views\Report\_Form.cshtml"
               Write(Html.TextBoxFor(model => model.DateTimeFrom, new { @class = "date-time", id = "date-time_from", type="datetime-local", Value= @datetimeFromValue  }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- time to -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 115 "..\..\Views\Report\_Form.cshtml"
               Write(Html.LabelFor(model => model.DateTimeFormTo));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 116 "..\..\Views\Report\_Form.cshtml"
               Write(Html.TextBoxFor(model => model.DateTimeTo, new { @id = "date-time_to", @class = "date-time", @type = "datetime-local", Value = @datetimeToValue}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- rcp -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 120 "..\..\Views\Report\_Form.cshtml"
               Write(Html.LabelFor(model => model.Recipe));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 121 "..\..\Views\Report\_Form.cshtml"
               Write(Html.TextBoxFor(model => model.Recipe, new { @id = "recipe", @class = "rcp-in", @type = "number", @name = "recipe", @value = "0", @min = 0, @max = 30, @style = "width:50px;" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <!-- over Rcp limits -->\r\n             " +
"   <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"checkbox\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 126 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par0Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 127 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par0Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- amount" +
" -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 133 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par1Sel, new { @onchange = "InputEnable(this, tol1)" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 134 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par1Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol1\"");

WriteLiteral(">&plusmn</label>\r\n");

WriteLiteral("                        ");

            
            #line 138 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.Par1Tol, new { @id = "tol1", @class = "tol-set", @name = "tol1", @value = "0", @type = "number", @min = 0, @max = 10, @step = "0.1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span>kg</span>\r\n                    </div>\r\n\r\n        " +
"        </div>\r\n                <!-- temperature -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 146 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par2Sel, new { @onchange = "InputEnable(this, tol2)" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 147 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par2Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol2\"");

WriteLiteral(">&plusmn</label>\r\n");

WriteLiteral("                        ");

            
            #line 151 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.Par2Tol, new { @id = "tol2", @class = "tol-set", @name = "tol2", @value = "0", @type = "number", @min = 0, @max = 10, @step = "0.1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span>°C</span>\r\n                    </div>\r\n          " +
"      </div>\r\n                <!-- step time -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 158 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par3Sel, new { @onchange = "InputEnable(this, tol3)" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 159 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par3Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol3\"");

WriteLiteral(">&plusmn</label>\r\n");

WriteLiteral("                        ");

            
            #line 163 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.Par3Tol, new { @id = "tol3", @class = "tol-set", @name = "tol3", @value = "0", @type = "number", @min = 0, @max = 10, @step = "0.1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span>min</span>\r\n                    </div>\r\n         " +
"       </div>\r\n                <!-- interstep time -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 170 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par4Sel, new { @onchange = "InputEnable(this, tol4)" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 171 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par4Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol4\"");

WriteLiteral(">&plusmn</label>\r\n");

WriteLiteral("                        ");

            
            #line 175 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.Par4Tol, new { @id = "tol4", @class = "tol-set", @name = "tol4", @value = "0", @type = "number", @min = 0, @max = 10, @step = "0.1" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span>min</span>\r\n                    </div>\r\n         " +
"       </div>\r\n            </div>\r\n");

WriteLiteral("            <input");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"display: block; float: right; margin-left: 15px; padding: 2px 2px 2px 2px" +
";\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Submit\"");

WriteLiteral(" />\r\n");

            
            #line 181 "..\..\Views\Report\_Form.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </section>\r\n</div>");

        }
    }
}
#pragma warning restore 1591