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
"      return $(window).width();\r\n    }\r\n\r\n    function closeDataModal() {\r\n     " +
"   $(\'#exportModal\').modal(\'hide\');\r\n    }\r\n\r\n    function windowHeight() {\r\n   " +
"     //return window.innerHeight;\r\n        return $(window).height() - 130;\r\n   " +
" }\r\n\r\n    // add Event onResize and define method\r\n    if (window.attachEvent) {" +
"\r\n        window.attachEvent(\'onresize\', function () {\r\n            alert(\'attac" +
"hEvent - resize\');\r\n        });\r\n    }\r\n    else if (window.addEventListener) {\r" +
"\n        window.addEventListener(\'resize\', function () {\r\n            var id;\r\n " +
"           $(window).resize(function () {\r\n                clearTimeout(id);\r\n  " +
"              id = setTimeout(RecalcCount(25), 500);\r\n            });\r\n        }" +
", true);\r\n    }\r\n    else {\r\n        //The browser does not support Javascript e" +
"vent binding\r\n    }\r\n\r\n    // disable or enable input\r\n    function InputEnable(" +
"el_s, el_d) {\r\n        if ($(el_s).prop(\'checked\') == true) {\r\n            $(el_" +
"d).prop(\"disabled\", false);\r\n            //$(el_d).removeAttr(\"disabled\");\r\n    " +
"        $(el_d).prop(\"value\", 0);\r\n        }\r\n        else {\r\n            consol" +
"e.log(\'false\');\r\n            $(el_d).prop(\"disabled\", true);\r\n            $(el_d" +
").prop(\"value\", 0);\r\n        }\r\n    }\r\n\r\n    function InitReportFilter() {\r\n    " +
"    InputEnable();\r\n    }\r\n\r\n    function RecalcCount(rowHeight) {\r\n        var " +
"count;\r\n        count = Math.round((windowHeight() - $(\'.navbar\').height() - $(\'" +
"#top_menu\').height() - $(\'.message\').height() - $(\'footer\').height() - 25) / row" +
"Height);\r\n        return count;\r\n    }\r\n    $(\'#date-time_from\').datepicker();\r\n" +
"</script>\r\n\r\n<div>\r\n    <!-- pozdeji onclick tlacitka v menu -->\r\n    <section");

WriteLiteral(" id=\"reportForm\"");

