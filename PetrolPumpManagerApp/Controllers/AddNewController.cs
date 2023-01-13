using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  static PumpDBLibrary.BusinessLogic.ModelManager;

namespace PetrolPumpManagerApp.Controllers
{
    public class AddNewController : Controller
    {
        // GET: AddNew
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddTanker()
        {
            return View();
        }
        public ActionResult Tankers()
        {
            return View();
        }

        public ActionResult Supplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Supplier(Supplier model)
        {
           // int record = CreateSupplier(model.SupplierID,model.FullName, model.Email,model.Address, model.ContactNumber, model.Remark);
            return View();
        }
     
        public ActionResult GetSupplierList()
        {
            
            return View();
        }
        //[HttpPut]
        //public ActionResult Supplier(Supplier model)
        //{
        //    int record = CreateSupplier(model.SupplierID, model.FullName, model.Email, model.Address, model.ContactNumber, model.Remark);
        //    return View();
        //}





        public ActionResult AddMachine()
        {
            return View();
        }
        public ActionResult Machine()
        {

           //List< Machine> m = new List<Machine>()
           // {
           //    new Machine(){  MachineID = 1,
           //     MachineNumber = 1,
           //     MachineName = "Machine1",
           //     FuilType = "petrol",
           //     Nozzels = { "sd" }},
           //    new Machine(){  MachineID = 1,
           //     MachineNumber = 1,
           //     MachineName = "Machine2",
           //     FuilType = "petrol",
           //     Nozzels = { "sd","fdkfj","ckchd" }}

           // };

            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }

        //orders

        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Purchase()
        {
            return View();
        }
    }
}