using kompiuteriuRinkykla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Helpers
{
    public class PartFormHelper
    {
        public SelectList DataStorageTypes { get; set; }
        public SelectList RamTypes { get; set; }
        public SelectList GpuTypes { get; set; }

        public SelectList DataStorageInterfaces { get; set; }
        public SelectList RamInterfaces { get; set; }

        public SelectList RamConnectionTypes { get; set; }
        public SelectList ProcessorConnectionTypes { get; set; }

        public SelectList PsuEfficiencyRatings { get; set; }


        public PartFormHelper()
        {
            DataStorageTypes = new SelectList(new List<string> { "SSD", "HDD" });
            RamTypes = new SelectList(new List<string> { "DDR1", "DDR2", "DDR3", "DDR4", "DDR5" });
            GpuTypes = new SelectList(new List<string> {
                    "PCI",
                    "AGP",
                    "PCIe x16",
                    "PCIe x8",
                    "PCIe x1"
            });

            DataStorageInterfaces = new SelectList(new List<string> {
                "SAS 12 Gb/s",
                "SAS 6 Gb/s",
                "SAS 3 Gb/s",
                "SATA 6 Gb/s",
                "SATA 3 Gb/s",
                "SATA 1.5 Gb/s"
            });
            RamInterfaces = new SelectList(new List<string> {
                "DDR1", "DDR2", "DDR3", "DDR4", "DDR5"
            });

            RamConnectionTypes = new SelectList(new List<string> {
                        "184-pin DIMM",
                        "200-pin SODIMM",
                        "204-pin SODIMM",
                        "240-pin DIMM",
                        "260-pin SODIMM",
                        "284-pin DIMM",
                        "288-pin DIMM"
            });


            ProcessorConnectionTypes = new SelectList(new List<string> {
                        "AM1",
                        "AM2+",
                        "AM3",
                        "AM3+",
                        "AM4"
            });

            PsuEfficiencyRatings = new SelectList(new List<string> {
                "80+ Titanium",
                "80+ Platinum",
                "80+ Gold",
                "80+ Silver",
                "80+ Bronze",
                "80+"
            });
        }

        public void ValidatePart(Part Part, ControllerBase ModelState)
        {

        }
    }
}
