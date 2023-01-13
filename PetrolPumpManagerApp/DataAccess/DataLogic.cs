using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PumpDBLibrary.BusinessLogic.ModelManager;

namespace PetrolPumpManagerApp.DataAccess
{
   static public class DataLogic
    {


        static public Tuple<List<MeterReading>, MeterReading, List<Staff>> MeterReadingList(int id = 0)
        {
            string date ="2022-11-23";
            var data = GetMeterReadingData(date);
            var sdata = GetStaffListBySale(date);
            List<MeterReading> modelList = new List<MeterReading>();
            List<Staff> Sm = new List<Staff>();
            MeterReading model = new MeterReading();
            foreach (var row in data)
            {
                if (id > 0)
                {

                    model.ID = row.ID;
                    model.ClosingReading = row.ClosingReading;
                    model.Date = row.Date;
                    model.MachineName = row.MachineName;
                    model.NozzelName = row.NozzelName;
              
                    
                }
                else
                {
                    modelList.Add(new MeterReading
                    {
                        ID = row.ID,
                        ClosingReading = row.ClosingReading,
                        MachineName=row.MachineName,
                        NozzelName=row.NozzelName,
                     
                    }) ;

                }

            }

            foreach (var d in sdata)
            {
                Sm.Add(
                    new Staff
                    {
                        StaffID=d.StaffID,
                        FullName=d.FullName
                    }
                    );
            }


           
            return new Tuple<List<MeterReading>, MeterReading,List<Staff>>(modelList, model,Sm);

        }

        static public Tuple<List<MeterReading>, MeterReading> getSalebysID(int sid)
        {
            string date = "2022-11-23";
            var data = GetSaleDataByStaffIDData(date, sid);
            List<MeterReading> m = new List<MeterReading>();
            MeterReading model = new MeterReading();
            foreach (var d in data.Item1)
            {
                m.Add(
                    new MeterReading
                    {
                        ProductName = d.ProductName,
                        SaleInLeters=d.SaleInLeters,
                        SaleAmount=d.SaleAmount
                    }
                    );
                
            }
            model.SaleAmount = data.Item2.SaleAmount;
            model.SaleInLeters = data.Item2.SaleInLeters;
            return new Tuple<List<MeterReading>, MeterReading>(m,model);
        }
        static public Tuple<List<ProductRate>, ProductRate> RateList(int id = 0)
        {
            var data = GetProductRateList(id);
            List<ProductRate> modelList = new List<ProductRate>();
            ProductRate model = new ProductRate();
            foreach (var row in data)
            {
                if (id > 0)
                {
                    model.RateId = row.RateId;
                    model.ProductId = row.ProductId;
                    model.ProductName = row.ProductName;
                    model.Date = row.Date;
                    model.Rate = row.Rate;
                }
                else
                {
                    modelList.Add(new ProductRate
                    {
                       RateId = row.RateId,
                       ProductId = row.ProductId,
                       ProductName = row.ProductName,
                      Date = row.Date,
                       Rate = row.Rate
                    });

                }

            }

            return new Tuple<List<ProductRate>, ProductRate>(modelList, model);

        }

        static public Tuple< List<Staff>,Staff> StaffList(int id = 0)
        {
            var data = GetStaffList(id);
            List<Staff> modelList = new List<Staff>();
            Staff model = new Staff();
            foreach (var row in data)
            {
                if (id > 0)
                {
                    model.StaffID = row.StaffID;
                    model.FullName = row.FullName;
                    model.EmailAddress = row.EmailAddress;
                    model.ContactNumber = row.ContactNumber;
                    model.Salary = row.Salary;
                    model.TotalDayOFAttendenceInMonth = row.TotalDayOFAttendenceInMonth;
                    model.TotalLeavesInMonth = row.TotalLeavesInMonth;
                    model.Address = row.Address;
                    model.DateOfBirth = row.DateOfBirth;
                    model.Designation = row.Designation;
                    model.IsWorking = row.IsWorking;
                }
                else
                {
                    modelList.Add(new Staff
                    {
                        StaffID = row.StaffID,
                        FullName = row.FullName,
                        EmailAddress = row.EmailAddress,
                        ContactNumber = row.ContactNumber,
                        Salary = row.Salary,
                        TotalDayOFAttendenceInMonth = row.TotalDayOFAttendenceInMonth,
                        TotalLeavesInMonth = row.TotalLeavesInMonth,
                        Address = row.Address,
                        DateOfBirth = row.DateOfBirth,
                        Designation = row.Designation,
                        IsWorking = row.IsWorking

                    });

                }

            }

            return new Tuple<List<Staff>, Staff>(modelList, model);

        }


