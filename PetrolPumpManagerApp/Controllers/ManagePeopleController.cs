using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
namespace PetrolPumpManagerApp.Controllers
{



    /// <summary>
    /// dont delete me -----------------------------------------------------3333333333333====================######################
    /// </summary>
    public class ManagePeopleController : Controller
    {
        // GET: ManagePeople
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }
        public ActionResult AddStaff()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(Staff model)
        {
            //int record = CreateStaff(model.StaffID, model.FullName,model.EmailAddress,
            //                         model.ContactNumber,System.DateTime.Now, 
            //                         model.Address, model.Salary, model.Designation,
            //                         model.IsWorking, model.TotalLeavesInMonth,
            //                         model.TotalDayOFAttendenceInMonth);
            return View();
        }
        public ActionResult StaffLeave()
        {
            return View();
        }

    }
}