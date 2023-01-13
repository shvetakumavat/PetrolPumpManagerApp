
using PumpDataAccessLibrary.DataAccess;
using PumpDataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PumpDataAccessLibrary.BusinessLogic
{
   public static class StaffManager
    {
        public static int CreateStaff(int staffId,  string fullName,  string emailAddress,   string contactNumber,
                          DateTime dateOfBirth, string Address,decimal salary, string designation, 
                          bool isWorking, int totalLeavesInMonth,  int totalDayOFAttendenceInMonth)
        {

            Staff data = new Staff()
            {
                StaffID=staffId,
                FullName=fullName,
                EmailAddress=emailAddress,
                ContactNumber=contactNumber,
                DateOfBirth=dateOfBirth,
                Address= Address,
                Salary =salary,
                Designation=designation,
                IsWorking=isWorking,
                TotalLeavesInMonth=totalLeavesInMonth,
                TotalDayOFAttendenceInMonth=totalDayOFAttendenceInMonth
            };
            string sql = @"INSERT INTO
                         `pumpmanagmentdb`.`staff` (`ID`, `FullName`, `EmailAddress`, `ContactNumber`, `DateOfBirth`,
                         `Address`, `Salary`, `Designation`, `IsWorking`, `TotalLeavesInMonth`, `TotalDayOFAttendenceInMonth`) 
                          VALUES (@StaffID,@FullName,@EmailAddress,
                                    @ContactNumber,@DateOfBirth,@Address,
                                    @Salary,@Designation,
                                    @IsWorking,@TotalLeavesInMonth,
                                    @TotalDayOFAttendenceInMonth);";
            return MySqlDataAccess.SaveData(sql,data) ;
        }
    }
}
