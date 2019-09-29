using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace Defect_Tracker.Models
{
    public class UIDataModel
    {
       //[Display(Name = "Ticket Number")]
        public string TicketNumber { get; set; }
      
        public int Passed { get; set; }
        //[Display(Name = "Total Testcases")]
        public int TotalTestcases { get; set; }
        public int Fail { get; set; }
        public int OnHold { get; set; }
        public int Defects { get; set; }
     
    }
    public class DefectViewModel1
    {
        public DefectViewModel1()
        {
            AllTicketDetails = new List<DefectModel>();
        }
        public List<DefectModel> AllTicketDetails { get; set; }
    }
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, double y)
        {
            this.Label = label;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "label")]
        public string Label = "";

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}
