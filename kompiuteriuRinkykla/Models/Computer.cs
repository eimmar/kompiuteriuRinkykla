using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Models
{
    public class Computer : BaseEntity
    {
        public string Name { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime EditDate { get; set; }
        public string Purpose { get; set; }

        public ICollection<ComputerPart> ComputerParts { get; set; }
    }
}
