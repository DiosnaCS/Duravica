using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dubravica.Controllers;
using Dubravica.Report.Models;
using ServiceStack.Text;

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
            sql = string.Format("SELECT \"diNegToler\" FROM events WHERE \"iRecordType\"=11 AND \"diBatchNo\"={0} ORDER BY \"siRecipeStep\" DESC", batchNo);

            results = db.multipleItemSelectPostgres(sql);
            if (results != null)
            {
                foreach (object[] result in results)
                {
                    int traceNumber = (int)result[0];
                    traceNumbers.Add(traceNumber);
                }
            }
            return traceNumbers;
        }

        public string ToCSV (uint[] batchIds)
        {
            List<Steps> data = new List<Steps>();
            foreach (uint Id in batchIds) {
                Steps recipe = getBatchData(Id);
                data.Add(recipe);
            }
            string csv = CsvSerializer.SerializeToCsv(data);
            return csv;
        }
        public Steps getBatchData(uint batchId)
        {
            string sql = "";
            List<object[]> results = new List<object[]>();
            db db = new db("Dubravica", 12);

            sql = "SELECT MAX(batchno)," +
                    "step," +
                    "MAX(recipeno), " +
                    "MAX(timefrom), " +
                    "MAX(timeto), " +
                    "MAX(operation), " +
                    "MAX(deviceid), " +
                    "MAX(devicerecipe), " +
                    "MAX(need), " +
                    "MAX(done), " +
                    "MAX(status_forced), " +
                    "MAX(status_ok), " +
                    "MAX(stepscount) " +
                        "FROM get_batch(" + batchId + ") GROUP BY step ORDER BY step DESC;";

            results = db.multipleItemSelectPostgres(sql);
            Steps Steps = returnBatch(results);

            return Steps;
        }
        /// <summary>
        /// Refractored method to return batch in model 
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        private static Steps returnBatch(List<object[]> results)
        {
            Steps Steps = new Steps();
            RecipeStep rcpStep = new RecipeStep();

            //BatchId to model
            if (results[0][0] != DBNull.Value)
            {
                Steps.Id = Convert.ToUInt32(results[0][0]);
            }

            //BowlId to model
            if (results[0][6] != DBNull.Value)
            {
                Steps.BowlId = Convert.ToInt32(results[0][6]);
            }

            //pkTime StartTime format to model
            if (results[0][3] != DBNull.Value)
            {
                long pkTime = Convert.ToInt64(results[0][3]);
                long timeInNanoSeconds = pkTime * 10000000;
                DateTime datetimeStartBatch = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                Steps.StartTime = datetimeStartBatch;
            }
            //pkTime EndTime format to model
            if (results[0][4] != DBNull.Value)
            {
                long pkTime = Convert.ToInt64(results[0][4]);
                long timeInNanoSeconds = pkTime * 10000000;
                DateTime datetimeEndBatch = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                Steps.EndTime = datetimeEndBatch;
            }
            //RecipeNo to model
            if (results[0][2] != DBNull.Value)
            {
                Steps.RecipeNo = Convert.ToInt32(results[0][2]);
            }

            //RecipeName to model
            Steps.RecipeName = results[0][7].ToString();

            //Number of steps
            if (results[0][12] != DBNull.Value)
            {
                Steps.StepsCount = Convert.ToInt32(results[0][12]);
            }

            for (int i = 1; i < results.Count; i++)
            {
                RecipeStep recipeStep = new RecipeStep();

                //Current Step
                if (results[i][1] != DBNull.Value)
                {
                    recipeStep.step = (int)results[i][1];
                }
                //Device RecipeNo
                if (results[i][2] != DBNull.Value)
                {
                    recipeStep.RecipeNo = Convert.ToInt32(results[i][2]);
                }

                //pkTime StartTime format to model
                if (results[i][3] != DBNull.Value)
                {
                    long pkTime = Convert.ToInt64(results[i][3]);
                    long timeInNanoSeconds = pkTime * 10000000;
                    DateTime datetimeStart = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                    recipeStep.StartTime = datetimeStart;
                }
                //pkTime EndTime format to model
                if (results[i][4] != DBNull.Value)
                {
                    long pkTime = Convert.ToInt64(results[i][4]);
                    long timeInNanoSeconds = pkTime * 10000000;
                    DateTime datetimeEnd = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                    recipeStep.EndTime = datetimeEnd;
                }
                //type of operation
                if (results[i][5] != DBNull.Value)
                {
                    switch ((int)results[i][5])
                    {
                        case 15:
                            recipeStep.OperationNr = OperationType.Dosing;
                            break;
                        case 25:
                            recipeStep.OperationNr = OperationType.Kneading;
                            break;
                        case 35:
                            recipeStep.OperationNr = OperationType.Ripping;
                            break;
                        case 45:
                            recipeStep.OperationNr = OperationType.Tipping;
                            break;
                    }
                }
                //DeviceId
                if (results[i][6] != DBNull.Value)
                {
                    recipeStep.DeviceId = Convert.ToInt32(results[i][6]);
                }

                //DeviceName
                recipeStep.Device = results[i][7].ToString();

                //Need
                if (results[i][8] != DBNull.Value)
                {
                    recipeStep.Need = Convert.ToInt32(results[i][8]);
                }

                //Done
                if (results[i][9] != DBNull.Value)
                {
                    recipeStep.Done = Convert.ToInt32(results[i][9]);
                }

                //StepStatus
                if (results[i][10] != DBNull.Value)
                {
                    switch ((int)results[i][10])
                    {
                        case 0:
                            recipeStep.Status = StepStatus.Error;
                            break;
                        case 1:
                            recipeStep.Status = StepStatus.ForcedStart;
                            break;
                    }
                }
                if (results[i][11] != DBNull.Value)
                {
                    switch ((int)results[i][11])
                    {
                        case 0:
                            recipeStep.Status |= StepStatus.Error;
                            break;
                        case 1:
                            recipeStep.Status |= StepStatus.OK;
                            break;
                        case 2:
                            recipeStep.Status |= StepStatus.Skipped;
                            break;
                    }
                }
                Steps.BatchSteps.Add(recipeStep);
            }

            return Steps;
        }
    }
}