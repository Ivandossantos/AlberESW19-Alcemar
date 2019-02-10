using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESW19Backup2.Data;
using Microsoft.AspNetCore.Mvc;

namespace ESW19Backup2.Controllers
{
    public class ModalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModalController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Faz-se um switch para se ver se o cao ja foi ou nou adotado
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="nomeCao"></param>
        /// <param name="nome"></param>
        /// <returns>A vista de Index</returns>
        /// <remarks></remarks>
        public IActionResult Index(string tipo, string nomeCao, string nome)
        {
            string mensagem = "";
            switch (tipo)
            {
                case "inf":
                    mensagem = "O cão de nome " + nomeCao + " foi adotado pelo " + nome;
                    break;
                case "error":
                    mensagem = "O cão de nome " + nomeCao + " já foi adotado pelo " + nome + "! Tente outra adoção"; ;
                    break;
            }
            ViewData["mensagem"] = mensagem;
            return View();
        }
        public IActionResult Index2(string tipo, string nomeCao, string nome)
        {
            string mensagem = "";
            switch (tipo)
            {
                case "inf":
                    mensagem = "O cão de nome " + nomeCao + " foi apadrinhado pelo " + nome;
                    break;
                case "error":
                    mensagem = "O cão de nome " + nomeCao + " já foi apadrinhado pelo " + nome + "! Tente ajudar outro cão"; ;
                    break;
            }
            ViewData["mensagem"] = mensagem;
            return View();
        }


    }
}