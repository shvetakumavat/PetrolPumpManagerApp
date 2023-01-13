using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.ViewModels
{
    public class MachineCreateViewModel
    {
        public  Machine MachineModel { get; set; }
        public List<Nozzels> MachineNozzels { get; set; }
    }
}