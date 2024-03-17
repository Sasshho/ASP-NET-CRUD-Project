using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Priut_za_jivotni.Data;
using Priut_za_jivotni.Models;

namespace Priut_za_jivotni.Controllers
{
    public class DogsController : Controller
    {
        private readonly Priut_za_jivotniContext _context;

        public DogsController(Priut_za_jivotniContext context)
        {
            _context = context;
        }

        // GET: Dogs
        public async Task<IActionResult> Index()
        {
              return _context.Dogs != null ? 
                          View(await _context.Dogs.ToListAsync()) :
                          Problem("Entity set 'Priut_za_jivotniContext.Dogs'  is null.");
        }

        // GET: Dogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dogs = await _context.Dogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogs == null)
            {
                return NotFound();
            }

            return View(dogs);
        }

        // GET: Dogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Breed,Age")] Dogs dogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogs);
        }

        // GET: Dogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dogs = await _context.Dogs.FindAsync(id);
            if (dogs == null)
            {
                return NotFound();
            }
            return View(dogs);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Breed,Age")] Dogs dogs)
        {
            if (id != dogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogsExists(dogs.Id))
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
            return View(dogs);
        }

        // GET: Dogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dogs == null)
            {
                return NotFound();
            }

            var dogs = await _context.Dogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogs == null)
            {
                return NotFound();
            }

            return View(dogs);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dogs == null)
            {
                return Problem("Entity set 'Priut_za_jivotniContext.Dogs'  is null.");
            }
            var dogs = await _context.Dogs.FindAsync(id);
            if (dogs != null)
            {
                _context.Dogs.Remove(dogs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogsExists(int id)
        {
          return (_context.Dogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
