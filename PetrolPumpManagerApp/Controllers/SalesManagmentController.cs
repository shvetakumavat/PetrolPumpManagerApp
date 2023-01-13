using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
using static PetrolPumpManagerApp.DataAccess.DataLogic;
using PetrolPumpManagerApp.ViewModels;

namespace PetrolPumpManagerApp.Controllers
{

   //idex view of MeterReadings 
   //defing index view 
    

    public class SalesManagmentController : Controller
    {

        public void WireUpList()
        {
            ViewBag.StaffList = StaffList().Item1;
            ViewBag.ProductList = ProductList().Item1;
            ViewBag.MachineList = MachineList().Item1;
            

        }
        // GET: SalesManagment
        public ActionResult Index()
        {
            var sd = MeterReadingList().Item3;
            List<SalesManModel> sm = new List<SalesManModel>();
            foreach (var i in sd)
            {
                sm.Add(
                    new SalesManModel
                    {
                        staffId = i.StaffID,
                        StaffName = i.FullName,
                        sale = getSalebysID(i.StaffID).Item1,
                        TSale = getSalebysID(i.StaffID).Item2.SaleInLeters,
                        TSaleAmount= getSalebysID(i.StaffID).Item2.SaleAmount
                    }
                    )  ;
            }

            SaleIndexViewModel model = new SaleIndexViewModel
            {
                SalesMan = sm,
                meterReading = MeterReadingList().Item1
            };         
            return View(model);
        }


        // GET: SalesManagment/Create
        public ActionResult Create()
        {
            WireUpList();

            return View(new MeterReading { ID=0, Date=System.DateTime.Now.Date});
        }

        // POST: SalesManagment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeterReading model)
        {
            WireUpList();

            //if (ModelState.IsValid)
            //{
            //    model.SaleInLeters = model.ClosingReading - model.OpeningReading - model.Test;

            //    if (model.ProductId == 1)
            //    {
            //        model.SaleAmount = model.SaleInLeters * model.HSDRate;
            //    }
            //    else {
            //        model.SaleAmount = model.SaleInLeters * model.MSDRate;
            //    }

            //    int record = CreateAndUpdateMeterReading(model.ID,model.ClosingReading,
            //        model.Date,model.StaffId,model.ProductId,model.MachineId,
            //        model.NozzelId,model.Test,model.SaleAmount,model.SaleInLeters );

            //    return View("Create");
            //}
          
            return RedirectToAction("Create");

        }
        public JsonResult GetMachineNozzels(int MachineId)
        {

            var nozzelList = NozzelList(MachineId);
            return Json(nozzelList, JsonRequestBehavior.AllowGet);
        }


        // GET: SalesManagment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

      
        // GET: SalesManagment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
