using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniPlanner.Areas.Identity.Data;
using UniPlanner.Models;

namespace UniPlanner.Controllers
{
    public class UniProgrammeController : Controller
    {
        private readonly UniPlannerContext _context;

        public UniProgrammeController(UniPlannerContext context)
        {
            _context = context;
        }

        // GET: UniProgramme
        public async Task<IActionResult> Index()
        {
              return _context.UniProgramme != null ? 
                          View(await _context.UniProgramme.ToListAsync()) :
                          Problem("Entity set 'UniPlannerContext.UniProgramme'  is null.");
        }

        // GET: UniProgramme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniProgramme == null)
            {
                return NotFound();
            }

            var uniProgramme = await _context.UniProgramme
                .FirstOrDefaultAsync(m => m.UniProgrammeID == id);
            if (uniProgramme == null)
            {
                return NotFound();
            }

            return View(uniProgramme);
        }

        // GET: UniProgramme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniProgramme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniProgrammeID,Link,RankScore")] UniProgramme uniProgramme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uniProgramme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uniProgramme);
        }

        // GET: UniProgramme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniProgramme == null)
            {
                return NotFound();
            }

            var uniProgramme = await _context.UniProgramme.FindAsync(id);
            if (uniProgramme == null)
            {
                return NotFound();
            }
            return View(uniProgramme);
        }

        // POST: UniProgramme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UniProgrammeID,Link,RankScore")] UniProgramme uniProgramme)
        {
            if (id != uniProgramme.UniProgrammeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uniProgramme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniProgrammeExists(uniProgramme.UniProgrammeID))
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
            return View(uniProgramme);
        }

        // GET: UniProgramme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniProgramme == null)
            {
                return NotFound();
            }

            var uniProgramme = await _context.UniProgramme
                .FirstOrDefaultAsync(m => m.UniProgrammeID == id);
            if (uniProgramme == null)
            {
                return NotFound();
            }

            return View(uniProgramme);
        }

        // POST: UniProgramme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniProgramme == null)
            {
                return Problem("Entity set 'UniPlannerContext.UniProgramme'  is null.");
            }
            var uniProgramme = await _context.UniProgramme.FindAsync(id);
            if (uniProgramme != null)
            {
                _context.UniProgramme.Remove(uniProgramme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniProgrammeExists(int id)
        {
          return (_context.UniProgramme?.Any(e => e.UniProgrammeID == id)).GetValueOrDefault();
        }
    }
}
