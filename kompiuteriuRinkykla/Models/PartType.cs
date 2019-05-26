using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace kompiuteriuRinkykla.Models
{
    public partial class PartType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Part> Parts { get; set; }

        public PartType()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }

        public override string ToString()
        {
            string Title = "";
            switch (Name)
            {
                case "data_storage":
                    Title = "Duomenų talpykla";
                    break;
                    case "ram":
                    Title = "RAM";
                    break;
                case "processor":
                    Title = "Procesorius";
                    break;
                case "computer_case":
                    Title = "Kompiuterio korpusas";
                    break;
                case "motherboard":
                    Title = "Motininė plokštė";
                    break;
                case "gpu":
                    Title = "Vaizdo plokštė";
                    break;
                case "psu":
                    Title = "Maitinimo blokas";
                    break;
            }

            return Title;
        }
    }
}