WriteLiteral(">\r\n");

            
            #line 71 "..\..\Views\Report\_Form.cshtml"
        
            
            #line default
            #line hidden
            
            #line 71 "..\..\Views\Report\_Form.cshtml"
         using (Html.BeginForm("Index", "Report", new { ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, new { role = "form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div>\r\n");

WriteLiteral("                ");

            
            #line 74 "..\..\Views\Report\_Form.cshtml"
           Write(Html.HiddenFor(model => model.StartId, new { @id = "start_id", @value = 0 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 75 "..\..\Views\Report\_Form.cshtml"
           Write(Html.HiddenFor(model => model.Count, new { @id = "count", @value = 60 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2419), Tuple.Create("\"", 2445)
            
            #line 76 "..\..\Views\Report\_Form.cshtml"
, Tuple.Create(Tuple.Create("", 2427), Tuple.Create<System.Object, System.Int32>(ViewBag.firstinit
            
            #line default
            #line hidden
, 2427), false)
);

WriteLiteral(" />\r\n");

            
            #line 77 "..\..\Views\Report\_Form.cshtml"
                
            
            #line default
            #line hidden
            
            #line 77 "..\..\Views\Report\_Form.cshtml"
                  
                    int year, month, day, hours, minutes;
                    string datetimeToValue = "";
                    string datetimeFromValue = "";
                    if (Model.DateTimeFormFrom.Ticks == 0)
                    {
                        year = DateTime.Now.Year;
                        month = DateTime.Now.Month;
                        day = DateTime.Now.Day - 1;
                        hours = DateTime.Now.Hour;
                        minutes = DateTime.Now.Minute;
                    }
                    else
                    {
                        year = Model.DateTimeFormFrom.Year;
                        month = Model.DateTimeFormFrom.Month;
                        day = Model.DateTimeFormFrom.Day;
                        hours = Model.DateTimeFormFrom.Hour;
                        minutes = Model.DateTimeFormFrom.Minute;
                    }

                    string smonth = month.ToString();
                    string sday = day.ToString();
                    string shours = hours.ToString();
                    string sminutes = minutes.ToString();

                    if (month < 10)
                    {
                        smonth = "0" + smonth;
                    }
                    if (day < 10)
                    {
                        sday = "0" + day;
                    }
                    if (hours < 10)
                    {
                        shours = "0" + hours;
                    }
                    if (minutes < 10)
                    {
                        sminutes = "0" + sminutes;
                    }
                    if (day < 1)
                    {
                        sday = "28";
                    }

                    datetimeFromValue = year + "-" + smonth + "-" + sday + "T" + shours + ":" + sminutes;

                    if (Model.DateTimeFormTo.Ticks == 0)
                    {
                        year = DateTime.Now.Year;
                        month = DateTime.Now.Month;
                        day = DateTime.Now.Day;
                        hours = DateTime.Now.Hour;
                        minutes = DateTime.Now.Minute;
                    }
                    else
                    {
                        year = Model.DateTimeFormTo.Year;
                        month = Model.DateTimeFormTo.Month;
                        day = Model.DateTimeFormTo.Day;
                        hours = Model.DateTimeFormTo.Hour;
                        minutes = Model.DateTimeFormTo.Minute;
                    }
                    smonth = month.ToString();
                    sday = day.ToString();
                    shours = hours.ToString();
                    sminutes = minutes.ToString();
                    if (month < 10)
                    {
                        smonth = "0" + month;
                    }
                    if (day < 10)
                    {
                        sday = "0" + day;
                    }
                    if (day < 1)
                    {
                        sday = "28";
                    }
                    if (hours < 10)
                    {
                        shours = "0" + hours;
                    }
                    if (minutes < 10)
                    {
                        sminutes = "0" + minutes;
                    }
                    datetimeToValue = year + "-" + smonth + "-" + sday + "T" + shours + ":" + sminutes;
                    bool recipeSel = false, par0 = false, par1 = false, par2 = false, par3 = false, par4 = false;
                    if (Model.RecipeSel == true)
                    {
                        recipeSel = true;
                    }
                    if (Model.Par0Sel == true)
                    {
                        par0 = true;
                    }
                    if (Model.Par1Sel == true)
                    {
                        par1 = true;
                    }
                    if (Model.Par2Sel == true)
                    {
                        par3 = true;
                    }
                    if (Model.Par3Sel == true)
                    {
                        par3 = true;
                    }
                    if (Model.Par4Sel == true)
                    {
                        par4 = true;
                    }
                
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <!-- time from -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 197 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.DateTimeFormFrom));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 200 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.DateTimeFrom, new { @class = "date-time", id = "date-time_from", type = "datetime-local", Value = @datetimeFromValue }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- time t" +
"o -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 206 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.DateTimeFormTo));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 209 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.DateTimeTo, new { @id = "date-time_to", @class = "date-time", @type = "datetime-local", Value = @datetimeToValue }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- rcpNo-" +
"->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 215 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.RecipeSel, new { @onclick = "InputEnable(this, recipe)", @checked = recipeSel }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 216 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Recipe));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n");

            
            #line 219 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 219 "..\..\Views\Report\_Form.cshtml"
                         if (ViewBag.firstinit == false && Model.RecipeSel == true)
                        {
                            
            
            #line default
            #line hidden
            
            #line 221 "..\..\Views\Report\_Form.cshtml"
                       Write(Html.TextBoxFor(model => model.Recipe, new { @id = "recipe", @class = "date-time", @type = "number", @name = "recipe", @value = Model.Recipe, @min = 0, @style = "width:50px;" }));

            
            #line default
            #line hidden
            
            #line 221 "..\..\Views\Report\_Form.cshtml"
                                                                                                                                                                                                              
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" class=\"tol-set\"");

WriteLiteral(" disabled");

WriteLiteral(" id=\"recipe\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" name=\"recipe\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">\r\n");

            
            #line 226 "..\..\Views\Report\_Form.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n                <!-- amount -" +
"->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 232 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par1Sel, new { @onclick = "InputEnable(this, tol1)", @checked = par1 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 233 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par1Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol1\"");

WriteLiteral(">&plusmn</label>\r\n");

            
            #line 237 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 237 "..\..\Views\Report\_Form.cshtml"
                         if (ViewBag.firstinit == false && Model.Par1Sel == true)
                        {
                            
            
            #line default
            #line hidden
            
            #line 239 "..\..\Views\Report\_Form.cshtml"
                       Write(Html.TextBoxFor(model => model.Par1Tol, new { @id = "tol1", @class = "tol-set", @name = "Par1Tol", @value = Model.Par1Tol, @type = "number", @min = 0, @step = "0.1" }));

            
            #line default
            #line hidden
            
            #line 239 "..\..\Views\Report\_Form.cshtml"
                                                                                                                                                                                                    
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" class=\"tol-set\"");

WriteLiteral(" disabled");

WriteLiteral(" id=\"tol1\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" name=\"Par1Tol\"");

WriteLiteral(" step=\"0.1\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">\r\n");

            
            #line 244 "..\..\Views\Report\_Form.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <span>kg</span>\r\n                    </div>\r\n\r\n          " +
"      </div>\r\n                <!-- temperature -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 252 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par2Sel, new { @onclick = "InputEnable(this, tol2)", @checked = par2 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 253 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par2Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol2\"");

WriteLiteral(">&plusmn</label>\r\n");

            
            #line 257 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 257 "..\..\Views\Report\_Form.cshtml"
                         if (ViewBag.firstinit == false && Model.Par2Sel == true)
                        {
                            
            
            #line default
            #line hidden
            
            #line 259 "..\..\Views\Report\_Form.cshtml"
                       Write(Html.TextBoxFor(model => model.Par2Tol, new { @id = "tol2", @class = "tol-set", @name = "Par2Tol", @value = Model.Par2Tol, @type = "number", @min = 0, @step = "0.1" }));

            
            #line default
            #line hidden
            
            #line 259 "..\..\Views\Report\_Form.cshtml"
                                                                                                                                                                                                    
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" class=\"tol-set\"");

WriteLiteral(" disabled");

WriteLiteral(" id=\"tol2\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" name=\"Par2Tol\"");

WriteLiteral(" step=\"0.1\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">\r\n");

            
            #line 264 "..\..\Views\Report\_Form.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <span>°C</span>\r\n                    </div>\r\n            " +
"    </div>\r\n                <!-- step time -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 271 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par3Sel, new { @onclick = "InputEnable(this, tol3)", @checked = par3 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 272 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par3Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol3\"");

WriteLiteral(">&plusmn</label>\r\n");

            
            #line 276 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 276 "..\..\Views\Report\_Form.cshtml"
                         if (ViewBag.firstinit == false && Model.Par3Sel == true)
                        {
                            
            
            #line default
            #line hidden
            
            #line 278 "..\..\Views\Report\_Form.cshtml"
                       Write(Html.TextBoxFor(model => model.Par3Tol, new { @id = "tol3", @class = "tol-set", @name = "Par3Tol", @value = Model.Par3Tol, @type = "number", @min = 0, @step = "0.1" }));

            
            #line default
            #line hidden
            
            #line 278 "..\..\Views\Report\_Form.cshtml"
                                                                                                                                                                                                    
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" class=\"tol-set\"");

WriteLiteral(" disabled");

WriteLiteral(" id=\"tol3\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" name=\"Par3Tol\"");

WriteLiteral(" step=\"0.1\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">\r\n");

            
            #line 283 "..\..\Views\Report\_Form.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <span>min</span>\r\n                    </div>\r\n           " +
"     </div>\r\n                <!-- interstep time -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 290 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par4Sel, new { @onclick = "InputEnable(this, tol4)", @checked = par4 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 291 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par4Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n                        " +
"<label");

WriteLiteral(" for=\"tol4\"");

WriteLiteral(">&plusmn</label>\r\n");

            
            #line 295 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 295 "..\..\Views\Report\_Form.cshtml"
                         if (ViewBag.firstinit == false && Model.Par4Sel == true)
                        {
                            
            
            #line default
            #line hidden
            
            #line 297 "..\..\Views\Report\_Form.cshtml"
                       Write(Html.TextBoxFor(model => model.Par4Tol, new { @id = "tol4", @class = "tol-set", @name = "Par4Tol", @value = Model.Par4Tol, @type = "number", @min = 0, @step = "0.1" }));

            
            #line default
            #line hidden
            
            #line 297 "..\..\Views\Report\_Form.cshtml"
                                                                                                                                                                                                    
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" class=\"tol-set\"");

WriteLiteral(" disabled");

WriteLiteral(" id=\"tol4\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" name=\"Par4Tol\"");

WriteLiteral(" step=\"0.1\"");

WriteLiteral(" type=\"number\"");

WriteLiteral(" value=\"0\"");

WriteLiteral(">\r\n");

            
            #line 302 "..\..\Views\Report\_Form.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        <span>min</span>\r\n                    </div>\r\n           " +
"     </div>\r\n                <!-- over Rcp limits -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"checkbox md\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 309 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.CheckBoxFor(model => model.Par0Sel, new { @checked = par0 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 310 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.Par0Sel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- Button" +
"s -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n                        <!-- old code of this butto" +
"n: style=\"display: block; float: right; margin-left: 15px; padding: 2px 2px 2px " +
"2px;\" -->\r\n                        <input");

WriteLiteral(" style=\"margin: 5px;\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Submit\"");

WriteLiteral(" />\r\n                    </div>\r\n                    <div>\r\n");

            
            #line 320 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 320 "..\..\Views\Report\_Form.cshtml"
                         if (Model.Batches.Count > 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#exportModal\"");

WriteLiteral(" style=\"margin:5px;\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral(">CSV Export</button>\r\n");

WriteLiteral("                            <div");

WriteLiteral(" id=\"exportModal\"");

WriteLiteral(" class=\"modal fade\"");

WriteLiteral(" role=\"dialog\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"modal-dialog\"");

WriteLiteral(">\r\n\r\n                                    <!-- Modal content-->\r\n                 " +
"                   <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"close\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">&times;</button>\r\n                                            <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">Batch report export to CSV</h4>\r\n                                        </div>\r" +
"\n                                        <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n                                            <p>\r\n");

            
            #line 334 "..\..\Views\Report\_Form.cshtml"
                                                
            
            #line default
            #line hidden
            
            #line 334 "..\..\Views\Report\_Form.cshtml"
                                                  
                                                    double time = ((double)Model.Batches.Count / 1000);
                                                
            
            #line default
            #line hidden
WriteLiteral("\r\n                                                You will export export ");

            
            #line 337 "..\..\Views\Report\_Form.cshtml"
                                                                  Write(Model.Batches.Count);

            
            #line default
            #line hidden
WriteLiteral(" batches to csv<br>\r\n                                                Very aproxim" +
"atly it will take ");

            
            #line 338 "..\..\Views\Report\_Form.cshtml"
                                                                         Write(time);

            
            #line default
            #line hidden
WriteLiteral(" s\r\n                                            </p>\r\n                           " +
"             </div>\r\n                                        <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 15390), Tuple.Create("\"", 15415)
, Tuple.Create(Tuple.Create("", 15397), Tuple.Create<System.Object, System.Int32>(Href("~/Report/exportCSV")
, 15397), false)
);

WriteLiteral(" style=\"margin:5px;\"");

WriteLiteral(" class=\"btn btn-sm btn-default\"");

WriteLiteral(" onclick=\"closeDataModal()\"");

WriteLiteral(">CSV Export</a>\r\n                                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">Close</button>\r\n                                        </div>\r\n                " +
"                    </div>\r\n                                </div>\r\n            " +
"                </div>\r\n");

            
            #line 348 "..\..\Views\Report\_Form.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                </div>\r\n                <!-- recipes " +
"multi field -->\r\n                <div");

WriteLiteral(" class=\"form-item\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 354 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.RecipesRanges));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n");

            
            #line 357 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 357 "..\..\Views\Report\_Form.cshtml"
                           string rcpRangesValue = ""; 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 358 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.TextBoxFor(model => model.RecipesRanges, new { @class = "form-control", id = "recipes_numbers", Value= rcpRangesValue }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!-- recipe" +
"s multi select -->\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <div>\r\n");

WriteLiteral("                        ");

            
            #line 364 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.LabelFor(model => model.RecipesNames));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <div>\r\n");

            
            #line 367 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 367 "..\..\Views\Report\_Form.cshtml"
                           var recipesNames = Model.RecipesNames.Items;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 368 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 368 "..\..\Views\Report\_Form.cshtml"
                          Model.RecipesNames = null;
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 369 "..\..\Views\Report\_Form.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 369 "..\..\Views\Report\_Form.cshtml"
                          Model.RecipesNames = new MultiSelectList(recipesNames, "Value", "Text");
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("                        ");

            
            #line 371 "..\..\Views\Report\_Form.cshtml"
                   Write(Html.ListBoxFor(model => model.RecipesNumbers, Model.RecipesNames, new { @class = "form-control", id = "recipes_multiselect", multiple = "multiple" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                        <script>
                            $(document).ready(function () {
                                $(""#recipes_multiselect"").attr({
                                    ""data-placeholder"": ""Select desired recipes"",
                                });
                                $(""#recipes_multiselect"").chosen({
                                    width: ""100%"",
                                    no_results_text: ""No recipe found!""
                                });
                            });
                        </script>
                    </div>
                </div>
            </div>
");

            
            #line 386 "..\..\Views\Report\_Form.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </section>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
