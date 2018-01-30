using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dubravica.GraphReport.Models;
using Dubravica.Handlers;
using Dubravica.Report.Models;

namespace Dubravica.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GraphReportController : Controller
    {
        // GET: GraphReport
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> getData()
        {
            string json = null;
            StreamReader stream = new StreamReader(Request.InputStream);
            if (json == null)
            {
                json = stream.ReadToEnd();
            }
            if (json != "")
            {
                object data = new object();
                //ReportModel RVM = new ReportModel();
                DataRequest dataRequest = new JavaScriptSerializer().Deserialize<DataRequest>(json);
                List<object[]> objects = new List<object[]>();
                string columns = "";
                switch (dataRequest.requestType)
                {
                    case RequestType.frequency:

                        break;
                    case RequestType.differences:

                        break;
                    case RequestType.absoulteScale:
                        db db = new db("Dubravica", 12);
                        string[] conditions1 = { "\"UTC\"", "\"UTC\"" };
                        string[] Operators = { ">=", "<=" };
                        string[] conditions2 = { "'" + GraphReportHelper.pkTimeToUTC(dataRequest.beginTime) + "'", "'" + GraphReportHelper.pkTimeToUTC(dataRequest.endTime) + "'" };
                        string where = db.whereMultiple(conditions1, Operators, conditions2);
                        foreach (string table in dataRequest.definition.Select(tag=> tag.table).Distinct())
                        {
                            foreach (Tag tag in dataRequest.definition)
                            {
                                columns += columns += " \"" + tag.column + "\",";
                            }
                            objects = await db.multipleItemSelectPostgresAsync(columns, table, where);
                        }
                        break;
                }
            }
            else
            {
                return null;
            }
            return Json(data, "application/json", JsonRequestBehavior.AllowGet);

        }
    }
}