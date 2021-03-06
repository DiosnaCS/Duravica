﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dubravica.Report.Models
{

    public class ReportModel
    {
        public Int32 ConvertDT2pkTime(DateTime dateTime)
        {
            DateTime pkTimeStart = DateTime.SpecifyKind(new DateTime(2000, 1, 1), DateTimeKind.Utc);
            Int32 pkTime = 0;
            pkTime = (Int32)(dateTime.ToUniversalTime() - pkTimeStart).TotalSeconds;

            return pkTime;
        }

        // StartId
        public Int32 StartId { get; set; }

        // Count
        public Int16 Count { get; set; }

        // pk time from
        public Int32 pkTimeFrom { get; set; }

        // pk time to
        public Int32 pkTimeTo { get; set; }

        // date time from
        [Display(Name = "From:")]
        public DateTime DateTimeFormFrom {
            get {
                DateTime dateTime = new DateTime(DateTimeFormFromDate.Year, DateTimeFormFromDate.Month, DateTimeFormFromDate.Day, DateTimeFormFromTime.Hour, DateTimeFormFromTime.Minute, 0);
                pkTimeFrom = ConvertDT2pkTime(dateTime);
                return dateTime;
            }
            set {
                DateTimeFormTo = value;
            }
        }
        public DateTime DateTimeFormFromDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateTimeFormFromTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeFrom {
            get {
                if (DateTimeFormTo.Ticks == 0)  {
                    pkTimeFrom = ConvertDT2pkTime(new DateTime(DateTime.Now.Ticks - 864000000000));
                    return DateTimeFormTo;
                }
                else {
                    return DateTimeFormTo;
                }
            }
            set {
                DateTimeFormFrom = value;
                pkTimeFrom = ConvertDT2pkTime(value);
            }
        }

        // date time to
        [Display(Name = "To:")]
        public DateTime DateTimeFormTo {
            get {
                DateTime dateTime = new DateTime(DateTimeFormToDate.Year, DateTimeFormToDate.Month, DateTimeFormToDate.Day, DateTimeFormToTime.Hour, DateTimeFormToTime.Minute, 0);
                pkTimeTo = ConvertDT2pkTime(dateTime);
                return dateTime;
            }
                set {
                DateTimeFormTo = value;
            } }
        public DateTime DateTimeFormToDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateTimeFormToTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeTo {
            get {
                return DateTimeFormTo;
            }
            set {
                DateTimeFormTo = value;
                pkTimeTo = ConvertDT2pkTime(value);
            }
        }
        public bool RecipeSel { get; set; }
        // recipe        
        [Display(Name = "Recipe:")]
        public int Recipe { get; set; }

        // over limits
        [Display(Name = "Over limits")]
        public bool Par0Sel { get; set; }

        // amount       
        [Display(Name = "Amount: ")]
        public bool Par1Sel { get; set; }
        public string sPar1Tol { get; set; }
        public string Par1Tol {
            get {
                return sPar1Tol;
            }
            set {
                if (value != null)
                {
                    AmountTolerance = (int)(float.Parse(value.Replace(".", ",")) * Amount_coef);
                }
                else { }
            } }
        public const int Amount_coef = 1000;
        public int AmountTolerance { get; set; }

        // temperature
        [Display(Name = "Temperature: ")]
        public bool Par2Sel { get; set; }
        public string sPar2Tol { get; set; }
        public string Par2Tol
        {
            get
            {
                return sPar2Tol;
            }
            set
            {
                if (value != null)
                {
                    TempTolerance = (int)(float.Parse(value.Replace(".", ",")) * Temp_coef);
                }
                else { }
            }
        }
        public const int Temp_coef = 10;
        public int TempTolerance { get; set; }

        // step time
        [Display(Name = "Step time: ")]
        public bool Par3Sel { get; set; }
        public string sPar3Tol { get; set; }
        public string Par3Tol
        {
            get
            {
                return sPar3Tol;
            }
            set
            {
                if (value != null)
                {
                    StepTimeTolerance = (int)(float.Parse(value.Replace(".", ",")) * StepTime_coef);
                }
                else { }
            }
        }
        public const int StepTime_coef = 60;
        public int StepTimeTolerance { get; set; }

        // interstep time
        [Display(Name = "Interstep time: ")]
        public bool Par4Sel { get; set; }
        public string sPar4Tol { get; set; }
        public string Par4Tol
        {
            get
            {
                return sPar4Tol;
            }
            set
            {
                if (value != null)
                {
                    InterStepTimeTolerance = (int)(float.Parse(value.Replace(".", ",")) * InterStepTime_coef);
                } else { }
            }
        }
        public const int InterStepTime_coef = 60;
        public int InterStepTimeTolerance { get; set; }
        [Display(Name = "Recipes ranges:")]
        public string RecipesRanges { get; set; }
        public List<int> RecipesNumbers  { get; set; }
        public int[] RecipesNumbers2 { get; set; }
        [Display(Name = "Recipes:")]
        public MultiSelectList RecipesNames { get; set; }

        //Data should be also there
        public List<Batch> Batches = new List<Batch>(); //array of current batches 
    }

    /// <summary>
    /// Status bits of (E)nd and (S)tart of step 0xEEEE_SSSS
    /// </summary>
    [Flags]
    public enum StepStatus
    {
        Running = 0x00000000,
        ForcedStart = 0x00000001,
        OK = 0x00010000,
        Skipped = 0x00020000,
        Cancelled = 0x00040000,
        Error = 0x00080000,
    }

    [Flags]
    public enum BatchStatus
    {
        None = 0,
        AM = 1, //Amount
        Temp = 2, //Temperature
        ST = 4, //StepTime
        IST = 8 //InterStepTime
    }

    
    public enum OperationType
    {
        Dosing = 11,
        Kneading = 21,
        Ripping = 31,
        Tipping = 41
    }



    public class Batch
    {
        public uint Id /*diBatchNo directly from db*/ { get; set; }
        public DateTime StartTime /*In pkTime from server, at a client conversion to dateTime*/ { get; set; }
        public DateTime EndTime /*In pkTime from server, at a client conversion to dateTime*/ { get; set; }
        public string RecipeName /*string directly from db*/ { get; set; }
        public int RecipeNo /*string directly from db*/ { get; set; }
        public BatchStatus diffStatus /* flag type */ { get; set; }
        public StepStatus batchStatus /* flag type */ { get; set; }
        public int maxDiffAM { get; set; }
        public int minDiffAM { get; set; }
        public int maxDiffTemp { get; set; }
        public int minDiffTemp { get; set; }
        public int maxDiffST { get; set; }
        public int minDiffST { get; set; }
        public int maxDiffIST { get; set; }
        public int minDiffIST { get; set; }
    }

    public class Steps {
        public uint Id { get; set; }
        public int BowlId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RecipeNo { get; set; }
        public string RecipeName  { get; set; }
        public int StepsCount { get; set; }
        public List<RecipeStep> BatchSteps = new List<RecipeStep>();
        
    }

    public class CSVSteps
    {
        public uint BatchNo { get; set; }
        public int BowlId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RecipeNo { get; set; }
        public string RecipeName { get; set; }
        public int StepsCount { get; set; }
        
        //Whole model sorted from steps ascending
        public int step /*step*/ { get; set; }
        public int DeviceId /*Device id*/{ get; set; }
        public string Device /*DeviceName directly from db*/ { get; set; }
        public OperationType OperationNr /*Resolve how to get that*/ { get; set; }
        public Int32 Need /*DeviceName directly from db*/ { get; set; }
        public Int32 Done /*diNeedDone directly from db*/ { get; set; }
        //Diff should be calculted by client
        public StepStatus Status /*siStatus directly from db*/ { get; set; }
    }


    public class RecipeStep
    {

        //Whole model sorted from steps ascending
        public int step /*step*/ { get; set; }
        public DateTime StartTime /*In pkTime from server, at a client conversion to dateTime*/ { get; set; }
        public DateTime EndTime /*In pkTime from server, at a client conversion to dateTime*/ { get; set; }
        public int RecipeNo /*Device recipe*/{ get; set; }
        public int DeviceId /*Device id*/{ get; set; }
        public string Device /*DeviceName directly from db*/ { get; set; }
        public OperationType OperationNr /*Resolve how to get that*/ { get; set; }
        public Int32 Need /*DeviceName directly from db*/ { get; set; }
        public Int32 Done /*diNeedDone directly from db*/ { get; set; }

        //Diff should be calculted by client

        public StepStatus Status /*siStatus directly from db*/ { get; set; }
        
    }
}