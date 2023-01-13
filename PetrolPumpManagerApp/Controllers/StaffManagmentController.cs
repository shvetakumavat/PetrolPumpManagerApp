using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PumpDBLibrary.BusinessLogic.ModelManager;
using PetrolPumpManagerApp.Models;

namespace PetrolPumpManagerApp.Controllers
{
    public class StaffManagmentController : Controller
    {
        // GET: StaffManagment
        public ActionResult Index()
        {
            var data = GetStaffList(0);
            List<Staff> Model = new List<Staff>();
            foreach (var row in data)
            {
                Model.Add(new Staff
                {
                    StaffID = row.StaffID,
                    FullName=row.FullName,
                    EmailAddress=row.EmailAddress,
                    ContactNumber=row.ContactNumber,
                    Salary=row.Salary,
                    TotalDayOFAttendenceInMonth=row.TotalDayOFAttendenceInMonth,
                    TotalLeavesInMonth=row.TotalLeavesInMonth,
                    Address=row.Address,
                    DateOfBirth=row.DateOfBirth,
                    Designation=row.Designation,
                    IsWorking=row.IsWorking
                    
                }) ;

            }
            return View(Model);
        }

        

        // GET: StaffManagment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffManagment/Create
        [HttpPost]
        public ActionResult Create(Staff model)
        {
            if (ModelState.IsValid)
            {
                int record = CreateAndUpdateStaff(
                    
                    model.StaffID,
                    model.FullName,
                    model.EmailAddress,
                    model.ContactNumber,
                    model.DateOfBirth,
                    model.Address,
                    model.Salary,
                    model.Designation,
                    model.IsWorking,
                    model.TotalLeavesInMonth,
                    model.TotalDayOFAttendenceInMonth
                
                    );

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: StaffManagment/Edit/5
        public ActionResult Edit(int id)
        {
            var data = GetStaffList(id);
            Staff Model=new Staff();
            foreach (var row in data)
            {

                Model.StaffID = row.StaffID;
                Model.FullName = row.FullName;
                Model.EmailAddress = row.EmailAddress;
                Model.ContactNumber = row.ContactNumber;
                Model.Salary = row.Salary;
                Model.TotalDayOFAttendenceInMonth = row.TotalDayOFAttendenceInMonth;
                Model.TotalLeavesInMonth = row.TotalLeavesInMonth;
                Model.Address = row.Address;
                Model.DateOfBirth = row.DateOfBirth;
                Model.Designation = row.Designation;
                Model.IsWorking = row.IsWorking;


            }
            return View("Create", Model);
        }

      
        // GET: StaffManagment/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteStaffMember(id);
            return RedirectToAction("Index");
        }

     
    }
}
