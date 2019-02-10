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
    public class AdocaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdocaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adocao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adocao.ToListAsync());
        }

        public IActionResult Create(string nomeCao)
        {
            //obter adoção pelo nome do cão
            var appAdocao = from a in _context.Adocao
                            where a.NomeCao == nomeCao
                            select new
                            {
                                a.AdocaoId,
                                a.Nome,
                                a.Email,
                                a.Telefone,
                                a.NomeCao,
                                a.Estado
                            };
            var adocao = appAdocao.SingleOrDefault();
            if (adocao != null)
            {
                if (adocao.Estado == "Adotado")
                {
                    return RedirectToAction(nameof(ModalController.Index), "Modal", new { tipo = "error", nomeCao = adocao.NomeCao, nome = adocao.Nome });

                }
            }

            return View();


        }

        // POST: Adocoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adocao modelAdocao)
        {
            if (ModelState.IsValid)
            {
                var adocao = new Adocao
                {
                    AdocaoId = modelAdocao.AdocaoId,
                    Nome = modelAdocao.Nome,
                    Email = modelAdocao.Email,
                    Telefone = modelAdocao.Telefone,
                    NomeCao = modelAdocao.NomeCao,
                    Estado = "Adotado" //adotado
                };
                _context.Add(adocao);
                await _context.SaveChangesAsync();
               return RedirectToAction(nameof(ModalController.Index), "Modal", new { tipo = "inf", nomeCao = adocao.NomeCao, nome = adocao.Nome });
            }
            return View(modelAdocao);
        }
    }
}