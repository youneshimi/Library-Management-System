using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bibliothèque.Data;

namespace bibliothèque.Controllers
{
    public class AbonnesController : Controller
    {
        private readonly bibliothèqueContext _context;

        public AbonnesController(bibliothèqueContext context)
        {
            _context = context;
        }

        // GET: Abonnes
        public async Task<IActionResult> Index()
        {
              return _context.Abonne != null ? 
                          View(await _context.Abonne.ToListAsync()) :
                          Problem("Entity set 'bibliothèqueContext.Abonne'  is null.");
        }

        // GET: Abonnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abonne == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abonne == null)
            {
                return NotFound();
            }

            return View(abonne);
        }

        // GET: Abonnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abonnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom")] Abonne abonne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abonne);
        }

        // GET: Abonnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abonne == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonne.FindAsync(id);
            if (abonne == null)
            {
                return NotFound();
            }
            return View(abonne);
        }

        // POST: Abonnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom")] Abonne abonne)
        {
            if (id != abonne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonneExists(abonne.Id))
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
            return View(abonne);
        }

        // GET: Abonnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abonne == null)
            {
                return NotFound();
            }

            var abonne = await _context.Abonne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (abonne == null)
            {
                return NotFound();
            }

            return View(abonne);
        }

        // POST: Abonnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abonne == null)
            {
                return Problem("Entity set 'bibliothèqueContext.Abonne'  is null.");
            }
            var abonne = await _context.Abonne.FindAsync(id);
            if (abonne != null)
            {
                _context.Abonne.Remove(abonne);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonneExists(int id)
        {
          return (_context.Abonne?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
