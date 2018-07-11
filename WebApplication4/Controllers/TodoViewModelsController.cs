using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4
{
    public class TodoViewModelsController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public TodoViewModelsController(ApplicationDbContext context)
        {

            _context = context;
           
        }


        

        // GET: TodoViewModels
        public async Task<IActionResult> Index()
        {
            var todol = _context.todoViewModels.Include(c => c.Category);
            return View(await todol.ToListAsync());
            
        }
       

        // GET: TodoViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoViewModel = await _context.todoViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoViewModel == null)
            {
                return NotFound();
            }

            return View(todoViewModel);
        }

        
        public IActionResult Create()
        {
            ViewBag.Categor = new SelectList(_context.categoryViewModels.Select(c => new { Id = c.Id, Name = c.Name }), "Id", "Name");           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,StartDate,EndDate,CategoryId")] TodoViewModel todoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoViewModel);
        }
        
        // GET: TodoViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categor = new SelectList(_context.categoryViewModels.Select(c => new { Id = c.Id, Name = c.Name }), "Id", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var todoViewModel = await _context.todoViewModels.FindAsync(id);
            if (todoViewModel == null)
            {
                return NotFound();
            }
            return View(todoViewModel);
        }

        // POST: TodoViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,StartDate,EndDate,CategoryId")] TodoViewModel todoViewModel)
        {
            
            if (id != todoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(todoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoViewModelExists(todoViewModel.Id))
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
            return View(todoViewModel);
        }

        // GET: TodoViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoViewModel = await _context.todoViewModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoViewModel == null)
            {
                return NotFound();
            }

            return View(todoViewModel);
        }

        // POST: TodoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoViewModel = await _context.todoViewModels.FindAsync(id);
            _context.todoViewModels.Remove(todoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoViewModelExists(int id)
        {
            return _context.todoViewModels.Any(e => e.Id == id);
        }
    }
}
