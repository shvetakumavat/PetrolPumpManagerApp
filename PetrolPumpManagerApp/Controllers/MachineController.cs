using Newtonsoft.Json.Linq;
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
    public class MachineController : Controller
    {

        public static List<string> machineNozzels = new List<string>() { "Nozzle 1", "Nozzle 2", "Nozzle 3", "Nozzle 4" };
        // GET: Machine
        public ActionResult Index()
        {
            var data = MachineList(0);
            var nozzeldata = NozzelList(0);
           
            List<MachineCreateViewModel> Model = new List<MachineCreateViewModel>();
            foreach (Machine m in data.Item1)
            {
                Model.Add(new MachineCreateViewModel
                {
                    MachineModel = m,
                    MachineNozzels = nozzeldata
                }) ;
                   
            }
            return View(Model);
          
        }


        // GET: Machine/Create
        public ActionResult Create()
        {
            ViewBag.nozzels = machineNozzels;
            return View(new MachineCreateViewModel {
            MachineModel= new Machine { 
            MachineID=0
            } 
            });
        }

    
        // POST: Machine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachineCreateViewModel model, string AddNozzel, string Nozzel, string submit)
        {
          
            if (submit == "Save")
            {

                if (ModelState.IsValid)
                {
                    CreateAndUpdateMachine(model.MachineModel.MachineID,
                        model.MachineModel.MachineNumber,
                        model.MachineModel.MachineName);
                    foreach (string nozzel in machineNozzels)
                    {

                        CreateNozzels(nozzel, model.MachineModel.MachineID);
                    }

                }
                return RedirectToAction("Index");
        }
            else if (AddNozzel == "+")
            {
                machineNozzels.Add(Nozzel);
                ViewBag.nozzels = machineNozzels;
                return RedirectToAction("Create");

    }

            else
                return View();
}


        public ActionResult Edit(int id)
        {
            var data = MachineList(0);
            var nozzeldata = NozzelList(0);
            List<string> n = new List<string>();
            MachineCreateViewModel model = new MachineCreateViewModel()
            {
                MachineModel = data.Item2,
                MachineNozzels = nozzeldata
            };
            foreach (var s in nozzeldata)
            {
                n.Add(s.NozzelName);
            }
            machineNozzels = n;
            ViewBag.nozzels = machineNozzels;
            return View("Create", model);
        }




        //delete Nozzel Method 

        public ActionResult RemoveNozzelFromList(int id)
        {
            machineNozzels.RemoveAt(id);
                  ViewBag.nozzels = machineNozzels;
            return RedirectToAction("Create");
        }



        // GET: Machine/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteMachine(id);
            return View();
        }

      
    }
}
