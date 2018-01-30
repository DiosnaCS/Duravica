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
            List<CSVSteps> stepdata = new List<CSVSteps>();
            string csv = "";
            foreach (uint Id in batchIds) {
                /*
                Steps recipe = getBatchData(Id);
                List<RecipeStep> recipeSteps = recipe.BatchSteps;
                recipedata.Add(recipe);
                // why this function is only for IEnurable
                csv += CsvSerializer.SerializeToCsv(recipedata);
                recipedata.Remove(recipe);
                csv += CsvSerializer.SerializeToCsv(recipeSteps);
                */
                Steps recipe = getBatchData(Id);
                foreach (var batchstep in recipe.BatchSteps) {
                    CSVSteps CSVstep = new CSVSteps();
                    CSVstep.BatchNo = recipe.Id;
                    CSVstep.BowlId = recipe.BowlId;
                    CSVstep.StartTime = recipe.StartTime;
                    CSVstep.EndTime = recipe.EndTime;
                    CSVstep.RecipeNo = recipe.RecipeNo;
                    CSVstep.RecipeName = recipe.RecipeName;
                    CSVstep.StepsCount = recipe.StepsCount;
                    CSVstep.step = batchstep.step;
                    CSVstep.DeviceId = batchstep.DeviceId;
                    CSVstep.Device = batchstep.Device;
                    CSVstep.OperationNr = batchstep.OperationNr;
                    CSVstep.Need = batchstep.Need;
                    CSVstep.Done = batchstep.Done;
                    CSVstep.Status = batchstep.Status;
                    //this will add step into big list of all steps in all batches
                    stepdata.Add(CSVstep);
                }
            }
            csv = CsvSerializer.SerializeToCsv(stepdata);
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
            int stepStatus = 0;
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
                        case 11:
                            recipeStep.OperationNr = OperationType.Dosing;
                            break;
                        case 15:
                            recipeStep.OperationNr = OperationType.Dosing;
                            break;
                        case 21:
                            recipeStep.OperationNr = OperationType.Kneading;
                            break;
                        case 25:
                            recipeStep.OperationNr = OperationType.Kneading;
                            break;
                        case 31:
                            recipeStep.OperationNr = OperationType.Ripping;
                            break;
                        case 35:
                            recipeStep.OperationNr = OperationType.Ripping;
                            break;
                        case 41:
                            recipeStep.OperationNr = OperationType.Tipping;
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
                    stepStatus = (int)results[i][10];
                    recipeStep.Status = (StepStatus)stepStatus;    
                }
                if (results[i][11] != DBNull.Value)
                {
                    stepStatus = (int)results[i][11];
                    stepStatus = stepStatus << 16;
                    recipeStep.Status |= (StepStatus)stepStatus;
                }
                Steps.BatchSteps.Add(recipeStep);
            }

            return Steps;
        }
        /// <summary>
        /// Unfortuantly this is only for Dubravica 
        /// </summary>
        /// <param name="model">Model with data from form</param>
        public ReportModel SelectReports(ReportModel model)
        {
            List<object[]> results = getReportData(model);
            //model.Batches = new Batch[results.Count];
            //int i = 0;
            foreach (object[] result in results)
            {
                bool resultOK = true;
                if (model.Par1Sel == true)
                {
                    if (result[5] == DBNull.Value || result[6] == DBNull.Value)
                    {
                        resultOK = false;
                    }
                }
                if (model.Par2Sel == true)
                {
                    if (result[7] == DBNull.Value || result[8] == DBNull.Value)
                    {
                        resultOK = false;
                    }
                }
                if (model.Par3Sel == true)
                {
                    if (result[9] == DBNull.Value || result[10] == DBNull.Value)
                    {
                        resultOK = false;
                    }
                }
                if (model.Par4Sel == true)
                {
                    if (result[11] == DBNull.Value || result[12] == DBNull.Value)
                    {
                        resultOK = false;
                    }
                }
                if (resultOK == true)
                {
                    Batch batch = new Batch();

                    //Id = BatchNo
                    if (result[0] != DBNull.Value)
                    {
                        batch.Id = Convert.ToUInt32(result[0]);
                    }
                    //pkTime StartTime format to model
                    if (result[1] != DBNull.Value)
                    {
                        long pkTime = Convert.ToInt64(result[1]);
                        long timeInNanoSeconds = pkTime * 10000000;
                        DateTime datetimeStart = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                        batch.StartTime = datetimeStart;
                    }
                    //pkTime EndTime format to model
                    if (result[2] != DBNull.Value)
                    {
                        long pkTime = Convert.ToInt64(result[2]);
                        long timeInNanoSeconds = pkTime * 10000000;
                        DateTime datetimeEnd = new DateTime(((630836424000000000 - 13608000000000) + timeInNanoSeconds));
                        batch.EndTime = datetimeEnd;
                    }

                    //RecipeName 
                    batch.RecipeName = result[3].ToString();

                    //RecipeNumber
                    if (result[4] != DBNull.Value)
                    {
                        batch.RecipeNo = Convert.ToInt32(result[4]);
                    }

                    batch.status = BatchStatus.None;
                    //Batch Status
                    if (result[5].ToString().Length != 0 && result[6].ToString().Length != 0)
                    {
                        batch.status |= BatchStatus.AM;
                        batch.maxDiffAM = (int)result[5];
                        batch.minDiffAM = (int)result[6];
                    }
                    if (result[7].ToString().Length != 0 && result[8].ToString().Length != 0)
                    {
                        batch.status |= BatchStatus.Temp;
                        batch.maxDiffTemp = (int)result[7];
                        batch.minDiffTemp = (int)result[8];
                    }
                    if (result[9].ToString().Length != 0 && result[10].ToString().Length != 0)
                    {
                        batch.status |= BatchStatus.ST;
                        batch.maxDiffST = (int)result[9];
                        batch.minDiffST = (int)result[10];
                    }
                    if (result[11].ToString().Length != 0 && result[12].ToString().Length != 0)
                    {
                        batch.status |= BatchStatus.IST;
                        batch.maxDiffIST = (int)result[11];
                        batch.minDiffIST = (int)result[12];
                    }
                    //Batch to Batches
                    //model.Batches[i] = batch;
                    model.Batches.Add(batch);
                }
                //i++;
            }
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<object[]> getReportData(ReportModel model)
        {
            int dateFrom = model.pkTimeFrom; //in pkTime
            int dateTo = model.pkTimeTo; //in pkTime
            int recipeNo = model.Recipe;

            bool OverLimits = model.Par0Sel;
            bool AmountSel = model.Par1Sel;
            bool TempSel = model.Par2Sel;
            bool StepTimeSel = model.Par3Sel;
            bool InterStepTimeSel = model.Par4Sel;
            if (AmountSel == true || TempSel == true || StepTimeSel == true || true || InterStepTimeSel == true)
            {
                AmountSel = true;
                TempSel = true;
                StepTimeSel = true;
                InterStepTimeSel = true;
            }
            List<object[]> results = new List<object[]>();
            string sql = "";
            db db = new db("Dubravica", 12);

            sql = "SELECT dibatchno, MAX(pktimefrom) AS timefrom, MAX(pktimeto) AS timeto,";
            sql += "MAX(rcpname) AS rcpname, MAX(recipenumber) AS recipenumber,";
            sql += "MAX(maxamount) AS maxamnt, MAX(mintamount) AS minamnt,";
            sql += "MAX(maxtemperature) AS maxtemp, MAX(mintemperature) AS mintemp,";
            sql += "MAX(maxsteptime) AS maxst, MAX(minsteptime) AS minst,";
            sql += "MAX(maxintersteptime) AS maxist, MAX(minintersteptime) AS minist ";
            sql = string.Format(sql + "FROM get_bad_batches({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}) GROUP BY dibatchno ORDER BY dibatchno ASC",
                dateFrom, dateTo, recipeNo, OverLimits, AmountSel, model.AmountTolerance,
                TempSel, model.TempTolerance, StepTimeSel, model.StepTimeTolerance, InterStepTimeSel,
                model.InterStepTimeTolerance);

            results = db.multipleItemSelectPostgres(sql);
            return results;
        }


        /// 
        /// </summary>
        /// <param name="batchId"></param>
        public Steps getBatchData(int batchId)
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
        
        /*public dynamic getReportGraphsConfig(string path, )
        {
            dynamic data;

            XmlSerializer.DeserializeFromString();
            return data;
        }*/   
    }
}