using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Models
{
    public class ComputerPart :BaseEntity
    {
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
