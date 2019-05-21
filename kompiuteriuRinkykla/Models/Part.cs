using System;
using System.Collections.Generic;

namespace kompiuteriuRinkykla.Models
{
    public partial class Part : BaseEntity
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public PartType PartType { get; set; }

        // PartType = data_storage
        public int MemoryGb { get; set; }
        public string Type { get; set; }
        public int DataStorageInterface { get; set; }
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
    }
}
