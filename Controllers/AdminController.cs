using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETFinalExamsProject.Entities;
using ASP.NETFinalExamsProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETFinalExamsProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly CallContext _context;

        public AdminController(CallContext context)
        {
            _context = context;
        }



        // GET: Admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.CallTrackerClasses.ToListAsync());
        }

        // GET: Admin/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CallTrackerClasses == null)
            {
                return NotFound();
            }

            var callTrackerClass = await _context.CallTrackerClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callTrackerClass == null)
            {
                return NotFound();
            }

            return View(callTrackerClass);
        }

        // GET: Admin/Create
        [Authorize(Roles = "Receptionist")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,CallType,Duration,DestinationNumber,DateTime,Cost")] CallTrackerClass callTrackerClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callTrackerClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(callTrackerClass);
        }

        // GET: Admin/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CallTrackerClasses == null)
            {
                return NotFound();
            }

            var callTrackerClass = await _context.CallTrackerClasses.FindAsync(id);
            if (callTrackerClass == null)
            {
                return NotFound();
            }
            return View(callTrackerClass);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,CallType,Duration,DestinationNumber,DateTime,Cost")] CallTrackerClass callTrackerClass)
        {
            if (id != callTrackerClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callTrackerClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallTrackerClassExists(callTrackerClass.Id))
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
            return View(callTrackerClass);
        }

        // GET: Admin/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CallTrackerClasses == null)
            {
                return NotFound();
            }

            var callTrackerClass = await _context.CallTrackerClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callTrackerClass == null)
            {
                return NotFound();
            }

            return View(callTrackerClass);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CallTrackerClasses == null)
            {
                return Problem("Entity set 'CallContext.CallTrackerClasses'  is null.");
            }
            var callTrackerClass = await _context.CallTrackerClasses.FindAsync(id);
            if (callTrackerClass != null)
            {
                _context.CallTrackerClasses.Remove(callTrackerClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallTrackerClassExists(int id)
        {
          return _context.CallTrackerClasses.Any(e => e.Id == id);
        }
    }
}
