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
    public class RequisicaoExamesController : Controller
    {
        private readonly Context _context;

        public RequisicaoExamesController(Context context)
        {
            _context = context;
        }

        // GET: RequisicaoExames
        public async Task<IActionResult> Index()
        {
            var context = _context.RequisicaoExame.Include(r => r.Consulta).Include(r => r.Exame);
            return View(await context.ToListAsync());
        }

        // GET: RequisicaoExames/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicaoExame = await _context.RequisicaoExame
                .Include(r => r.Consulta)
                .Include(r => r.Exame)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicaoExame == null)
            {
                return NotFound();
            }

            return View(requisicaoExame);
        }

        // GET: RequisicaoExames/Create
        public IActionResult Create()
        {
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo");
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "IdadePaciente");
            return View();
        }

        // POST: RequisicaoExames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataRequisicao,Situacao,DataAgendamento,ExameId,ConsultaId")] RequisicaoExame requisicaoExame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicaoExame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", requisicaoExame.ConsultaId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "IdadePaciente", requisicaoExame.ExameId);
            return View(requisicaoExame);
        }

        // GET: RequisicaoExames/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicaoExame = await _context.RequisicaoExame.FindAsync(id);
            if (requisicaoExame == null)
            {
                return NotFound();
            }
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", requisicaoExame.ConsultaId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "IdadePaciente", requisicaoExame.ExameId);
            return View(requisicaoExame);
        }

        // POST: RequisicaoExames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataRequisicao,Situacao,DataAgendamento,ExameId,ConsultaId")] RequisicaoExame requisicaoExame)
        {
            if (id != requisicaoExame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicaoExame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicaoExameExists(requisicaoExame.Id))
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
            ViewData["ConsultaId"] = new SelectList(_context.Consulta, "Id", "Tipo", requisicaoExame.ConsultaId);
            ViewData["ExameId"] = new SelectList(_context.Exame, "Id", "IdadePaciente", requisicaoExame.ExameId);
            return View(requisicaoExame);
        }

        // GET: RequisicaoExames/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicaoExame = await _context.RequisicaoExame
                .Include(r => r.Consulta)
                .Include(r => r.Exame)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicaoExame == null)
            {
                return NotFound();
            }

            return View(requisicaoExame);
        }

        // POST: RequisicaoExames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var requisicaoExame = await _context.RequisicaoExame.FindAsync(id);
            _context.RequisicaoExame.Remove(requisicaoExame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicaoExameExists(long id)
        {
            return _context.RequisicaoExame.Any(e => e.Id == id);
        }
    }
}
