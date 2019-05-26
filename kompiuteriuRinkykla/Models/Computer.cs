using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Models
{
    public class Computer
    {
        [Required(ErrorMessage = "Laukas yra privalomas.")]
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<ComputerPart> ComputerParts { get; set; }

        public Computer()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }
    }
}
