using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kompiuteriuRinkykla.Models
{
    public partial class Part : BaseEntity
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
    
        public int PartTypeId { get; set; }
        public PartType PartType { get; set; }

        [JsonIgnore]
        public ICollection<ComputerPart> ComputerParts { get; set; }


        // PartType = data_storage
        public int MemoryGb { get; set; }
        public string Type { get; set; }
        public string DataStorageInterface { get; set; }
        public double Length { get; set; }

        // PartType = ram
        public string ConnectionType { get; set; }
        //public string Type { get; set; }
        //public int MemoryGb { get; set; }

        // PartType = processor
        //public string ConnectionType { get; set; }
        public double ProcessorFrequency { get; set; }
        public int CoreCount { get; set; }
        public int Power { get; set; }

        // PartType = computer_case
        public string Color { get; set; }
        //public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double MaxGpuLength { get; set; }
        public double MaxDataStorageLength { get; set; }
        public double MaxPsuLength { get; set; }
        public double MaxMotherboardLength { get; set; }

        // PartType = motherboard
        public string RamConnType { get; set; }
        public int RamSocketCount { get; set; }
        public int MaxRam { get; set; }
        public string CpuConnType { get; set; }
        //public double Length { get; set; }

        // PartType = gpu
        //public int MemoryGb { get; set; }
        //public string RamMemoryType { get; set; }
        //public int Power { get; set; }
        //public double Length { get; set; }
        public int MonitorSocketCount { get; set; }

        // PartType = psu
        //public int Power { get; set; }
        public string EfficiencyRating { get; set; }
        public int PciSocketCount { get; set; }
        //public double Length { get; set; }

        public override string ToString()
        {
            string Title = base.ToString();

            if (PartType != null && PartType.Name != null)
            {
                switch (PartType.Name)
                {
                    case "data_storage":
                        Title = Manufacturer + " " + Model + " " + MemoryGb + "GB " + Type + ", " + Price + " Eur";
                        break;
                    case "ram":
                        Title = Manufacturer + " " + Model + " " + MemoryGb + "GB " + Type + ", " + Price + " Eur";
                        break;
                    case "processor":
                        Title = Manufacturer + " " + Model + " " + ProcessorFrequency + "GHz " + CoreCount + " brand." + ", " + Price + " Eur";
                        break;
                    case "computer_case":
                        Title = Manufacturer + " " + Model + " " + Color + " " + Length + "cm x " + Width + "cm x " + Height + "cm" + ", " + Price + " Eur";
                        break;
                    case "motherboard":
                        Title = Manufacturer + " " + Model + ", " + Price + " Eur";
                        break;
                    case "gpu":
                        Title = Manufacturer + " " + Model + " " + MemoryGb + "GB " + Type + ", " + Price + " Eur";
                        break;
                    case "psu":
                        Title = Manufacturer + " " + Model + " " + Power + "W " + EfficiencyRating + ", " + Price + " Eur";
                        break;
                }
            }

            return Title;
        }
    }
}
