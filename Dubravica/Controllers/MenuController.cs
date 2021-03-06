﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Dubravica.Controllers
{
    public class MenuController : Controller
    {
        [Authorize]
        public ActionResult Index(int id)
        {
            bool bMenu = getMenu(id);
            if (!bMenu)
                return RedirectToAction("Login", "Account");
            XMLController XC = new XMLController();
            List<string> plc = XC.readNodesNameXML("plc", id, 1);
            List<string> names = XC.readNodesNameXML("plc", id, 2);
            List<string> types = XC.XMLgetTypes("plc", id);
            string url = "/" + types[1] + "?name=" + names[0] + "&plc=" + plc[0];
            return Redirect(url);
        }

        /*
         * @param void, @return redirect 
         * Method to get Menu o
         * to Menu on Index view method
         */
        public bool getMenu(int id = 0)
        {
            String preId;
            if (id == 0)
            {

                if (Request.QueryString["id"] != null)
                {
                    preId = Request.QueryString["id"].ToString();
                    if (User.IsInRole(preId))
                    {
                        id = Int32.Parse(preId);
                    }
                    else
                    {
                        return false;//RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    if ((Int32.TryParse(Session["id"].ToString(), out id)) == true)
                    {
                        //out int id = int id 
                    }
                    else
                    {
                        return true;//RedirectToAction("Index", "Home");
                    }
                }
            }


            XMLController XC = new XMLController();
            List<String> values = XC.readXML("plc", id);
            List<String> items = XC.readNodesNameXML("plc", id, 3);
            List<String> plc = XC.readNodesNameXML("plc", id, 1);
            List<String> names = XC.readNodesNameXML("plc", id, 2);
            List<String> types = XC.XMLgetTypes("plc", id);
            string ProjectName = XC.readNodeXML("name", id);
            int i = 0;
            foreach (String value in values)
            {
                //String name = names[i] + items[i];
                Session.Add(items[i], value);
                i++;
            }
            Session.Add("values", values);

            Session.Add("id", id);
            Session.Add("names", names);
            Session.Add("plc", plc);
            Session.Add("types", types);
            Session.Add("ProjectName", ProjectName);

            return true;//return RedirectToAction("Index", "Menu");
        }
    }
}