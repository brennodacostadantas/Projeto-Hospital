using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoHospital.Data;
using ProjetoHospital.Models;

namespace ProjetoHospital.Controllers
{
    public class DiaSemanasController : Controller
    {
        private readonly Context _context;

        public DiaSemanasController(Context context)
        {
            _context = context;
        }

        // GET: DiaSemanas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiaSemana.ToListAsync());
        }

        // GET: DiaSemanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiaSemana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // GET: DiaSemanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaSemanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] DiaSemana diaSemana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaSemana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaSemana);
        }

        // GET: DiaSemanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiaSemana.FindAsync(id);
            if (diaSemana == null)
            {
                return NotFound();
            }
            return View(diaSemana);
        }

        // POST: DiaSemanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] DiaSemana diaSemana)
        {
            if (id != diaSemana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaSemana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaSemanaExists(diaSemana.Id))
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
            return View(diaSemana);
        }

        // GET: DiaSemanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaSemana = await _context.DiaSemana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaSemana == null)
            {
                return NotFound();
            }

            return View(diaSemana);
        }

        // POST: DiaSemanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaSemana = await _context.DiaSemana.FindAsync(id);
            _context.DiaSemana.Remove(diaSemana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaSemanaExists(int id)
        {
            return _context.DiaSemana.Any(e => e.Id == id);
        }
    }
}
