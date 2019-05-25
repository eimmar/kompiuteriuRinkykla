using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kompiuteriuRinkykla.Models;
using Microsoft.EntityFrameworkCore;

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
            for (int pTypeId = 1; pTypeId < 8; pTypeId++)
            {
                try
                {
                    ComputerPart CPart = computerAssemblyContext.ComputerPart
                        .Include(cp => cp.Part)
                        .Where(cp => cp.ComputerId == Computer.Id && cp.Part.PartTypeId == pTypeId)
                        .FirstOrDefault();

                    switch (pTypeId)
                    {
                        case 1:
                            SetSelectedValue(DataStorage, CPart);
                            break;
                        case 2:
                            SetSelectedValue(Rams, CPart);
                            break;
                        case 3:
                            SetSelectedValue(Processors, CPart);
                            break;
                        case 4:
                            SetSelectedValue(ComputerCases, CPart);
                            break;
                        case 5:
                            SetSelectedValue(Motherboards, CPart);
                            break;
                        case 6:
                            SetSelectedValue(Gpus, CPart);
                            break;
                        case 7:
                            SetSelectedValue(Psus, CPart);
                            break;
                    }
                }
                catch (ArgumentNullException e) { }
                catch (NullReferenceException e) { }
            }
        }

        public void SetSelectedValue(SelectList Parts, ComputerPart Cp)
        {
            var selected = Parts.Where(x => x.Value.Equals(Cp.Part.Id.ToString())).FirstOrDefault();
            if (selected != null)
            {
                selected.Selected = true;
            }
        }
    }
}
