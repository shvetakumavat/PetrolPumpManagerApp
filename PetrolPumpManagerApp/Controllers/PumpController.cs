using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetrolPumpManagerApp.Controllers
{
    public class PumpController : Controller
    {
        // GET: Pump
        public ActionResult Index()
        {
            return View();
        }


      
        [HttpPost]
        public ActionResult Rate(ProductRate model)
        {
            return View();
        }
       
        public ActionResult MeterReadings()
        {
            return View();
        }
        //public ActionResult GetMeterReadings()
        //{

        //    List<MeterReading> m = new List<MeterReading>() {
        //        new MeterReading()
        //        { 
        //            ID=1,
        //            OpeningReading=1200,
        //            ClosingReading=5000,
        //            Date=System.DateTime.Now,
        //            StaffAtThatDate=null,
        //            Machines=null,
        //            FuilType=null,
        //            SaleAmount=12333,
        //            SaleInLeters=23233,
        //            NetSale=90439,
        //            TatalSalesAmount=934030,
        //           TatalSalesInLeter=930940
        //        },
        //         new MeterReading()
        //        {
        //            ID=1,
        //            OpeningReading=1200,
        //            ClosingReading=5000,
        //            Date=System.DateTime.Now,
        //            StaffAtThatDate=null,
        //            Machines=null,
        //            FuilType=null,
        //            SaleAmount=12333,
        //            SaleInLeters=23233,
        //            NetSale=90439,
        //            TatalSalesAmount=934030,
        //           TatalSalesInLeter=930940
        //        }

        //    };
        //    return View(m);
        //}


        public ActionResult DipReading()
        {
            return View();
        }

        public ActionResult Deposites()
        {
            return View();
        }
       
        public ActionResult Expences()
        {
            return View();
        }
    }
}