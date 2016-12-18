using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication042.Data;
using WebApplication042.Models;

namespace WebApplication042.Controllers
{
    public class Class1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Class1Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Class1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Class1.ToListAsync());
        }

        // GET: Class1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class1 = await _context.Class1.SingleOrDefaultAsync(m => m.ID == id);
            if (class1 == null)
            {
                return NotFound();
            }

            return View(class1);
        }

        // GET: Class1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Class1 class1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(class1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(class1);
        }

        // GET: Class1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class1 = await _context.Class1.SingleOrDefaultAsync(m => m.ID == id);
            if (class1 == null)
            {
                return NotFound();
            }
            return View(class1);
        }

        // POST: Class1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Class1 class1)
        {
            if (id != class1.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(class1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Class1Exists(class1.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(class1);
        }

        // GET: Class1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var class1 = await _context.Class1.SingleOrDefaultAsync(m => m.ID == id);
            if (class1 == null)
            {
                return NotFound();
            }

            return View(class1);
        }

        // POST: Class1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var class1 = await _context.Class1.SingleOrDefaultAsync(m => m.ID == id);
            _context.Class1.Remove(class1);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Class1Exists(int id)
        {
            return _context.Class1.Any(e => e.ID == id);
        }
    }
}
