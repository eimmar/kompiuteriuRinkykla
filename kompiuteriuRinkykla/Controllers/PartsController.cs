using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kompiuteriuRinkykla.Models;
using kompiuteriuRinkykla.Helpers;

namespace kompiuteriuRinkykla.Controllers
{
    public class PartsController : Controller
    {
        private readonly computerAssemblyContext _context;

        public PartsController(computerAssemblyContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Part.Include(p => p.PartType).ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Part
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/AddPart
        public IActionResult AddPart()
        {
            return View(); 
        }

        // GET: Parts/Create
        public IActionResult Create(string partType)
        {      
            var partTypeObj = _context.PartType.FirstOrDefault(m => m.Name.Equals(partType));
            if (partTypeObj == null)
            {
                return NotFound();
            }

            ViewData["PartType"] = partTypeObj;
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manufacturer,Model,Code,Price,Qty,MemoryGb,Type,DataStorageInterface,Length,ConnectionType,ProcessorFrequency,CoreCount,Power,Color,Width,Height,MaxGpuLength,MaxDataStorageLength,MaxPsuLength,MaxMotherboardLength,RamConnType,RamSocketCount,MaxRam,CpuConnType,MonitorSocketCount,EfficiencyRating,PciSocketCount,DateCreated,DateModified,PartTypeId")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Part.Add(part);
                await _context.SaveChangesAsync();
                TempData["success"] = "Detalė sukurta.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var partTypeObj = _context.PartType.FirstOrDefault(m => m.Id == part.PartTypeId);
                ViewData["PartType"] = partTypeObj;
            }
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Part.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var OldPart = await _context.Part.FindAsync(id);
            if (OldPart == null)
            {
                return NotFound();
            }
            int.TryParse(Request.Form["qty"], out int Qty);
            OldPart.Qty = Qty;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(OldPart);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Likutis atnaujintas.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["error"] = "Klaida atnaujinant likutį.";
                    if (!PartExists(OldPart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(OldPart);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Part
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.Part.FindAsync(id);
            _context.Part.Remove(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Parts/RelatedParts
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> RelatedParts()
        {
            var Parts = Request.Form["PIds[]"].ToArray().Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToArray();
            if (Parts.Count() == 0)
            {
                return Json(new { });
            }

            PartSuggestor Ps = new PartSuggestor();
            return Json(Ps.GetSuggestedParts(Parts));
        }

        private bool PartExists(int id)
        {
            return _context.Part.Any(e => e.Id == id);
        }
    }
}
