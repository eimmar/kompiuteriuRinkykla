using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kompiuteriuRinkykla.Models;

namespace kompiuteriuRinkykla.Controllers
{
    public class ComputersController : Controller
    {
        private readonly computerAssemblyContext _context;

        public ComputersController(computerAssemblyContext context)
        {
            _context = context;
        }

        // GET: Computers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Computer.ToListAsync());
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        public async Task<ActionResult> DetailsByPurpose(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Purpose,Id,DateCreated,DateModified")] Computer computer)
        {
            int DataStorage = int.Parse(Request.Form["data_storage"]);
            int Ram = int.Parse(Request.Form["rams"]);
            int Processor = int.Parse(Request.Form["processors"]);
            int ComputerCase = int.Parse(Request.Form["computer_case"]);
            int Motherboard = int.Parse(Request.Form["motherboards"]);
            int Gpu = int.Parse(Request.Form["gpus"]);
            int Psu = int.Parse(Request.Form["psus"]);
            List<int> partIds = new List<int> {
                DataStorage,
                Ram,
                Processor,
                ComputerCase,
                Motherboard,
                Gpu,
                Psu
            };
            var parts = _context.Part.Where(p => partIds.Contains(p.Id));
            List<ComputerPart> computerParts = new List<ComputerPart>();

            foreach (Part p in parts)
            {
                ComputerPart cp = new ComputerPart { Part = p, Computer = computer };
                _context.ComputerPart.Add(cp);
            }

            if (ModelState.IsValid)
            {
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        public IActionResult ChooseComputerByPurpose(string purpose)
        {
            var computers = from c in _context.Computer select c;
            if (!String.IsNullOrEmpty(purpose))
                computers = computers.Where(c => c.Purpose.Equals(purpose));
            return View(computers.ToList());
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Purpose,Id,DateCreated,DateModified")] Computer computer)
        {
            if (id != computer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.Id))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computer = await _context.Computer.FindAsync(id);
            _context.Computer.Remove(computer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
            return _context.Computer.Any(e => e.Id == id);
        }
    }
}
