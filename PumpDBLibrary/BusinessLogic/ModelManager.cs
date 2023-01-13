using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PumpDBLibrary.Model;
using PumpDBLibrary.DataAccess;
namespace PumpDBLibrary.BusinessLogic
{
    public static  class ModelManager
    {

        public static int CreateAndUpdateMeterReading(int Id, decimal closingReading,
            DateTime date, int staffId, int productId, int machineId, 
            int nozzelId, decimal test, decimal saleAmount, decimal saleInLrt)
        {

            MeterReading data = new MeterReading
            {
                ID=Id,
                ClosingReading=closingReading,
                Date=date,
                StaffId=staffId,
                ProductId=productId,
                MachineId=machineId,
                NozzelId=nozzelId,
                Test=test,
                SaleInLeters=saleInLrt,
                SaleAmount=saleAmount
            };
            string sql;
            if (Id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`meterreading` SET
                                                                `ClosingReading` =@ClosingReading ,
                                                                `Date` = @Date,
                                                                `StaffId`=@StaffId , 
                                                                `MachineId` =@MachineId, 
                                                                `NozzelId` = @NozzelId, 
                                                                `ProductId` =@ProductId , 
                                                                `Test` = @Test,
                                                                `SaleAmount` =@SaleAmount
                                                                WHERE (`ID` = '" + Id+"'); ";

            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`meterreading` 
                        (`ClosingReading`, `Date`, `StaffId`, `MachineId`, `NozzelId`, `ProductId`, `Test`, `SaleAmount`,`SaleInLeters`) 
                        VALUES (@ClosingReading, @Date, @StaffId, @MachineId, @NozzelId, @ProductId, @Test, @SaleAmount,@SaleInLeters);";
            }                                                           


            return MySqlDataAccess.SaveData(sql, data);
        }

        public static decimal GetMeterOpeningReadingVal(int nozzelId, int machineId, string date, int productId)
        {

            string sql;
            decimal meterOpening;
            
            sql = "select closingReading from meterreading where (MachineId='"+machineId+"') and (NozzelId='"+nozzelId+ "') and (date= subdate('"+ date + "',1)) and (ProductId='" + productId+"')";
            meterOpening= MySqlDataAccess.LoadValue<decimal>(sql);
            if (meterOpening != 0)
            {
                return meterOpening;
            }
            else return 00;
        }
        public static decimal GetProductRateVal( string date)
        {

            string sql;
            decimal productRate;

            sql = "select Rate from productrate ( Date ='"+date+"')";
            productRate = MySqlDataAccess.LoadValue<decimal>(sql);
            if (productRate != 0)
            {
                return productRate;
            }
            else return 00;
        }

        public static List<HSDMSDSales> GetSumOfSales()
        {
            string sql = @"select ht.HSDSaleInAmt, mt.MSDSaleInAmt, ot.OverAllSaleInAmt, ot.Date as SaleDate
                            from
                            (select sum(saleAmount) as HSDSaleInAmt, row_number() over(order by date) as rownumber from meterreading where ProductId = 1 group by date) as ht
                            inner join
                            (select sum(saleAmount) as MSDSaleInAmt ,  row_number() over(order by date) as rownumber   from meterreading where ProductId = 2 group by date) as mt
                            on ht.rownumber = mt.rownumber
                            inner join
                            (select sum(saleAmount) as OverAllSaleInAmt ,Date,  row_number() over(order by date) as rownumber  from meterreading group by date) as ot
                            on ht.rownumber = ot.rownumber";
            return MySqlDataAccess.LoadData<HSDMSDSales>(sql).ToList();
         
        }


