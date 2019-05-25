using kompiuteriuRinkykla.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kompiuteriuRinkykla.Helpers
{
    public class PartSuggestor
    {
        private computerAssemblyContext DbContext;

        public PartSuggestor()
        {
            DbContext = new computerAssemblyContext();
        }

        public IEnumerable<Part> GetSuggestedParts(string[] PartIds)
        {
            var PIds = Array.ConvertAll(PartIds, Ids => int.Parse(Ids));
            List<Part> SuggestedParts = new List<Part>();
            var Parts = DbContext.Part
                .Where(p => PIds.Contains(p.Id))
                .Include(p => p.PartType)
                .ToList();

            foreach (Part P in Parts)
            {
                SuggestedParts.AddRange(GetSuggestedParts(P));
            }

            return SuggestedParts;
        }

        public IEnumerable<Part> GetSuggestedParts(Part BasePart)
        {
            double LowerKoef = 0.8;
            double UpperKoef = 1.2;
            IEnumerable<Part> SuggestedParts = DbContext.Part
                .Where(p => p.PartTypeId == BasePart.PartTypeId)
                .Where(p => p.Id != BasePart.Id);

            switch (BasePart.PartType.Name)
            {
                case "data_storage":
                    SuggestedParts = SuggestedParts
                        .Where(p => 
                        (p.MemoryGb > BasePart.MemoryGb * LowerKoef && p.MemoryGb < BasePart.MemoryGb * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                        //.Where(p => p.Type.Equals(BasePart.Type));
                    break;
                case "ram":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.MemoryGb > BasePart.MemoryGb * LowerKoef && p.MemoryGb < BasePart.MemoryGb * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef)
                        );
                    //.Where(p => p.Type.Equals(BasePart.Type));
                    break;
                case "processor":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.ProcessorFrequency > BasePart.ProcessorFrequency * LowerKoef && p.ProcessorFrequency < BasePart.ProcessorFrequency * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                    //.Where(p => p.Type.Equals(BasePart.Type));
                    break;
                case "computer_case":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.Width > BasePart.Width * LowerKoef && p.Width < BasePart.Width * UpperKoef
                        && p.Height > BasePart.Height * LowerKoef && p.Height < BasePart.Height * UpperKoef
                        && p.Length > BasePart.Length * LowerKoef && p.Length < BasePart.Length * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                    break;
                case "motherboard":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.MaxRam > BasePart.MaxRam * LowerKoef && p.MaxRam < BasePart.MaxRam * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                    //.Where(p => p.CpuConnType.Equals(BasePart.CpuConnType));
                    break;
                case "gpu":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.MemoryGb > BasePart.MemoryGb * LowerKoef && p.MemoryGb < BasePart.MemoryGb * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                    //.Where(p => p.RamMemoryType.Equals(BasePart.RamMemoryType));
                    break;
                case "psu":
                    SuggestedParts = SuggestedParts
                        .Where(p =>
                        (p.Power > BasePart.Power * LowerKoef && p.Power < BasePart.Power * UpperKoef)
                        || (p.Price > BasePart.Price * LowerKoef && p.Price < BasePart.Price * UpperKoef));
                    //.Where(p => p.EfficiencyRating.Equals(BasePart.EfficiencyRating));
                    break;
            }

            return SuggestedParts.ToList();
        }
    }
}
