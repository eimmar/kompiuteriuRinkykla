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

        computerAssemblyContext DBContext;

        public ComputerHelper(Computer Computer)
        {
            DBContext = new computerAssemblyContext();

            DataStorage = GetPartSelectList("data_storage");
            Rams = GetPartSelectList("ram");
            Processors = GetPartSelectList("processor");
            ComputerCases = GetPartSelectList("computer_case");
            Motherboards = GetPartSelectList("motherboard");
            Gpus = GetPartSelectList("gpu");
            Psus = GetPartSelectList("psu");
 
            PcPurposes = new SelectList(new List<string> { "Mokslams", "Darbui", "Žaidimams", "Video/grafiniam kūrimui" });

            // Setting default selected values
            for (int pTypeId = 1; pTypeId < 8; pTypeId++)
            {
                try
                {
                    ComputerPart CPart = Computer.ComputerParts.Where(cp => cp.Part.PartTypeId == pTypeId).FirstOrDefault();
                    SelectList Parts = new SelectList(new List<string>());

                    switch (pTypeId)
                    {
                        case 1:
                            Parts = DataStorage;
                            break;
                        case 2:
                            Parts = Rams;
                            break;
                        case 3:
                            Parts = Processors;
                            break;
                        case 4:
                            Parts = ComputerCases;
                            break;
                        case 5:
                            Parts = Motherboards;
                            break;
                        case 6:
                            Parts = Gpus;
                            break;
                        case 7:
                            Parts = Psus;
                            break;
                    }
                    SetSelectedValue(Parts, CPart);
                }
                catch (ArgumentNullException e) { }
                catch (NullReferenceException e) { }
                catch (InvalidOperationException e) { }
            }
        }

        SelectList GetPartSelectList(string PartTypeName)
        {
            return new SelectList(DBContext.Part
               .Where(ds => ds.PartType.Name == PartTypeName)
               .Include(p => p.PartType)
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.ToString() })
                .ToList(), "Value", "Text");
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
