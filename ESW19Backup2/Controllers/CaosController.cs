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
    public class CaosController : Controller
    {
        private readonly ApplicationDbContext _context;
        protected readonly List<Ajuda> _ajudas;

        public CaosController(ApplicationDbContext context)
        {
            _context = context;
            _ajudas = context.Ajudas.Where(ai => ai.Controller == "Caos").ToList();
        }

        // GET: Caos
        /// <summary>
        /// Mostra a Lista dos cães existentes
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IActionResult> Index()
        {
           
                SetHelpModal("Index");
                return View(await _context.Cao.ToListAsync());
         
                
        }

        /// <summary>
        /// Mostra a Lista dos cães existentes
        /// Mas esta lista só é apresentado para o administrador
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IActionResult> IndexAdmin()
        {
            return View(await _context.Cao.ToListAsync());
        }

        // GET: Caos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cao = await _context.Cao
                .Include(c => c.Saude).Include(c => c.Saude.Estado)
                .SingleOrDefaultAsync(c=>c.CaoId == id);
            if (cao == null)
            {
                return NotFound();
            }

            return View(cao);
        }

        // GET: Caos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaoId,Nome,Idade,Raca, DataDeEntrada")] Cao cao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cao);
                await _context.SaveChangesAsync();
                SetSuccessMessage("Cão criado com sucesso");

                return RedirectToAction(nameof(IndexAdmin));
            }
            return View(cao);
        }

        // GET: Caos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cao = await _context.Cao.SingleOrDefaultAsync(m => m.CaoId == id);
            if (cao == null)
            {
                return NotFound();
            }
            return View(cao);
        }

        // POST: Caos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaoId,Nome,Idade,Raca")] Cao cao)
        {
            if (id != cao.CaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaoExists(cao.CaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexAdmin));
            }
            return View(cao);
        }

        // GET: Caos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cao = await _context.Cao
                .SingleOrDefaultAsync(m => m.CaoId == id);
            if (cao == null)
            {
                return NotFound();
            }

            return View(cao);
        }

        // POST: Caos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cao = await _context.Cao.SingleOrDefaultAsync(m => m.CaoId == id);
            _context.Cao.Remove(cao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAdmin));
        }

        private bool CaoExists(int id)
        {
            return _context.Cao.Any(e => e.CaoId == id);
        }

        protected void SetSuccessMessage(String Message)
        {
            TempData["Successo"] = Message;
        }


        private void SetHelpModal(String Action)
        {
            ViewData["TextoModalAjuda"] = _ajudas.Single(ai => ai.Action == Action && ai.Elemento == "ModalAjuda").Texto;
        }
    }
}
