using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using club.Data;
using club.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace club.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Activite.Include(a => a.Club).Include(a => a.Membre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Activites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activite == null)
            {
                return NotFound();
            }

            var activite = await _context.Activite
                .Include(a => a.Club)
                .Include(a => a.Membre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // GET: Activites/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Set<Club>(), "Id", "Nom");
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email");
            return View();
        }

        // POST: Activites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,ClubId,MembreId")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Set<Club>(), "Id", "Nom", activite.ClubId);
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", activite.MembreId);
            return View(activite);
        }

        // GET: Activites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activite == null)
            {
                return NotFound();
            }

            var activite = await _context.Activite.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Set<Club>(), "Id", "Nom", activite.ClubId);
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", activite.MembreId);
            return View(activite);
        }

        // POST: Activites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,ClubId,MembreId")] Activite activite)
        {
            if (id != activite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiviteExists(activite.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Set<Club>(), "Id", "Nom", activite.ClubId);
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", activite.MembreId);
            return View(activite);
        }

        // GET: Activites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activite == null)
            {
                return NotFound();
            }

            var activite = await _context.Activite
                .Include(a => a.Club)
                .Include(a => a.Membre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activite == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Activite'  is null.");
            }
            var activite = await _context.Activite.FindAsync(id);
            if (activite != null)
            {
                _context.Activite.Remove(activite);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiviteExists(int id)
        {
          return _context.Activite.Any(e => e.Id == id);
        }
    }
}
