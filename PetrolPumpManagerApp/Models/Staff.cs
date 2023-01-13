using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Decimal Salary { get; set; }
        public string Designation { get; set; }
        public bool IsWorking { get; set; }
       
        //TODO write LeaveLogic saparete class becuse of Startdate and EndDate
        //TODO count all leaves of this individual in month 
        //using between query in sql
        //and pass the total of leaves in this property 
        //this property not store in DB 
        //but leaves are stored
        public int TotalLeavesInMonth { get; set; }

        //count all days in month -TotalLeavesInMonth
        //this property not store in DB
        //just Use for display
        public int TotalDayOFAttendenceInMonth { get; set; }


    }
}