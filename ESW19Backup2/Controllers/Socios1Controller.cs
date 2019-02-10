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
    public class Socios1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Socios1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Socios.ToListAsync());
        }

        // GET: Socios1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios
                .SingleOrDefaultAsync(m => m.SociosId == id);
            if (socios == null)
            {
                return NotFound();
            }

            return View(socios);
        }

        // GET: Socios1/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("SociosId,Nome,Morada,Email,Telefone,CartaoCidadao,PRofissao,MensagemAdicional")] Socios socios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socios);
                await _context.SaveChangesAsync();
                SetSuccessMessage("Muito Obrigado pela sua participação");
                return RedirectToAction(nameof(Criar));
            }
            return View(socios);
        }

        protected void SetSuccessMessage(String Message)
        {
            TempData["SucessoSO"] = Message;
        }

        // POST: Socios1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SociosId,Nome,Morada,Email,Telefone,CartaoCidadao,PRofissao,MensagemAdicional")] Socios socios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socios);
        }

        // GET: Socios1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios.SingleOrDefaultAsync(m => m.SociosId == id);
            if (socios == null)
            {
                return NotFound();
            }
            return View(socios);
        }

        // POST: Socios1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SociosId,Nome,Morada,Email,Telefone,CartaoCidadao,PRofissao,MensagemAdicional")] Socios socios)
        {
            if (id != socios.SociosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SociosExists(socios.SociosId))
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
            return View(socios);
        }

        // GET: Socios1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socios = await _context.Socios
                .SingleOrDefaultAsync(m => m.SociosId == id);
            if (socios == null)
            {
                return NotFound();
            }

            return View(socios);
        }

        // POST: Socios1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socios = await _context.Socios.SingleOrDefaultAsync(m => m.SociosId == id);
            _context.Socios.Remove(socios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SociosExists(int id)
        {
            return _context.Socios.Any(e => e.SociosId == id);
        }
    }
}
