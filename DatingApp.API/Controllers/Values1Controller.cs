using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data;
using DatingApp.API.Models;

namespace DatingApp.API.Controllers
{
    public class Values1Controller : Controller
    {
        private readonly DataContext _context;

        public Values1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: Values1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Values.ToListAsync());
        }

        // GET: Values1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Values
                .FirstOrDefaultAsync(m => m.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        // GET: Values1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Values1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Value value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(value);
        }

        // GET: Values1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Values.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        // POST: Values1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Value value)
        {
            if (id != value.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValueExists(value.Id))
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
            return View(value);
        }

        // GET: Values1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var value = await _context.Values
                .FirstOrDefaultAsync(m => m.Id == id);
            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        // POST: Values1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var value = await _context.Values.FindAsync(id);
            _context.Values.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValueExists(int id)
        {
            return _context.Values.Any(e => e.Id == id);
        }
    }
}
