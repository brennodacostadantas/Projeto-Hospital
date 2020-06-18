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
    public class ExamePlanoesController : Controller
    {
        private readonly Context _context;

        public ExamePlanoesController(Context context)
        {
            _context = context;
        }

        // GET: ExamePlanoes
        public async Task<IActionResult> Index()
        {
            var context = _context.ExamePlano.Include(e => e.Exame).Include(e => e.Plano);
            return View(await context.ToListAsync());
        }

        // GET: ExamePlanoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examePlano = await _context.ExamePlano
                .Include(e => e.Exame)
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.IdExame == id);
            if (examePlano == null)
            {
                return NotFound();
            }

            return View(examePlano);
        }

        // GET: ExamePlanoes/Create
        public IActionResult Create()
        {
            ViewData["IdExame"] = new SelectList(_context.Exame, "Id", "IdadePaciente");
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome");
            return View();
        }

        // POST: ExamePlanoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExame,IdPlano")] ExamePlano examePlano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examePlano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExame"] = new SelectList(_context.Exame, "Id", "IdadePaciente", examePlano.IdExame);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", examePlano.IdPlano);
            return View(examePlano);
        }

        // GET: ExamePlanoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examePlano = await _context.ExamePlano.FindAsync(id);
            if (examePlano == null)
            {
                return NotFound();
            }
            ViewData["IdExame"] = new SelectList(_context.Exame, "Id", "IdadePaciente", examePlano.IdExame);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", examePlano.IdPlano);
            return View(examePlano);
        }

        // POST: ExamePlanoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExame,IdPlano")] ExamePlano examePlano)
        {
            if (id != examePlano.IdExame)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examePlano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamePlanoExists(examePlano.IdExame))
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
            ViewData["IdExame"] = new SelectList(_context.Exame, "Id", "IdadePaciente", examePlano.IdExame);
            ViewData["IdPlano"] = new SelectList(_context.Plano, "Id", "Nome", examePlano.IdPlano);
            return View(examePlano);
        }

        // GET: ExamePlanoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examePlano = await _context.ExamePlano
                .Include(e => e.Exame)
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.IdExame == id);
            if (examePlano == null)
            {
                return NotFound();
            }

            return View(examePlano);
        }

        // POST: ExamePlanoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examePlano = await _context.ExamePlano.FindAsync(id);
            _context.ExamePlano.Remove(examePlano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamePlanoExists(int id)
        {
            return _context.ExamePlano.Any(e => e.IdExame == id);
        }
    }
}
