using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETFinalExamsProject.Entities;
using ASP.NETFinalExamsProject.Models;
using ASP.NETFinalExamsProject.Repository;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETFinalExamsProject.Controllers
{
    public class ReceptionistController : Controller
    {
       
        private readonly CallContext _context;

        public ReceptionistController(CallContext context)
        {
            _context = context;
        }

        private readonly IRepository _repo;

        public ReceptionistController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Receptionist
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CallTrackerClasses.ToListAsync());
        }



        // GET: Receptionist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receptionist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Receptionist")]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,CallType,Duration,DestinationNumber,DateTime,Cost")] CallTrackerClass callTrackerClass)
        {
            if (ModelState.IsValid)
            {
                object? callCost = _repo.CalculateCallCost(callTrackerClass.Duration, callTrackerClass.CallType);
                callTrackerClass.Cost = (double)callCost;

                _context.Add(callTrackerClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(callTrackerClass);
        }

    }
}
