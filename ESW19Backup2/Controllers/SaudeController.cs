using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESW19Backup2.Data;
using ESW19Backup2.Models;
using ESW19Backup2.Services;

namespace ESW19Backup2.Controllers
{
    public class SaudeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly List<Saude> _saude;
        List<string> listaCao = new List<string>();
        List<string> listaEstados = new List<string>();
        protected readonly List<Erro> _erros;

        public SaudeController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _saude = context.Saude.Include(s => s.Estado).Include(s=>s.Cao).ToList();
            _context = context;
            _erros = context.Erros.ToList();
            _emailSender = emailSender;
        }

        // GET: Saude
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Saude
                .Include(e => e.Estado).Include(e => e.Cao)
                .ToList();
            return View(ProperView("Index"), _saude);
        }

        // GET: Saude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saude = await _context.Saude
                .Include(e => e.Estado)
                .SingleOrDefaultAsync(m => m.SaudeId == id);
            if (saude == null)
            {
                return NotFound();
            }
            if (!User.IsInRole("Estudante"))
            {
               
                return View(ProperView("Details"), saude);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            Saude saude = _context.Saude.SingleOrDefault(e => e.SaudeId == id);
            listaEstados = (from estados in _context.Estados select estados.Nome).ToList();
            listaEstados.Sort();
            ViewBag.ListaEstados = listaEstados;
            return View(ProperView("Edit"), saude);
        }
       

        // POST: Saude/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaudeId,DataVacina,CaoId")] Saude saude)
        {
            if (ModelState.IsValid)
            {
                Saude novaVacina = _context.Saude.SingleOrDefault(e => e.SaudeId == saude.SaudeId);
                //novaVacina.Cao.nome = _context.Saude.SingleOrDefault(e => e.CaoId == saude.SaudeId)?.Cao.nome;
                novaVacina.DataVacina = saude.DataVacina;
                novaVacina.Estado = saude.Estado;
                _context.SaveChanges();
                SetSuccessMessage("Vacina editada");
                return RedirectToAction(nameof(Index));
            }
            SetErrorMessage("003");
            return View(saude);
        }

        // GET: Saude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saude = await _context.Saude
               
                .SingleOrDefaultAsync(m => m.SaudeId == id);
            if (saude == null)
            {
                return NotFound();
            }

            return View(saude);
        }

        // POST: Saude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saude = await _context.Saude.SingleOrDefaultAsync(m => m.SaudeId == id);
            _context.Saude.Remove(saude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaudeExists(int id)
        {
            return _context.Saude.Any(e => e.SaudeId == id);
        }

        #region Nossos Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns>Retorna a Vista escolhida</returns>
        /// <remarks></remarks>
        protected String ProperView(String viewName)
        {

            return viewName;
        }

        /// <summary>
        /// Metodo que vai buscar os nome dos caes e os estados para poder marcar as respectivas vacinas
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IActionResult MarcarVacina()
        {
            //lista de estados
            listaEstados = (from estados in _context.Estados select estados.Nome).ToList();
            listaEstados.Sort();

            ViewBag.ListaEstados = listaEstados;
            listaCao = (from caos in _context.Horarios select caos.Hora).ToList();
            listaCao.Sort();
            ViewBag.ListaCao = listaCao;
            return PartialView(ProperView("MarcarVacina"));

        }

        /// <summary>
        /// Insere as vacinas marcadas na base de dados
        /// </summary>
        /// <param name="saude"></param>
        /// <returns>Retorna o Index</returns>
        /// <remarks></remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarcarVacina([Bind("SaudeId, DataVacina, Estado, CaoId")] Saude saude)
        {
            //lista de estados
            if (ModelState.IsValid)
            {
                _context.Add(saude);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(saude);
        }

        /// <summary>
        /// Vai buscar a lista de erros
        /// Apresenta os erros na pagina que foram definidos
        /// </summary>
        /// <param name="Code"></param>
        /// <remarks></remarks>
        protected void SetErrorMessage(String Code)
        {
            var Erro = _erros.SingleOrDefault(e => e.Codigo == Code);
            TempData["Error_Code"] = Erro.Codigo;
            TempData["Error_Message"] = Erro.Mensagem;
        }

        /// <summary>
        /// Envia uma mensagem de sucesso
        /// </summary>
        /// <param name="Message"></param>
        /// <remarks></remarks>
        protected void SetSuccessMessage(String Message)
        {
            TempData["Success"] = Message;
        }

        /// <summary>
        /// Metodo responsavel por adiar as vacinas
        /// </summary>
        /// <param name="SaudeId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public IActionResult Adiar(int SaudeId)
        {
            Saude saude = _saude.SingleOrDefault(p => p.SaudeId == SaudeId);
            if (saude != null)
            {
                //saude.Estado = _context.Estados.SingleOrDefault(e => e.Nome == "Recusada");
                _context.SaveChanges();
                SetSuccessMessage("Vacina adiada");
                return RedirectToAction(nameof(Details), new { id = SaudeId });
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
