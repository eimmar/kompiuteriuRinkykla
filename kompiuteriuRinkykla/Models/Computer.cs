using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Models
{
    public class Computer : BaseEntity
    {
        [Required(ErrorMessage = "Laukas yra privalomas.")]
        public string Name { get; set; }
        public string Purpose { get; set; }

        public ICollection<ComputerPart> ComputerParts { get; set; }
    }
}
