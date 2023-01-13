using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PetrolPumpManagerApp.DataAccess.DataLogic;
using static PumpDBLibrary.BusinessLogic.ModelManager;
namespace PetrolPumpManagerApp.Controllers
{



    //create side chart for rate of 10 days 

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStockData()
        {

            List<Product> data = new List<Product>();
            foreach (var d in GetProductStock())
            {
                data.Add(new Product
                {
                    ProductName = d.ProductName,
                    Stock = d.Stock
                });
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSalesChartData()
        {

            List<HSDMSDSales> data = new List<HSDMSDSales>();
            var v = GetSumOfSales();
            foreach (var d in v)
            {
                data.Add(
                    new HSDMSDSales
                    {
                        HSDSaleInAmt = d.HSDSaleInAmt,
                        MSDSaleInAmt = d.MSDSaleInAmt,
                        OverAllSaleInAmt = d.OverAllSaleInAmt,
                        SaleDate = d.SaleDate.ToString("yyyy-MM-dd")
                    }
                    );
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLinearRateChartData()
        {

            List<HSDMSDSales> data = new List<HSDMSDSales>();
            var v = getRateDataforgraph();
            foreach (var d in v)
            {
                data.Add(
                    new HSDMSDSales
                    {
                        HSDSaleInAmt = d.HSDSaleInAmt,
                        MSDSaleInAmt = d.MSDSaleInAmt,
                        SaleDate = d.SaleDate.ToString("yyyy-MM-dd")
                    }
                    );
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductRate(DateTime Date)
        {
            string date = Date.ToString("yyyy-MM-dd");

            var productRate = GetProductRateVal(date);

            return Json(productRate, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrentRate(string date = "2022-11-26")
        {

            
            decimal hsdRate=0, msdRate=0;
            foreach (var r in RateList().Item1)
            {
                string cdate = r.Date.ToString("yyyy-MM-dd");
                if (cdate.Equals(date))
                {
                    if (r.ProductId == 1)
                    {
                        hsdRate = r.Rate;
                    }
                    if (r.ProductId == 2)
                    {
                        msdRate = r.Rate;
                    }
                }

            }
        
            decimal[] rates = { hsdRate, msdRate };
            return Json(rates, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMachineNozzels(int MachineId)
        {

            var nozzelList = NozzelList(MachineId);
            return Json(nozzelList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetopeningMeterValue(int NozzelId,int MachineId, DateTime Date, int ProductId)
        {
            string date =Date.ToString("yyyy-MM-dd");
                
            var meterOpeningReading = GetMeterOpeningReadingVal(NozzelId, MachineId, date,ProductId );
         
            return Json(meterOpeningReading, JsonRequestBehavior.AllowGet);
        }
      
        public JsonResult GetSalesDataByDate()
        {
            DateTime Date = DateTime.Now;
            string date = "2022-11-27";/*Date.ToString("yyyy-MM-dd");*/
           List<HSDMSDSales> sale = new List<HSDMSDSales>();
            var SaleData = GetSaleData(date);
            foreach (var s in SaleData)
            {
                sale.Add(new HSDMSDSales {
                HSDSaleInLtr = s.HSDSaleInLtr,
                MSDSaleInLtr = s.MSDSaleInLtr,
                OverAllSaleInLtr = s.OverAllSaleInLtr,
                HSDSaleInAmt = s.HSDSaleInAmt,
                MSDSaleInAmt = s.MSDSaleInAmt,
                OverAllSaleInAmt = s.OverAllSaleInAmt

            });
               
              
            }

            return Json(sale, JsonRequestBehavior.AllowGet);
        }

     
    }
}