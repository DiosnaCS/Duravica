using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dubravica.GraphReport.Models;
using Dubravica.Handlers;
using Dubravica.Report.Models;
using Newtonsoft.Json;
using Dubravica.Handlers;


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

        //[HttpPost]
        //public ActionResult Index()
        //{
          //  return View();
        //}
        public async Task<JsonResult> getData()
        {
            GraphReportResponse response = new GraphReportResponse();
            response.datasets = new List<DataSet>();
            //response.labels = new List<string>();
            string tagLabel = "";
            DateTime dateTimeLabel = new DateTime();

            string json = null;
            StreamReader stream = new StreamReader(Request.InputStream);
            if (json == null)
            {
                json = stream.ReadToEnd();
            }
            if (json != "")
            {
                //ReportModel RVM = new ReportModel();
                GraphReport.Models.DataRequest dataRequest = JsonConvert.DeserializeObject<GraphReport.Models.DataRequest>(json);
                List<object[]> objects = new List<object[]>();
                string columns = "";
                switch (dataRequest.requestType)
                {
                    case RequestType.batches:

                        break;

                    case RequestType.frequency:

                        break;
                    case RequestType.differences:

                        break;

                    case RequestType.absoulteScale:
                        db db = new db("InternDelights", 12);
                        string[] conditions1 = { "\"UTC\"", "\"UTC\"" };
                        string[] Operators = { ">=", "<=" };
                        string[] conditions2 = { "'" + GraphReportHelper.pkTimeToUTC(dataRequest.beginTime) + "'", "'" + GraphReportHelper.pkTimeToUTC(dataRequest.endTime) + "'" };
                        string where = db.whereMultiple(conditions1, Operators, conditions2);
                        foreach (string table in dataRequest.definition.Select(tag => tag.table).Distinct())
                        {
                            foreach (GraphReport.Models.Tag tag in dataRequest.definition)
                            {
                                columns += " \"" + tag.column + "\",";
                            }
                            columns = columns.Substring(0, columns.Length - 1);
                            objects = await db.multipleItemSelectPostgresAsync("\"UTC\"," + columns, table, where);
                            for (int i = 0; i < objects.Count; i++)
                            {
                                for (int j = 1; j < objects[0].Length; j++)
                                {
                                    if (i == 0)
                                    {
                                        DataSet onlyColorDataSet = new DataSet();
                                        onlyColorDataSet.backgroundColor = ColorTranslator.ToHtml(Color.DarkOliveGreen);
                                        //onlyColorDataSet.fillColor = "#8DB986"; //ColorTranslator.ToHtml(Color.AliceBlue);
                                        //onlyColorDataSet.highlightColor = "#8DB986";//ColorTranslator.ToHtml(Color.Aqua);
                                        //onlyColorDataSet.highlightStroker = "#ACCE91";// ColorTranslator.ToHtml(Color.Beige);
                                        //onlyColorDataSet.strokeColor = "#ACCE91"; //ColorTranslator.ToHtml(Color.Blue);
                                        response.datasets.Add(onlyColorDataSet);
                                        if (response.datasets[j - 1].data == null)
                                        {
                                            response.datasets[j - 1].data = new List<double>();
                                        }
                                    }
                                    double doubleValue = (double)objects[i][j];
                                    response.datasets[j - 1].data.Add(doubleValue);
                                    if (j < dataRequest.definition.Count)
                                    {
                                        tagLabel = dataRequest.definition[j - 1].label;
                                    }
                                    response.datasets[j - 1].label = tagLabel;
                                }
                                int lastDay = dateTimeLabel.Day;
                                //dateTimeLabel = Helpers.ConvertpkTime2DT(Helpers.utcToPkTime(objects[i][0].ToString()));
                                if (dateTimeLabel.Day != lastDay)
                                {
                                  //  response.labels.Add(dateTimeLabel.ToString());
                                }
                                else
                                {
                                    //response.labels.Add(dateTimeLabel.ToShortTimeString());
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                return null;
            }
            return Json(response, "application/json", JsonRequestBehavior.AllowGet);
        }

        static double Double(double input) { return input*2; }
    }
}