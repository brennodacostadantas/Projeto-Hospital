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
    public class PrescricaoMedicamentoesController : Controller
    {
        private readonly Context _context;

        public PrescricaoMedicamentoesController(Context context)
        {
            _context = context;
        }

        // GET: PrescricaoMedicamentoes
        public async Task<IActionResult> Index()
        {
            var context = _context.PrescricaoMedicamento.Include(p => p.Consulta);
            return View(await context.ToListAsync());
        }

        // GET: PrescricaoMedicamentoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoMedicamento = await _context.PrescricaoMedicamento
                .Include(p => p.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricaoMedicamento == null)
            {
                return NotFound();
            }

            return View(prescricaoMedicamento);
        }

        // GET: PrescricaoMedicamentoes/Create
        public IActionResult Create()
        {
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo");
            return View();
        }

        // POST: PrescricaoMedicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Medicamento,FormaUso,ConsultaId")] PrescricaoMedicamento prescricaoMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescricaoMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", prescricaoMedicamento.ConsultaId);
            return View(prescricaoMedicamento);
        }

        // GET: PrescricaoMedicamentoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoMedicamento = await _context.PrescricaoMedicamento.FindAsync(id);
            if (prescricaoMedicamento == null)
            {
                return NotFound();
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", prescricaoMedicamento.ConsultaId);
            return View(prescricaoMedicamento);
        }

        // POST: PrescricaoMedicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Medicamento,FormaUso,ConsultaId")] PrescricaoMedicamento prescricaoMedicamento)
        {
            if (id != prescricaoMedicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescricaoMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescricaoMedicamentoExists(prescricaoMedicamento.Id))
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
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", prescricaoMedicamento.ConsultaId);
            return View(prescricaoMedicamento);
        }

        // GET: PrescricaoMedicamentoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescricaoMedicamento = await _context.PrescricaoMedicamento
                .Include(p => p.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricaoMedicamento == null)
            {
                return NotFound();
            }

            return View(prescricaoMedicamento);
        }

        // POST: PrescricaoMedicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var prescricaoMedicamento = await _context.PrescricaoMedicamento.FindAsync(id);
            _context.PrescricaoMedicamento.Remove(prescricaoMedicamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescricaoMedicamentoExists(long id)
        {
            return _context.PrescricaoMedicamento.Any(e => e.Id == id);
        }
    }
}
