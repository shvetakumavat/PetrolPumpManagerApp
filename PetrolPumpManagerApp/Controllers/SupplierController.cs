using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;

namespace PetrolPumpManagerApp.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            var data = GetSupplierList(0);
            List<Supplier> Model = new List<Supplier>();
            foreach (var row in data)
            {
                Model.Add(new Supplier
                {
                    SupplierID = row.SupplierID,
                    FullName = row.FullName,
                    Email = row.Email,
                    ContactNumber = row.ContactNumber,
                    Address = row.Address,
                    Remark = row.Remark

                }); ;

            }
            return View(Model);
        }
        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View(new Supplier { SupplierID = 0 });
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier model)
        {

            if (ModelState.IsValid)
            {
                    int record = CreateAndUpdateSupplier(model.SupplierID,
                                                   model.FullName,
                                                   model.Email,
                                                   model.Address,
                                                   model.ContactNumber,
                                                   model.Remark);
          
                return RedirectToAction("Index");
            }
            else
            return View();

        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var data = GetSupplierList(id);
            Supplier Model = new Supplier();
            foreach (var row in data)
            {
                Model.SupplierID = row.SupplierID;
                Model.FullName = row.FullName;
                Model.Email = row.Email;
                Model.ContactNumber = row.ContactNumber;
                Model.Address = row.Address;
                Model.Remark = row.Remark;

            }
            return View("Create", Model);
        }

       
        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteSuplier(id);
            return RedirectToAction("Index");
        }


      
    }
}
