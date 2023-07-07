using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using club.Data;
using club.Models;

namespace club.Controllers
{
    public class ResponsablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsables
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Responsable.Include(r => r.Membre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Responsables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Responsable == null)
            {
                return NotFound();
            }

            var responsable = await _context.Responsable
                .Include(r => r.Membre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsable == null)
            {
                return NotFound();
            }

            return View(responsable);
        }

        // GET: Responsables/Create
        public IActionResult Create()
        {
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email");
            return View();
        }

        // POST: Responsables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Description,Date_Debut,Date_Fin,MembreId")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", responsable.MembreId);
            return View(responsable);
        }

        // GET: Responsables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Responsable == null)
            {
                return NotFound();
            }

            var responsable = await _context.Responsable.FindAsync(id);
            if (responsable == null)
            {
                return NotFound();
            }
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", responsable.MembreId);
            return View(responsable);
        }

        // POST: Responsables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,Date_Debut,Date_Fin,MembreId")] Responsable responsable)
        {
            if (id != responsable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsableExists(responsable.Id))
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
            ViewData["MembreId"] = new SelectList(_context.Membre, "Id", "Email", responsable.MembreId);
            return View(responsable);
        }

        // GET: Responsables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Responsable == null)
            {
                return NotFound();
            }

            var responsable = await _context.Responsable
                .Include(r => r.Membre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsable == null)
            {
                return NotFound();
            }

            return View(responsable);
        }

        // POST: Responsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Responsable == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Responsable'  is null.");
            }
            var responsable = await _context.Responsable.FindAsync(id);
            if (responsable != null)
            {
                _context.Responsable.Remove(responsable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsableExists(int id)
        {
          return _context.Responsable.Any(e => e.Id == id);
        }
    }
}
