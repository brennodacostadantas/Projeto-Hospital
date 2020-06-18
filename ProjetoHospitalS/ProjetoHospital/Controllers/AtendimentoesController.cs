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
    public class AtendimentoesController : Controller
    {
        private readonly Context _context;

        public AtendimentoesController(Context context)
        {
            _context = context;
        }

        // GET: Atendimentoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Atendimento.Include(a => a.Consulta).Include(a => a.DiaSemana).Include(a => a.Medico);
            return View(await context.ToListAsync());
        }

        // GET: Atendimentoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Consulta)
                .Include(a => a.DiaSemana)
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentoes/Create
        public IActionResult Create()
        {
            ViewData["AtendimentoDaConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo");
            ViewData["DiaSemanaId"] = new SelectList(_context.DiaSemana, "Id", "Nome");
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "CRM");
            return View();
        }

        // POST: Atendimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoraInicio,HoraFim,AtendePlano,AtendeDia,DiaSemanaId,MedicoId,AtendimentoDaConsultaId")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtendimentoDaConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", atendimento.AtendimentoDaConsultaId);
            ViewData["DiaSemanaId"] = new SelectList(_context.DiaSemana, "Id", "Nome", atendimento.DiaSemanaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "CRM", atendimento.MedicoId);
            return View(atendimento);
        }

        // GET: Atendimentoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["AtendimentoDaConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", atendimento.AtendimentoDaConsultaId);
            ViewData["DiaSemanaId"] = new SelectList(_context.DiaSemana, "Id", "Nome", atendimento.DiaSemanaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "CRM", atendimento.MedicoId);
            return View(atendimento);
        }

        // POST: Atendimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,HoraInicio,HoraFim,AtendePlano,AtendeDia,DiaSemanaId,MedicoId,AtendimentoDaConsultaId")] Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.Id))
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
            ViewData["AtendimentoDaConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", atendimento.AtendimentoDaConsultaId);
            ViewData["DiaSemanaId"] = new SelectList(_context.DiaSemana, "Id", "Nome", atendimento.DiaSemanaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "CRM", atendimento.MedicoId);
            return View(atendimento);
        }

        // GET: Atendimentoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.Consulta)
                .Include(a => a.DiaSemana)
                .Include(a => a.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var atendimento = await _context.Atendimento.FindAsync(id);
            _context.Atendimento.Remove(atendimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(long id)
        {
            return _context.Atendimento.Any(e => e.Id == id);
        }
    }
}
