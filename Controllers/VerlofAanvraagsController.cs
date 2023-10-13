using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Geprofs3.Data;
using Geprofs3.Models;

namespace Geprofs3.Controllers
{
    public class VerlofAanvraagsController : Controller
    {
        private readonly Geprofs3Context _context;

        public VerlofAanvraagsController(Geprofs3Context context)
        {
            _context = context;
        }

        // GET: VerlofAanvraags
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var aanvragen = from a in _context.VerlofAanvraag
        //                 select a;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        aanvragen = aanvragen.Where(s => s.Naam!.Contains(searchString));
        //    }

        //    return View(await aanvragen.ToListAsync());
        //}

        public async Task<IActionResult> Index(string columns, string searchString)
        {
            var aanvragen = from a in _context.VerlofAanvraag
                            select a;

            Console.WriteLine(columns);

            if (!String.IsNullOrEmpty(columns) && !String.IsNullOrEmpty(searchString))
            {
                switch (columns)
                {
                    case "naam":
                        aanvragen = aanvragen.Where(s => s.Naam!.Contains(searchString));
                        break;

                    case "rol":
                        aanvragen = aanvragen.Where(s => s.Rol!.Contains(searchString));
                        break;

                    case "afdeling":
                        aanvragen = aanvragen.Where(s => s.Afdeling!.Contains(searchString));
                        break;

                    case "status":
                        aanvragen = aanvragen.Where(s => s.Status!.Contains(searchString));
                        break;

                    default:
                        break;
                }
            }

            return View(await aanvragen.ToListAsync());
        }

        // GET: VerlofAanvraags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VerlofAanvraag == null)
            {
                return NotFound();
            }

            var verlofAanvraag = await _context.VerlofAanvraag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verlofAanvraag == null)
            {
                return NotFound();
            }

            return View(verlofAanvraag);
        }

        // GET: VerlofAanvraags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VerlofAanvraags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Rol,Afdeling,BeginDatum,EindDatum,Reden,Status")] VerlofAanvraag verlofAanvraag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verlofAanvraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verlofAanvraag);
        }

        // GET: VerlofAanvraags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VerlofAanvraag == null)
            {
                return NotFound();
            }

            var verlofAanvraag = await _context.VerlofAanvraag.FindAsync(id);
            if (verlofAanvraag == null)
            {
                return NotFound();
            }
            return View(verlofAanvraag);
        }

        // POST: VerlofAanvraags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Rol,Afdeling,BeginDatum,EindDatum,Reden,Status")] VerlofAanvraag verlofAanvraag)
        {
            if (id != verlofAanvraag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verlofAanvraag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerlofAanvraagExists(verlofAanvraag.Id))
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
            return View(verlofAanvraag);
        }

        // GET: VerlofAanvraags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VerlofAanvraag == null)
            {
                return NotFound();
            }

            var verlofAanvraag = await _context.VerlofAanvraag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verlofAanvraag == null)
            {
                return NotFound();
            }

            return View(verlofAanvraag);
        }

        // POST: VerlofAanvraags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VerlofAanvraag == null)
            {
                return Problem("Entity set 'Geprofs3Context.VerlofAanvraag'  is null.");
            }
            var verlofAanvraag = await _context.VerlofAanvraag.FindAsync(id);
            if (verlofAanvraag != null)
            {
                _context.VerlofAanvraag.Remove(verlofAanvraag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerlofAanvraagExists(int id)
        {
          return (_context.VerlofAanvraag?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
