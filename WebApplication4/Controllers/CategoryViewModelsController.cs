using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4
{
    public class CategoryViewModelsController : Controller
    {
        private readonly WebApplication4.Data.ApplicationDbContext _context;

        public CategoryViewModelsController(WebApplication4.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.categoryViewModels.ToListAsync());
        }

        // GET: CategoryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = await _context.categoryViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        // GET: CategoryViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }

        // GET: CategoryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = await _context.categoryViewModels.FindAsync(id);
            if (categoryViewModel == null)
            {
                return NotFound();
            }
            return View(categoryViewModel);
        }

        // POST: CategoryViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryViewModelExists(categoryViewModel.Id))
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
            return View(categoryViewModel);
        }

        // GET: CategoryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = await _context.categoryViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        // POST: CategoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryViewModel = await _context.categoryViewModels.FindAsync(id);
            _context.categoryViewModels.Remove(categoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryViewModelExists(int id)
        {
            return _context.categoryViewModels.Any(e => e.Id == id);
        }
    }
}
