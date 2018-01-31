using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dubravica.GraphReport.Models
{   

    public class GraphReportResponse
    {
          public List<double> dataSet { get; set; }
          public List<string> labels { get; set; }
    }
    public class DataRequest
    {
        public long beginTime { get; set; } //in pkTime
        public long endTime { get; set; } //in pkTime
        public RequestType requestType { get; set; }
        //public int viewLength;
        public List<Tag> definition { get; set; }
    }

    public class Tag
    {
        public string table { get; set; }
        public string column { get; set; }
    }

    public enum RequestType
    {
        batches,
        frequency,
        differences,
        absoulteScale
    }
    public enum GraphType
    {

    }
}