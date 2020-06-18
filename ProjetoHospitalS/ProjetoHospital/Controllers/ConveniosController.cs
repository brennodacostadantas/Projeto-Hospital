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
    public class ConveniosController : Controller
    {
        private readonly Context _context;

        public ConveniosController(Context context)
        {
            _context = context;
        }

        // GET: Convenios
        public async Task<IActionResult> Index()
        {
            var context = _context.Convenios.Include(c => c.Medico).Include(c => c.Plano);
            return View(await context.ToListAsync());
        }

        // GET: Convenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.Medico)
                .Include(c => c.Plano)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }

        // GET: Convenios/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medico, "Id", "CRM");
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome");
            return View();
        }

        // POST: Convenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,IdPlano")] Convenio convenio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medico, "Id", "CRM", convenio.IdMedico);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", convenio.IdPlano);
            return View(convenio);
        }

        // GET: Convenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios.FindAsync(id);
            if (convenio == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medico, "Id", "CRM", convenio.IdMedico);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", convenio.IdPlano);
            return View(convenio);
        }

        // POST: Convenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,IdPlano")] Convenio convenio)
        {
            if (id != convenio.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvenioExists(convenio.IdMedico))
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
            ViewData["IdMedico"] = new SelectList(_context.Medico, "Id", "CRM", convenio.IdMedico);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", convenio.IdPlano);
            return View(convenio);
        }

        // GET: Convenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .Include(c => c.Medico)
                .Include(c => c.Plano)
                .FirstOrDefaultAsync(m => m.IdMedico == id);
            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }

        // POST: Convenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convenio = await _context.Convenios.FindAsync(id);
            _context.Convenios.Remove(convenio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvenioExists(int id)
        {
            return _context.Convenios.Any(e => e.IdMedico == id);
        }
    }
}