        public static List<HSDMSDSales> getRateDataforgraph()
        {
            string sql = @"select h.HSDSaleInAmt, m.MSDSaleInAmt,h.SaleDate from 
                           (SELECT rate as HSDSaleInAmt ,date as SaleDate, row_number() over (order by date ) as id FROM pumpmanagmentdb.productrate where ProductId=1)as h
                           inner join 
                           (SELECT rate as MSDSaleInAmt , row_number() over (order by date ) as id FROM pumpmanagmentdb.productrate where ProductId=2)as m
                           on 
                           h.id=m.id order by h.SaleDate desc limit 7";
            return MySqlDataAccess.LoadData<HSDMSDSales>(sql).ToList();

        }
        public static List<Product> GetProductStock()
        {
            string sql = @"SELECT ProductName, Stock FROM pumpmanagmentdb.product;";
            return MySqlDataAccess.LoadData<Product>(sql).ToList();

        }



        static public List<HSDMSDSales> GetSaleData ( string date) {

            string sql = "pumpmanagmentdb.Select_Sale_Data";
            string [] pr = { "_saleDate" };
           return MySqlDataAccess.ExecuteStoredProcedures<HSDMSDSales>(sql,pr,date).ToList();
        }



        static public List<MeterReading> GetMeterReadingData(string date )
        {

            string sql = "pumpmanagmentdb.Select_Todays_MeterReadings";
            string[] pr = { "_date" };
            return MySqlDataAccess.ExecuteStoredProcedures<MeterReading>(sql, pr, date).ToList();
        }
        static public Tuple<List<MeterReading>,MeterReading> GetSaleDataByStaffIDData(string date,int id)
        {
            string sql = "pumpmanagmentdb.Select_ProductSaleData_By_StaffID";
            string[] pr = { "_date", "_id" };
            List<MeterReading> m=MySqlDataAccess.ExecuteStoredProcedures<MeterReading>(sql, pr, date,id).ToList();

           string  sql2 = @"select sum(SaleAmount) as SaleAmount , Sum(SaleInLeters) as SaleInLeters from meterreading
                            where StaffID='" + id + "' and Date='" + date + "'";
            MeterReading m1 = MySqlDataAccess.LoadValue<MeterReading>(sql2);

            return new Tuple<List<MeterReading>, MeterReading>(m, m1);
        }

        static public List<Staff> GetStaffListBySale(string date)
        {
            string sql = @"select 
                                distinct s.StaffId, s.FullName
                                from
                                staff s 
                                inner join  meterreading mr
                                					on s.StaffId=mr.StaffId
                                where mr.Date='"+date+"';";
            return MySqlDataAccess.LoadData<Staff>(sql).ToList();
        }

       
        /// <summary>
        /// Product Rate 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="date"></param>
        /// <param name="rate"></param>
        /// <returns></returns>

        public static int CreateAndUpdateProductRate(int id, int productId, DateTime date, decimal rate)
        {
            ProductRate data = new ProductRate()
            {
                RateId = id,
                ProductId=productId,
                Date=date,
                Rate=rate
            };
            string sql;
            if (id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`productrate` SET
                        `ProductId` =@ProductId, `Date` =@Date, `Rate` = @Rate 
                        WHERE (`ID` ='"+id+"');";

            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`productrate` ( `ProductId`, `Date`, `Rate`) VALUES (@ProductId,@Date,@Rate);";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }

        public static List<ProductRate> GetProductRateList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"select p.ID as RateId, p.ProductId, p.Date,p.Rate ,pr.ProductName as ProductName from productrate p inner join product pr on 
                        p.ProductId=pr.ProductID where ID='" + id+"' ";
            }
            else
            {
                // finding all records 
                sql = @"select p.ID as RateId, p.ProductId, p.Date,p.Rate ,pr.ProductName as ProductName from productrate p inner join product pr on 
                        p.ProductId=pr.ProductID order by p.ID desc limit 20 ";
            }
            return MySqlDataAccess.LoadData<ProductRate>(sql).ToList();

        }