        static public Tuple< List<Product>,Product> ProductList(int id = 0)
        {
            var data = GetProductList(id);
            List<Product> modelList = new List<Product>();
            Product model = new Product();
            foreach (var row in data)
            {
                if (id > 0)
                {

                    model.ProductID = row.ProductID;
                    model.ProductName = row.ProductName;
                    model.Stock = row.Stock;

                }
                else
                {
                    modelList.Add(new Product
                    {
                        ProductID = row.ProductID,
                        ProductName = row.ProductName,
                        Stock = row.Stock

                    });
                }
               

            }

            return new Tuple<List<Product>, Product>(modelList, model);

        }

        static public Tuple< List<Tanker>,Tanker> TankerList(int id = 0)
        {
            var data = GetTankerList(id);
            List<Tanker> modelList = new List<Tanker>();
            Tanker model = new Tanker();
            foreach (var row in data)
            {
                if (id > 0)
                {
                    model.TankerID = row.TankerID;
                    model.TankerName = row.TankerName;
                    model.Capacity = row.Capacity;
                    model.MaximumDip = row.MaximumDip;
                    model.MinmumDip = row.MinmumDip;

                }
                else
                {
                    modelList.Add(new Tanker
                    {
                        TankerID = row.TankerID,
                        TankerName = row.TankerName,
                        Capacity = row.Capacity,
                        MaximumDip = row.MaximumDip,
                        MinmumDip = row.MinmumDip

                    });

                }

            }

            return new Tuple<List<Tanker>, Tanker>(modelList, model);

        }


        static public Tuple<List<Supplier>,Supplier> SupplierList(int id = 0)
        {
            var data = GetSupplierList(id);
            List<Supplier> modelList = new List<Supplier>();
            Supplier model = new Supplier();
            foreach (var row in data)
            {
                if (id > 0)
                {

                    model.SupplierID = row.SupplierID;
                    model.FullName = row.FullName;
                    model.Address = row.Address;
                    model.Email = row.Email;
                    model.Remark = row.Remark;
                    model.ContactNumber = row.ContactNumber;

                }
                else
                {
                    modelList.Add(new Supplier
                    {
                        SupplierID = row.SupplierID,
                        FullName = row.FullName,
                        Address = row.Address,
                        Email = row.Email,
                        Remark = row.Remark,
                        ContactNumber = row.ContactNumber

                    });
                }

            }

            return new Tuple<List<Supplier>, Supplier>(modelList, model);

        }


        static public Tuple<List<PurchaseProduct>,PurchaseProduct> PurchaseProductsList(int id = 0)
        {
            
            List<PurchaseProduct> modelList = new List<PurchaseProduct>();
            PurchaseProduct model = new PurchaseProduct();
            var data = GetPurchaseProductsList(id);
            foreach (var row in data)
            {
                if (id > 0)
                {

                    model.PurchaseId = row.PurchaseId;
                    model.ProductsId = row.ProductsId;
                    model.ProductName = row.ProductName;
                    model.SuppliersId = row.SuppliersId;
                    model.SupplierName = row.SupplierName;
                    model.TankersId = row.TankersId;
                    model.TankerName = row.TankerName;
                    model.PurchaseAmount = row.PurchaseAmount;
                    model.Quantity = row.Quantity;
                    model.Remark = row.Remark;
                }
                else
                {
                    modelList.Add(new PurchaseProduct

                    {
                          PurchaseId = row.PurchaseId,
                          ProductsId = row.ProductsId,
                          ProductName = row.ProductName,
                          SuppliersId = row.SuppliersId,
                          SupplierName = row.SupplierName,
                          TankersId = row.TankersId,
                          TankerName = row.TankerName,
                          PurchaseAmount = row.PurchaseAmount,
                          Quantity = row.Quantity,
                          Remark = row.Remark,

                } );
                }
                  

            }

            return new Tuple<List<PurchaseProduct>, PurchaseProduct>(modelList,model);

        }

        static public Tuple<List<Machine>, Machine> MachineList(int id = 0)
        {
            List<Machine> modelList = new List<Machine>();
            Machine model = new Machine();
            var data = GetMchineList(id);
            foreach (var row in data)
            {
                if (id > 0)
                {

                    model.MachineNumber = row.MachineNumber;
                    model.MachineName = row.MachineName;
                    model.MachineID = row.MachineID;
                }
                else
                {
                    modelList.Add(new Machine

                    {

                        MachineNumber = row.MachineNumber,
                        MachineName = row.MachineName,
                        MachineID = row.MachineID

                    });
                }


            }

            return new Tuple<List<Machine>,Machine >(modelList, model);
        }
        static public List<Nozzels> NozzelList(int id = 0)
        {
            List<Nozzels> modelList = new List<Nozzels>();
     
            var data = GetMachineNozzels(id);
            modelList.Add(new Nozzels
            {
                NozzelId = 0,
                NozzelName = "--Select--",
                MachineId = 0
            }) ;
            foreach (var row in data)
            {
               
                    modelList.Add(new Nozzels

                    {
                        NozzelName = row.NozzelName,
                        NozzelId = row.NozzelId,
                        MachineId = row.MachineId

                    });
                


            }

            return modelList;
        }

       
    }
}