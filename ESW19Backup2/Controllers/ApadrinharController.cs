using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESW19Backup2.Data;
using ESW19Backup2.Models.Apoios;

namespace ESW19Backup2.Controllers
{
    public class ApadrinharController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApadrinharController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apadrinhar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Apadrinhar.Include(a => a.TiposDeAjuda);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: Apadrinhar/Create
        public IActionResult Create(string nomeCao)
        {
            var appApadrinhar = from a in _context.Apadrinhar
                                where a.NomeCao == nomeCao
                                select new
                                {
                                    a.ApadrinharId,
                                    a.Nome,
                                    a.Morada,
                                    a.Telefone,
                                    a.TiposDeAjuda,
                                    a.NomeCao,
                                    a.Estado
                                };
            var apadrinhar = appApadrinhar.SingleOrDefault();
            if (apadrinhar != null)
            {
                if (apadrinhar.Estado == "Apadrinhado")
                {
                    return RedirectToAction(nameof(ModalController.Index2), "Modal", new { tipo = "error", nomeCao = apadrinhar.NomeCao, nome = apadrinhar.Nome });
                }
            }

            ViewData["TipoApadrinhamentoId"] = new SelectList(_context.TipoApadrinhamento, "TipoApadrinhamentoId", "TipoApadrinhamentoId");
            return View();
        }

        // POST: Apadrinhar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApadrinharId,Nome,Morada,Telefone,Email,TipoApadrinhamentoId,NomeCao")] Apadrinhar apadrinhar)
        {
            var adocao = new Apadrinhar
            {
                ApadrinharId = apadrinhar.ApadrinharId,
                Nome = apadrinhar.Nome,
                Morada = apadrinhar.Morada,
                Telefone = apadrinhar.Telefone,
                Email = apadrinhar.Email,
                NomeCao = apadrinhar.NomeCao,
                Estado = "Apadrinhado"
            };

            _context.Add(apadrinhar);
                await _context.SaveChangesAsync();
               ViewData["TipoApadrinhamentoId"] = new SelectList(_context.TipoApadrinhamento, "TipoApadrinhamentoId", "TipoApadrinhamentoId", apadrinhar.TipoApadrinhamentoId);
            return RedirectToAction(nameof(ModalController.Index2), "Modal", new { tipo = "inf", nomeCao = adocao.NomeCao, nome = adocao.Nome });


        }

       
    }
}