        public static void DeleteProductRate(int id)
        {

            string sql = "DELETE FROM `pumpmanagmentdb`.`productrate` WHERE (`ID` = '"+id+"');";
            MySqlDataAccess.DeleteData(sql );

        }






















        public static int CreateAndUpdateProductPurchase(int purchaseId, int productId, int supplierId, int tankerId,DateTime date, decimal purchaseQuantity, decimal purchaseAmount)
        {
            PurchaseProduct data = new PurchaseProduct()
            {
                PurchaseId=purchaseId,
                ProductsId=productId,
                SuppliersId=supplierId,
                TankersId=tankerId,
                PurchaseAmount=purchaseAmount,
                Quantity=purchaseQuantity,
                Date=date
            };
            string sql;
            if (purchaseId > 0)
            {
                sql = @"call pumpmanagmentdb.Update_PurchaseProduct(@ProductsId, @SuppliersId, @TankersId, @Date, @Quantity, @PurchaseAmount, @PurchaseId);";

            }
            else
            {
                sql = @"call pumpmanagmentdb.Inset_Into_ProductPurchase_And_Product(@ProductsId, @SuppliersId, @TankersId,@Date,@Quantity , @PurchaseAmount);";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }


        public static  int CreateAndUpdateProduct(string productName)
        {
            Product p = new Product()
            {
                ProductName = productName,
                Stock = 0
            };
            string sql = @"INSERT INTO `pumpmanagmentdb`.`product`
                            ( `ProductName`, `Stock`)
                            VALUES (@ProductName,@Stock);";
            return MySqlDataAccess.SaveData(sql, p);
        }
        public static List<Product>GetProductList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT SupplierID, FullName, Email, Address, ContactNumber, Remark FROM supplier where SupplierID='" + id + "'";
            }
            else
            {
                // finding all records 
                sql = @"SELECT *FROM product";
            }
            return MySqlDataAccess.LoadData<Product>(sql).ToList();

        }


