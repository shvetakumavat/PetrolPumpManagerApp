using PetrolPumpManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPumpManagerApp.ViewModels
{
    public class MachineViewModel
    {
        public List<Machine> Machines = new List<Machine>();
        public List<Nozzels> MachineNozzles { get; set; }
    }
}