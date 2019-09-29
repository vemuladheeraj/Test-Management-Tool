using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Defect_Tracker.Models
{

    public class testlist
    {
        public string name1;
        public List<testlist> ReleaseName {get;set;}
       
    }
    public class releaseclass
    {
   
        public List<releaseclass> release { get; set; }
        public string ReleaseName { get; set; }

    }
}