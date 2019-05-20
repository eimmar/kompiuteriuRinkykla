using System;
using System.Collections.Generic;

namespace kompiuteriuRinkykla.Models
{
    public partial class Part
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Qty { get; set; }
    }
}
