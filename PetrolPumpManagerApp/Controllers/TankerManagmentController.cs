using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
namespace PetrolPumpManagerApp.Controllers
{
    public class TankerManagmentController : Controller
    {
        // GET: TankerManagment
        public ActionResult Index()
        {



            var data = GetTankerList(0);
            List<Tanker> Model = new List<Tanker>();
            foreach (var row in data)
            {
                Model.Add(new Tanker
                {
                   TankerID=row.TankerID,
                   TankerName=row.TankerName,
                   Capacity=row.Capacity,
                   MaximumDip=row.MaximumDip,
                   MinmumDip=row.MinmumDip

                }); ;

            }
            return View(Model);
            
        }

      

        // GET: TankerManagment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TankerManagment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tanker model)
        {
            if (ModelState.IsValid)
            {
                int record = CreateAndUpdateTanker(
                   model.TankerID,
                   model.TankerName,
                   model.Capacity,
                   model.MaximumDip,
                   model.MinmumDip
                    );

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: TankerManagment/Edit/5
        public ActionResult Edit(int id)
        {
            var data = GetTankerList(id);
            Tanker Model = new Tanker();
            foreach (var row in data)
            {
                Model.TankerID = row.TankerID;
                Model.TankerName = row.TankerName;
                Model.Capacity = row.Capacity;
                Model.MaximumDip = row.MaximumDip;
                Model.MinmumDip = row.MinmumDip;

            }
            return View("Create", Model);
        }


        // GET: TankerManagment/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteTanker(id);
            return RedirectToAction("Index");
        }

      
        
    }
}