        public static List<PurchaseProduct> GetPurchaseProductsList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"select 
                        p.PurchaseId,p.ProductsID as ProductsId ,pt.ProductName,
                        s.SupplierID as SuppliersId,s.FullName as SupplierName,t.TankerID as TankersId,
                        t.TankerName,p.Date,p.Quantity, p.PurchaseAmount,p.Remark
                        from purchaseproduct p inner join supplier s on p.SuppliersId=s.SupplierID
                                               inner join tanker   t on p.TankersId= t.TankerID 
                                               inner join product pt on p.ProductsId= pt.ProductID where p.PurchaseId='" + id+"' ";
            }
            else
            {
                // finding all records 
                sql = @"select 
                        p.PurchaseId,p.ProductsID as ProductsId ,pt.ProductName,
                        s.SupplierID as SuppliersId,s.FullName as SupplierName,t.TankerID as TankersId,
                        t.TankerName,p.Date,p.Quantity, p.PurchaseAmount,p.Remark
                        from purchaseproduct p inner join supplier s on p.SuppliersId=s.SupplierID
                                               inner join tanker   t on p.TankersId= t.TankerID 
                                               inner join product pt on p.ProductsId= pt.ProductID";
            }
            return MySqlDataAccess.LoadData<PurchaseProduct>(sql).ToList();

        }

        public static void DeleteProductPurchase(int PurchaseId)
        {
           
            string sql ="pumpmanagmentdb.Update_ProductStock_If_PurchaseProductRecordDelete";
           // MySqlDataAccess.UpdateData(sql, "_PurchaseId", PurchaseId);
           
        }






















        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        public static int CreateAndUpdateExpences(int Id, int staffid,decimal amount,string remark)
        {
            Expences data = new Expences()
            {
               ID=Id,
               StaffId=staffid,
               Amount=amount,
               Remark=remark

            };
            string sql;
            if (Id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`expences` SET `StaffId` = @StaffId,
                        `Remark` = @Remark, `Amount` = @Amount
                         WHERE(`ID` = '" + Id + "');";


            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`expences` ( `StaffId`, `Remark`, `Amount`) VALUES (@StaffId,@Remark,@Amount);";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }




        public static List<Expences> GetExpencesList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"select e.ID, e.StaffId,s.fullName as StaffName, e.Remark, e.Amount from expences e inner join staff s on e.StaffId=s.StaffId where ID='" + id + "'";
            }
            else
            {
                // finding all records 
                sql = @"select e.ID, e.StaffId,s.fullName as StaffName, e.Remark, e.Amount from expences e inner join staff s on e.StaffId=s.StaffId";
            }
            return MySqlDataAccess.LoadData<Expences>(sql).ToList();

        }

        public static void DeleteExpences(int id)
        {
            string sql = @"DELETE FROM `pumpmanagmentdb`.`expences` WHERE (`ID` = '" + id + "');";
            MySqlDataAccess.DeleteData(sql);
        }






        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




        /// <summary>
        /// Tanker Managment Code
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="contactNumber"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static int CreateAndUpdateTanker(int Id, string tankerName, decimal capacity,decimal maxdip,decimal mindip)
        {
            Tanker data = new Tanker()
            {
              TankerID=Id,
              TankerName= tankerName,
              Capacity=capacity,
              MaximumDip=maxdip,
              MinmumDip=mindip

            };
            string sql;
            if (Id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`tanker` SET `TankerName` = @TankerName,
                        `Capacity` = @Capacity, `MinmumDip` = @MinmumDip, `MaximumDip` = @MaximumDip
                         WHERE(`TankerID` = '" + Id + "');";
              

            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`tanker` (`TankerName`, `Capacity`, `MinmumDip`, `MaximumDip`) VALUES (@TankerName,@Capacity,@MinmumDip,@MaximumDip);
";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }




        public static List<Tanker> GetTankerList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT * FROM tanker where TankerID='" + id + "'";
            }
            else
            {
                // finding all records 
                sql = @"SELECT * FROM tanker";
            }
            return MySqlDataAccess.LoadData<Tanker>(sql).ToList();

        }

        public static void DeleteTanker(int id)
        {
            string sql = @"DELETE FROM `pumpmanagmentdb`.`tanker` WHERE (`TankerID` = '" + id + "');";
            MySqlDataAccess.DeleteData(sql);
        }






        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




        /// <summary>
        /// Code for Suppiler data access
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="contactNumber"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static int CreateAndUpdateSupplier(int Id, string fullName, string email, string address, string contactNumber, string remark)
        {
            Supplier data = new Supplier()
            {
                SupplierID = Id,
                FullName = fullName,
                Email = email,
                Address = address,
                ContactNumber = contactNumber,
                Remark = remark

            };
            string sql;
            if (Id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`Supplier` SET `FullName` = @FullName,
                        `Email` = @Email, `Address` = @Address, `ContactNumber` = @ContactNumber, 
                        `Remark` = @Remark WHERE(`SupplierID` = '" + Id + "')";

            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`supplier` (`FullName`, `Email`, `Address`, `ContactNumber`, `Remark`)
                                                                     VALUES (@FullName,@Email,@Address,@ContactNumber,@Remark);";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }

        public static List<Supplier> GetSupplierList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT SupplierID, FullName, Email, Address, ContactNumber, Remark FROM supplier where SupplierID='" + id + "'";
            }
            else
            {
                // finding all records 
                sql = @"SELECT SupplierID, FullName, Email, Address, ContactNumber, Remark FROM supplier";
            }
            return MySqlDataAccess.LoadData<Supplier>(sql).ToList();

        }

        public static void DeleteSuplier(int id)
        {
            string sql = @"DELETE FROM `pumpmanagmentdb`.`Supplier` WHERE (`SupplierID` = '" + id + "');";
            MySqlDataAccess.DeleteData(sql);
        }



        /// <summary>
        /// Machine Data Managment code
        /// </summary>
        /// <param name="id"></param>
        /// <param name="machineNumber"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public static int CreateAndUpdateMachine(int id, int machineNumber, string machineName)
        {
            Machine data = new Machine()
            {
                MachineID = id,
                MachineNumber=machineNumber,
                MachineName=machineName
            };
            string sql;
            if (id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`machine` SET `MachineName` = @MachineName , 'MachineNumber'= @MachineNumber WHERE (`MachineId` = '" + id + "');";

            }
            else
            {
                sql = @"INSERT INTO `pumpmanagmentdb`.`machine` ( `MachineNumber`, `MachineName`) VALUES (@MachineNumber,@MachineName);
";
            }


            return MySqlDataAccess.SaveData(sql, data);
        }


        public static int CreateNozzels( string nozzelName, int MachineId, int Id= 0)
        {
            Nozzels data = new Nozzels()
            {
                NozzelName=nozzelName,
                MachineId= MachineId
            };
            string sql;
            if (Id > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`nozzels` SET `NozzelName` = @NozzelName, `MachineId` = @MachineId WHERE (`MachineId` = '" + Id + "');";

            }
            else
            {
                sql = "call pumpmanagmentdb.Insert_Into_Mschine_Nozzels(@NozzelName)";
            }


       

            return MySqlDataAccess.SaveData(sql, data);
        }


