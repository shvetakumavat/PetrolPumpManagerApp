using System;
using System.Collections.Generic;
using System.Text;

namespace PumpDataAccessLibrary.Model
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

        public int TotalLeavesInMonth { get; set; }

        public int TotalDayOFAttendenceInMonth { get; set; }
    }
}
