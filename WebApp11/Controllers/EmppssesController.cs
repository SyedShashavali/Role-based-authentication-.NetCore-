using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp11.Models;

namespace WebApp11.Controllers
{
    [Authorize(Roles ="admin,Employee")]
    public class EmppssesController : Controller
    {
        private readonly webappContext _context;

        public EmppssesController(webappContext context)
        {
            _context = context;
        }

        // GET: Emppsses
        public async Task<IActionResult> Index()
        {
              return _context.Emppsses != null ? 
                          View(await _context.Emppsses.ToListAsync()) :
                          Problem("Entity set 'webappContext.Emppsses'  is null.");
        }

        // GET: Emppsses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emppsses == null)
            {
                return NotFound();
            }

            var emppss = await _context.Emppsses
                .FirstOrDefaultAsync(m => m.Eid == id);
            if (emppss == null)
            {
                return NotFound();
            }

            return View(emppss);
        }

        // GET: Emppsses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emppsses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Eid,Ename,Ejoin,Ejob,Esalary")] Emppss emppss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emppss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emppss);
        }

        // GET: Emppsses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emppsses == null)
            {
                return NotFound();
            }

            var emppss = await _context.Emppsses.FindAsync(id);
            if (emppss == null)
            {
                return NotFound();
            }
            return View(emppss);
        }

        // POST: Emppsses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Eid,Ename,Ejoin,Ejob,Esalary")] Emppss emppss)
        {
            if (id != emppss.Eid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emppss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmppssExists(emppss.Eid))
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
            return View(emppss);
        }

        // GET: Emppsses/Delete/5wcfx 
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emppsses == null)
            {
                return NotFound();
            }

            var emppss = await _context.Emppsses
                .FirstOrDefaultAsync(m => m.Eid == id);
            if (emppss == null)
            {
                return NotFound();
            }

            return View(emppss);
        }

        // POST: Emppsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emppsses == null)
            {
                return Problem("Entity set 'webappContext.Emppsses'  is null.");
            }
            var emppss = await _context.Emppsses.FindAsync(id);
            if (emppss != null)
            {
                _context.Emppsses.Remove(emppss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmppssExists(int id)
        {
          return (_context.Emppsses?.Any(e => e.Eid == id)).GetValueOrDefault();
        }
    }
}