//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //TODO-udate machine and nozzel table
        //machine are not update becuse of Machine number problem every time machine number is greater than 0 whenever I inser or Update I use Machine Number as fk in nozzels table 
        //becuse it creates an error when I insert data in both table 
        //so Dont Know what to do now 
        // one solution is I can create machine Id fild in Machine table and use it as a forien Ky 
        //ok I have search for some solution if no solution is fund I move forverd with so basic solution in which i don t use foregn ky and diractly insert values 





        // TODO-create Delete machine and Nozzle method in ModelManager class
        // TODO-create delete machine action 
        // TODO-create supplier index view as machine index view
        // TODO-Code for Curd operation of staff model

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<Machine> GetMchineList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT distinct machine.MachineNumber,machine.MachineName,machine.MachineId
                        FROM machine  left JOIN nozzels   ON machine.MachineId = nozzels.MachineId where machine.MachineId='" + id + "'";
            }
            else
            {

                //sql = @"SELECT machine.MachineName, machine.MachineNumber, nozzels.NozzelID,nozzels.NozzelName,nozzels.MachineNumber 
                //    FROM machine  left JOIN nozzels   ON machine.MachineNumber = nozzels.MachineNumber";
                sql = @"SELECT distinct machine.MachineNumber,machine.MachineName,machine.MachineId
                        FROM machine  left JOIN nozzels   ON machine.MachineId = nozzels.MachineId";
            }


            return MySqlDataAccess.LoadData<Machine>(sql).ToList();

        }

        public static List<Nozzels> GetMachineNozzels(int id = 0)
        {
            string sql;
           
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT nozzels.NozzelID,nozzels.NozzelName,nozzels.MachineId
                        FROM  nozzels  inner JOIN machine   ON machine.MachineId = nozzels.MachineId where machine.MachineId ='" + id + "'";
            }
            else
            {

                //sql = @"SELECT machine.MachineName, machine.MachineNumber, nozzels.NozzelID,nozzels.NozzelName,nozzels.MachineNumber 
                //    FROM machine  left JOIN nozzels   ON machine.MachineNumber = nozzels.MachineNumber";
                sql = @"SELECT nozzels.NozzelID,nozzels.NozzelName,nozzels.MachineId
                        FROM  nozzels  inner JOIN machine   ON machine.MachineId = nozzels.MachineId";
            }
           

            return MySqlDataAccess.LoadData<Nozzels>(sql).ToList();
            
        }

        public static void DeleteMachine(int id)
        {
            string sql = "call pumpmanagmentdb.Delete_Machine_and_Nozzels(@id)";
            MySqlDataAccess.DeleteData(sql,id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="fullName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="contactNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="Address"></param>
        /// <param name="salary"></param>
        /// <param name="designation"></param>
        /// <param name="isWorking"></param>
        /// <param name="totalLeavesInMonth"></param>
        /// <param name="totalDayOFAttendenceInMonth"></param>
        /// <returns></returns>
        public static int CreateAndUpdateStaff(int staffId, string fullName, string emailAddress, string contactNumber,
                         DateTime dateOfBirth, string Address, decimal salary, string designation,
                         bool isWorking, int totalLeavesInMonth, int totalDayOFAttendenceInMonth)
        {

            Staff data = new Staff()
            {
                StaffID = staffId,
                FullName = fullName,
                EmailAddress = emailAddress,
                ContactNumber = contactNumber,
                DateOfBirth = dateOfBirth,
                Address = Address,
                Salary = salary,
                Designation = designation,
                IsWorking = isWorking,
                TotalLeavesInMonth = totalLeavesInMonth,
                TotalDayOFAttendenceInMonth = totalDayOFAttendenceInMonth
            };
            string sql;
            if (staffId > 0)
            {
                sql = @"UPDATE `pumpmanagmentdb`.`staff` SET 
                                                            `FullName` =@FullName, 
                                                            `EmailAddress` = @EmailAddress,
                                                            `ContactNumber` =@ContactNumber ,
                                                            `DateOfBirth` =  @DateOfBirth , 
                                                            `Address` =@Address , 
                                                            `Salary` = @Salary , 
                                                            `Designation` =  @Designation,
                                                            `IsWorking` =  @IsWorking, 
                                                            `TotalLeavesInMonth` =@TotalLeavesInMonth ,
                                                            `TotalDayOFAttendenceInMonth` = @TotalDayOFAttendenceInMonth
                                                            WHERE (`StaffID` = '" + staffId+"'); ";

            }
            else
            {
                sql = @"INSERT INTO
                         `pumpmanagmentdb`.`staff` (`StaffID`, `FullName`, `EmailAddress`, `ContactNumber`, `DateOfBirth`,
                         `Address`, `Salary`, `Designation`, `IsWorking`, `TotalLeavesInMonth`, `TotalDayOFAttendenceInMonth`) 
                          VALUES(@StaffID, @FullName, @EmailAddress,
                                    @ContactNumber, @DateOfBirth, @Address,
                                    @Salary, @Designation,
                                    @IsWorking, @TotalLeavesInMonth,
                                    @TotalDayOFAttendenceInMonth); ";
            }

            return MySqlDataAccess.SaveData(sql, data);
        }


        public static List<Staff> GetStaffList(int id = 0)
        {
            string sql;
            if (id != 0)
            {
                //finding one record by id 

                sql = @"SELECT `StaffID`, `FullName`, `EmailAddress`, `ContactNumber`, `DateOfBirth`,
                         `Address`, `Salary`, `Designation`, `IsWorking`, `TotalLeavesInMonth`, `TotalDayOFAttendenceInMonth`
                from staff where  StaffID='" + id + "'";
            }
            else
            {
                // finding all records 
                sql = @"SELECT `StaffID`, `FullName`, `EmailAddress`, `ContactNumber`, `DateOfBirth`,
                         `Address`, `Salary`, `Designation`, `IsWorking`, `TotalLeavesInMonth`, `TotalDayOFAttendenceInMonth` FROM staff";
            }
            return MySqlDataAccess.LoadData<Staff>(sql).ToList();

        }
        public static void DeleteStaffMember(int id)
        {


            string sql = @"DELETE FROM `pumpmanagmentdb`.`staff` WHERE (`StaffID` = '" + id + "');";
            MySqlDataAccess.DeleteData(sql);
        }


    }
}
