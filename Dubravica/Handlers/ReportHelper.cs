using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dubravica.Controllers;
using Dubravica.Report.Models;

namespace Dubravica.Handlers
{
    public class ReportHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchNo"></param>
        public  static List<int> getTraceNumbers(int batchNo)
        {
            string sql = "";
            List<object[]> results = new List<object[]>();
            db db = new db("Dubravica", 12);
            List<int> traceNumbers = new List<int>();
            sql = string.Format("SELECT \"diNegToler\" FROM events WHERE \"iRecordType\"=11 AND \"diBatchNo\"={0}", batchNo);

            results = db.multipleItemSelectPostgres(sql);
            foreach (object[] result in results)
            {
                int traceNumber = (int)result[0];
                traceNumbers.Add(traceNumber);
            }

            return traceNumbers;
        }
        /// <sum
    }
}