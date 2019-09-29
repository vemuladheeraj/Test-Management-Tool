using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Defect_Tracker.Models
{
    public class DefectModel
    {
        public string T_Number { get; set; }
        public string T_Desc { get; set; }
        public string T_Developer { get; set; }
        public string T_Tester { get; set; }
        public int Passed { get; set; }
        public int Testcases { get; set; }
        public int Fail { get; set; }
        public int OnHold { get; set; }
        public int Defects { get; set; }
        public string T_State { get;  set; }
        public string Tester { get;  set; }
    }
    public class DefectViewModel
    {
        public DefectViewModel()
        {
            AllTicketDetails = new List<DefectModel>();
        }
        public List<DefectModel> AllTicketDetails { get; set; }
    }
}