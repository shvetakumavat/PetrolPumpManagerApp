﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.Models
{
    public class HSDMSDSales
    {
        public int ID { get; set; }
        public decimal HSDSaleInLtr { get; set; }
        public decimal MSDSaleInLtr { get; set; }
        public decimal OverAllSaleInLtr { get; set; }
        public decimal HSDSaleInAmt { get; set; }
        public decimal MSDSaleInAmt { get; set; }
        public decimal OverAllSaleInAmt { get; set; }
        public string SaleDate { get; set; }
    }
}