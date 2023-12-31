﻿using System;
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
    public class MajorsOfferedController : Controller
    {
        private readonly UniPlannerContext _context;

        public MajorsOfferedController(UniPlannerContext context)
        {
            _context = context;
        }

        // GET: MajorsOffered
        public async Task<IActionResult> Index()
        {
              return _context.MajorsOffered != null ? 
                          View(await _context.MajorsOffered.ToListAsync()) :
                          Problem("Entity set 'UniPlannerContext.MajorsOffered'  is null.");
        }

        // GET: MajorsOffered/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MajorsOffered == null)
            {
                return NotFound();
            }

            var majorsOffered = await _context.MajorsOffered
                .FirstOrDefaultAsync(m => m.MajorsOfferedID == id);
            if (majorsOffered == null)
            {
                return NotFound();
            }

            return View(majorsOffered);
        }

        // GET: MajorsOffered/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MajorsOffered/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MajorsOfferedID,Name,Link")] MajorsOffered majorsOffered)
        {
            if (ModelState.IsValid)
            {
                _context.Add(majorsOffered);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(majorsOffered);
        }

        // GET: MajorsOffered/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MajorsOffered == null)
            {
                return NotFound();
            }

            var majorsOffered = await _context.MajorsOffered.FindAsync(id);
            if (majorsOffered == null)
            {
                return NotFound();
            }
            return View(majorsOffered);
        }

        // POST: MajorsOffered/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MajorsOfferedID,Name,Link")] MajorsOffered majorsOffered)
        {
            if (id != majorsOffered.MajorsOfferedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(majorsOffered);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MajorsOfferedExists(majorsOffered.MajorsOfferedID))
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
            return View(majorsOffered);
        }

        // GET: MajorsOffered/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MajorsOffered == null)
            {
                return NotFound();
            }

            var majorsOffered = await _context.MajorsOffered
                .FirstOrDefaultAsync(m => m.MajorsOfferedID == id);
            if (majorsOffered == null)
            {
                return NotFound();
            }

            return View(majorsOffered);
        }

        // POST: MajorsOffered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MajorsOffered == null)
            {
                return Problem("Entity set 'UniPlannerContext.MajorsOffered'  is null.");
            }
            var majorsOffered = await _context.MajorsOffered.FindAsync(id);
            if (majorsOffered != null)
            {
                _context.MajorsOffered.Remove(majorsOffered);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajorsOfferedExists(int id)
        {
          return (_context.MajorsOffered?.Any(e => e.MajorsOfferedID == id)).GetValueOrDefault();
        }
    }
}
