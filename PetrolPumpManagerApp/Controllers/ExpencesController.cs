using PetrolPumpManagerApp.Models;
using PetrolPumpManagerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
using static PetrolPumpManagerApp.DataAccess.DataLogic;

namespace PetrolPumpManagerApp.Controllers
{
    public class ExpencesController : Controller
    {
        // GET: Expences

      
        public ActionResult Index()
        {
            var data = GetExpencesList(0);
            List<Expences> Model = new List<Expences>();
            foreach (var row in data)
            {
                Model.Add(new Expences
                {
                    ExpenceID = row.ID,
                    Amount= row.Amount,
                    Remark= row.Remark,
                    StaffId=row.StaffId,
                    StaffName=row.StaffName

                }) ; 

            }
            return View(Model);
          
        }

     
     

        // GET: Expences/Create
        public ActionResult Create()
        {
            
            ViewBag.StaffList = StaffList().Item1;
            return View(new Expences { ExpenceID=0});
        }

        //
        // POST: Expences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(Expences model)
        {
            

            if (ModelState.IsValid)
            {
                int record = CreateAndUpdateExpences(model.ExpenceID,
                                                     model.StaffId,
                                                     model.Amount,
                                                     model.Remark);
                return RedirectToAction("Index");

            }
            ViewBag.StaffList = StaffList().Item1;
            return RedirectToAction("Create");
           

        }

        // GET: Expences/Edit/5
        public ActionResult Edit(int id)
        {
            var data = GetExpencesList(id);
            Expences Model = new Expences();
            foreach (var row in data)
            {
                Model.ExpenceID = row.ID;
                Model.Amount = row.Amount;
                Model.Remark = row.Remark;
                Model.StaffId = row.StaffId;
                Model.StaffName = row.StaffName;
            }
            ViewBag.StaffList = StaffList().Item1;
            return View("Create",Model);
        }

     

        // GET: Expences/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteExpences(id);
            return RedirectToAction("Index");
        }

       
    }
}
