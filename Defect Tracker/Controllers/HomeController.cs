using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Defect_Tracker.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Defect_Tracker.Controllers
{
    public class HomeController : Controller
    {
        public const string appdescr = "Your application description page.";
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Index1()
        {

            List<testlist> list = new List<testlist>();
            list.Add(new testlist() { name1 = "dheeraj" });
            list.Add(new testlist() { name1 = "dheeraj56" });
            ViewBag.b = list;
            return View();
        }
        public ActionResult Index2()
        {
            var context = new Defect_TrackerEntities1();
            var sap = context.releases.ToList();
            ViewBag.allreleasenames = sap;
            return View();
        }
        [HttpPost]
        public ActionResult PostReleaseData(string param)

        {
            var context = new Defect_TrackerEntities1();
            var sap = context.releases.ToList();
            ViewBag.allreleasenames = sap;
            var res2 = context.releases.Where(x => x.Release_Name == param).Select(y => y.R_Id).Take(1).FirstOrDefault();
            //var rel1 = context.TicketInfoes.Where(x => x.R_ID == res2).ToList();
            //var rel1 = from ti in context.TicketInfoes
            //           from te in context.Testexecutions
            //           where (ti.T_Id == te.T_Id && ti.R_ID == res2)
            //           select new DefectModel
            //           {
            //               T_Number = ti.T_Number,
            //               T_Desc = ti.T_Desc,
            //               T_State = ti.T_State,
            //               T_Developer = ti.T_Developer,
            //               Tester = ti.T_Tester,
            //               Passed = te.passed ?? 0,
            //               Testcases = te.Testcases ?? 0,
            //               Fail = te.fail ?? 0,
            //               OnHold = te.onhold ?? 0,
            //               Defects = te.defects ?? 0

            //           };
            var rel1 = from ti in context.TicketInfoes
                       join te in context.Testexecutions on ti.T_Id equals te.T_Id
                       
                       into ps from te in ps.DefaultIfEmpty()
                       where ti.R_ID == res2
                       
                       select new DefectModel
                       {
                           T_Number = ti.T_Number,
                           T_Desc = ti.T_Desc,
                           T_State = ti.T_State,
                           T_Developer = ti.T_Developer,
                           Tester = ti.T_Tester,
                           Passed = te.passed ?? 0,
                           Testcases = te.Testcases ?? 0,
                           Fail = te.fail ?? 0,
                           OnHold = te.onhold ?? 0,
                           Defects = te.defects ?? 0

                                      };
            ViewBag.ticketinformation = rel1.ToList();

            DefectViewModel vm = new DefectViewModel();
            vm.AllTicketDetails = rel1.ToList();
            return PartialView("PartialIndex2", vm);
        }
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("NXP", 14));
            dataPoints.Add(new DataPoint("Infineon", 10));
            dataPoints.Add(new DataPoint("Renesas", 9));
            dataPoints.Add(new DataPoint("STMicroelectronics", 8));
            dataPoints.Add(new DataPoint("Texas Instruments", 7));
            dataPoints.Add(new DataPoint("Bosch", 5));
            dataPoints.Add(new DataPoint("ON Semiconductor", 4));
            dataPoints.Add(new DataPoint("Toshiba", 3));
            dataPoints.Add(new DataPoint("Micron", 3));
            dataPoints.Add(new DataPoint("Osram", 2));
            dataPoints.Add(new DataPoint("Others", 35));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        [HttpPost]
        public ActionResult UpdateReleasedata(string releaseName)

        {
            var context = new Defect_TrackerEntities1();
            release rupdate = new release();
            rupdate.Release_Name = releaseName;
            context.releases.Add(rupdate);
            context.SaveChanges();

            return Json("Release Added Successfully");

        }
        [HttpPost]
        public ActionResult saveAlTicketDetails(List<UIDataModel> UIDataModels)
            
        {

            try
            {
                foreach (var uIDataModel in UIDataModels)
                {
                    //UIDataModel UIDataModel = new UIDataModel();
                    string ticketnum = uIDataModel.TicketNumber;
                    int Testcases = Convert.ToInt32(uIDataModel.TotalTestcases);
                    int passed = Convert.ToInt32(uIDataModel.Passed);
                    int fail = Convert.ToInt32(uIDataModel.Fail);
                    int onhold = Convert.ToInt32(uIDataModel.OnHold);

                    //int defects = Convert.ToInt32(UIDataModel.

                    var context = new Defect_TrackerEntities1();
                    
                    Testexecution testexecution = new Testexecution();

                    int ticketid = context.TicketInfoes.Where(x => x.T_Number == ticketnum).Select(y => y.T_Id).Take(1).FirstOrDefault();
                    int CheckifExist = context.Testexecutions.Where(x => x.T_Id == ticketid).Select(y => y.T_Id).Take(1).FirstOrDefault();
                    string Connection = ConfigurationManager.ConnectionStrings["DefectTrackerConnectionString"].ConnectionString; 
                    using (var connection = new SqlConnection(Connection))
                    {
                        connection.Open();
                        var command = new SqlCommand("select top 1 * from Testexecution", connection)
                        {
                            CommandType = CommandType.Text
                        };
                        //command.Parameters.AddWithValue("@Datasource", LoaderConstants.ConstLawson);
                        var result = command.ExecuteScalar();
                    }


                    if (CheckifExist == 0)
                    {
                        testexecution.T_Id = ticketid;
                        testexecution.Testcases = Testcases;
                        testexecution.passed = passed;
                        testexecution.fail = fail;
                        testexecution.onhold = onhold;
                        //testexecution.defects = 0;

                        context.Testexecutions.Add(testexecution);
                        context.SaveChanges();

                        //return Json("Ticket Details saved Successfully");
                    }
                    else
                    {
                        //var testexecutiona = context.Testexecutions.Where(a => a.T_Id == ticketid).Select(y=>y.T_Id).FirstOrDefault();
                       Testexecution testexecutiona = context.Testexecutions.Single(x => x.T_Id == ticketid);
                        testexecutiona.Testcases = Testcases;
                        testexecutiona.passed = passed;
                        testexecutiona.fail = fail;
                        testexecutiona.onhold = onhold;
                        //testexecutiona.defects = 1;
                        //context.Testexecutions.Add(testexecutiona);
                      
                        context.SaveChanges();

                        //return Json("Testing for Another scenario");
                    }
                }
                //bool newCheckifExist =String.IsNullOrEmpty(CheckifExist.ToString());

                //return Json("To view");
            }
                catch(Exception e)
            {
                Console.WriteLine("{0} First exception caught.", e);
               
            }
            // return Json("To view");
          
          
            return Json("To view");
        }


        [HttpPost]
             public ActionResult InsertDefectDetails(string ticketid, string Deftitle, string DefectDesc, string DefSteps)

        {
            var context = new Defect_TrackerEntities1();
            Defect dinfoo = new Defect();
           
            var tickid = context.TicketInfoes.Where(x => x.T_Number == ticketid).Select(y => y.T_Id).Take(1).FirstOrDefault();
            var Releaseid = context.TicketInfoes.Where(x => x.T_Number == ticketid).Select(y => y.R_ID).Take(1).FirstOrDefault();
            var defectnumber = context.Defects.OrderByDescending(x => x.d_number).Select(y => y.d_number).Take(1).FirstOrDefault();
            var d_number = CreateDefectNumber(defectnumber);

            //var ticketinfo = new TicketInfo() { R_ID = res2,t_ };

            dinfoo.T_id = tickid;
            dinfoo.r_id = Releaseid;
            dinfoo.d_number = d_number;
            dinfoo.d_title = Deftitle;
            dinfoo.D_Description = DefectDesc;
            dinfoo.Stepstorepro = DefSteps;            
            context.Defects.Add(dinfoo);
            context.SaveChanges();

            return Json("Ticket Details Added Successfully");


        }

        public String CreateDefectNumber(string defectnumber)
        {
            var defbnum = Convert.ToInt32(defectnumber.Substring(3));
            Int32 defnu= defbnum+1;
            String defnum = defnu.ToString("D4");
            
            var def = "DEF";
           String newdefect =def + defnum;
            return (newdefect);
            
        }

        [HttpPost]
        public ActionResult InsertTicketDetails(string param1, string param2, string param3, string param4)

        {
            var context = new Defect_TrackerEntities1();
            TicketInfo tinfo = new TicketInfo();
            var res2 = context.releases.Where(x => x.Release_Name == param1).Select(y => y.R_Id).Take(1).FirstOrDefault();

            //var ticketinfo = new TicketInfo() { R_ID = res2,t_ };

            tinfo.R_ID = res2;
            tinfo.T_Number = param2;
            tinfo.T_State = param3;
            tinfo.T_Desc = param4;
            context.TicketInfoes.Add(tinfo);
            context.SaveChanges();

            return Json("Ticket Details Added Successfully");

        }
        //[HttpPost]
        //public void InsertTicketDetails(string param1, string param2, string param3, string param4)

        //{

        //    var context = new Defect_TrackerEntities1();
        //    TicketInfo tinfo = new TicketInfo();
        //    var res2 = context.releases.Where(x => x.Release_Name == param1).Select(y => y.R_Id).Take(1).FirstOrDefault();

        //    //var ticketinfo = new TicketInfo() { R_ID = res2,t_ };

        //    tinfo.R_ID = res2;
        //    tinfo.T_Number = param2;
        //    tinfo.T_State = param3;
        //    tinfo.T_Desc = param4;
        //    context.TicketInfoes.Add(tinfo);
        //    context.SaveChanges();
                   
        //}


        public ActionResult About()
        {
            ViewBag.Message = appdescr;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}