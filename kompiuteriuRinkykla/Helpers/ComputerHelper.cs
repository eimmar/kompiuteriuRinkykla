using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kompiuteriuRinkykla.Models;

namespace kompiuteriuRinkykla.Helpers
{
    public class ComputerHelper
    {
        public SelectList DataStorage { get; set; }
        public SelectList Rams { get; set; }
        public SelectList Processors { get; set; }

        public SelectList ComputerCases { get; set; }
        public SelectList Motherboards { get; set; }

        public SelectList Gpus { get; set; }
        public SelectList Psus { get; set; }


        public ComputerHelper()
        {
            //Data Storage
            computerAssemblyContext computerAssemblyContext = new computerAssemblyContext();
            DataStorage = new SelectList(computerAssemblyContext.Part
                .Where(ds => ds.PartTypeId == 1)
                .ToList(), "Id", "Manufacturer");

            //Rams
            Rams = new SelectList(computerAssemblyContext.Part
                .Where(ds => ds.PartTypeId == 2)
                .ToList(), "Id", "Manufacturer");

            //Processors
            Processors = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 3)
               .ToList(), "Id", "Manufacturer");

            //Computer cases
            ComputerCases = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 4)
               .ToList(), "Id", "Manufacturer");

            //Motherboard
            Motherboards = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 5)
               .ToList(), "Id", "Manufacturer");

            //gpus
            Gpus = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 6)
               .ToList(), "Id", "Manufacturer");

            //psus
            Psus = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 7)
               .ToList(), "Id", "Manufacturer");
        }

      
    }

}
