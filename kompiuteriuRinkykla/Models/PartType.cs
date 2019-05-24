using System;
using System.Collections.Generic;

namespace kompiuteriuRinkykla.Models
{
    public partial class PartType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Part> Parts { get; set; }

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
