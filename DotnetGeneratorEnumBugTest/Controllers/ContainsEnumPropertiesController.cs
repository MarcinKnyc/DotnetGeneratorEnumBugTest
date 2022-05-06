#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotnetGeneratorEnumBugTest.Data;
using DotnetGeneratorEnumBugTest.Models;

namespace DotnetGeneratorEnumBugTest.Controllers
{
    public class ContainsEnumPropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContainsEnumPropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContainsEnumProperties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Models.ToListAsync());
        }

        // GET: ContainsEnumProperties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containsEnumProperty = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (containsEnumProperty == null)
            {
                return NotFound();
            }

            return View(containsEnumProperty);
        }

        // GET: ContainsEnumProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContainsEnumProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnumType")] ContainsEnumProperty containsEnumProperty)
        {
            if (ModelState.IsValid)
            {
                containsEnumProperty.Id = Guid.NewGuid();
                _context.Add(containsEnumProperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(containsEnumProperty);
        }

        // GET: ContainsEnumProperties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containsEnumProperty = await _context.Models.FindAsync(id);
            if (containsEnumProperty == null)
            {
                return NotFound();
            }
            return View(containsEnumProperty);
        }

        // POST: ContainsEnumProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,EnumType")] ContainsEnumProperty containsEnumProperty)
        {
            if (id != containsEnumProperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(containsEnumProperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainsEnumPropertyExists(containsEnumProperty.Id))
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
            return View(containsEnumProperty);
        }

        // GET: ContainsEnumProperties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var containsEnumProperty = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (containsEnumProperty == null)
            {
                return NotFound();
            }

            return View(containsEnumProperty);
        }

        // POST: ContainsEnumProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var containsEnumProperty = await _context.Models.FindAsync(id);
            _context.Models.Remove(containsEnumProperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainsEnumPropertyExists(Guid id)
        {
            return _context.Models.Any(e => e.Id == id);
        }
    }
}
