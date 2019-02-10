using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESW19Backup2.Data;
using ESW19Backup2.Models;

namespace ESW19Backup2.Controllers
{
    public class VoluntariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoluntariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voluntarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Voluntario.Include(v => v.Area);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Voluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .Include(v => v.Area)
                .SingleOrDefaultAsync(m => m.VoluntarioId == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // GET: Voluntarios/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaId");
            return View();
        }

        public IActionResult Apoio()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoluntarioId,Nome,Email,Telefone,Profissao,AreaId")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntario);
                await _context.SaveChangesAsync();
                SetSuccessMessage("Muito Obrigado pela sua participação");
                return RedirectToAction(nameof(Create));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaId", voluntario.Area.Nomes);
            return View(voluntario);
        }

        protected void SetSuccessMessage(String Message)
        {
            TempData["SucessoV"] = Message;
        }

        // GET: Voluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario.SingleOrDefaultAsync(m => m.VoluntarioId == id);
            if (voluntario == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaId", voluntario.AreaId);
            return View(voluntario);
        }

        // POST: Voluntarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoluntarioId,Nome,Email,Telefone,Profissao,AreaId")] Voluntario voluntario)
        {
            if (id != voluntario.VoluntarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioExists(voluntario.VoluntarioId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaId", voluntario.AreaId);
            return View(voluntario);
        }

        // GET: Voluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .Include(v => v.Area)
                .SingleOrDefaultAsync(m => m.VoluntarioId == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntario = await _context.Voluntario.SingleOrDefaultAsync(m => m.VoluntarioId == id);
            _context.Voluntario.Remove(voluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioExists(int id)
        {
            return _context.Voluntario.Any(e => e.VoluntarioId == id);
        }
    }
}
