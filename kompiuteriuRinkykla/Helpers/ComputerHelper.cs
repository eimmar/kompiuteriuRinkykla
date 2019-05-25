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

        public SelectList PcPurposes { get; set; }


        public ComputerHelper(Computer Computer)
        {
            //Data Storage
            computerAssemblyContext computerAssemblyContext = new computerAssemblyContext();
            DataStorage = new SelectList(computerAssemblyContext.Part
                .Where(ds => ds.PartTypeId == 1)
                .Select(p => new SelectListItem {Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.MemoryGb + "GB " + p.Type + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //Rams
            Rams = new SelectList(computerAssemblyContext.Part
                .Where(ds => ds.PartTypeId == 2)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.MemoryGb + "GB " + p.Type + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //Processors
            Processors = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 3)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.ProcessorFrequency + "GHz " + p.CoreCount + " brand." + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //Computer cases
            ComputerCases = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 4)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.Color + " " + p.Length + "cm x " + p.Width + "cm x " + p.Height + "cm" + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //Motherboard
            Motherboards = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 5)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //gpus
            Gpus = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 6)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.MemoryGb + "GB " + p.Type + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            //psus
            Psus = new SelectList(computerAssemblyContext.Part
               .Where(ds => ds.PartTypeId == 7)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Manufacturer + " " + p.Model + " " + p.Power + "W " + p.EfficiencyRating + ", " + p.Price + " Eur" })
                .ToList(), "Value", "Text");

            PcPurposes = new SelectList(new List<string> { "Mokslams", "Darbui", "Žaidimams", "Video/grafiniam kūrimui" });

            // Setting default selected values
            try
            {
           //     Computer.ComputerParts.Where(cp => cp.Part.PartTypeId == 1).FirstOrDefault()
            //    SetSelectedValue(DataStorage);
            } catch (ArgumentNullException e) { }
        }

        public void SetSelectedValue(SelectList Parts, ComputerPart Part)
        {
            var selected = Parts.Where(x => x.Value.Equals(Part.Id.ToString())).FirstOrDefault();
            if (selected != null)
            {
                selected.Selected = true;
            }
        }
    }
}
