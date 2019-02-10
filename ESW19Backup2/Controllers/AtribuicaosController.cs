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
using System.Security.Claims;

namespace ESW19Backup2.Controllers
{
    public class AtribuicaosController : Controller
    {
        protected ApplicationDbContext _context;


        private List<Atribuicao> _atribuicaos;
        private readonly IEmailSender _emailSender;

        public AtribuicaosController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _atribuicaos = context.Atribuicao.Include(a => a.Horario).Include(a => a.Tarefa).Include(a => a.Funcionarios)
             
                .ToList();
            _emailSender = emailSender;
            _context = context;
        }

        // GET: Atribuicaos
        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name != "akxeldacosta8@gmail.com")
            {
                ViewBag.HorarioPublicar = _context.Atribuicao.Include(h => h.Horario).Include(h => h.Tarefa)
                    .Include(h=> h.Funcionarios)
                    .ToList();
                return View();
            }
            return RedirectToAction(nameof(Criar));

           
        }


        /// <summary>
        /// Metodo responsavel por criar um horario, selecionando a hora, 
        /// o funcionario, e a tarefa dele naquele dia
        /// </summary>
        /// <returns>Ele retorna a lista dos horarios</returns>
        /// <remarks></remarks>
        public IActionResult Criar()
        {

            ViewBag.Horario = _context.Horarios.Select(p => new SelectListItem()
            {
                Value = p.HorariosID.ToString(),
                Text = p.Hora

            }).ToList();
            //vai buscar a lista de tarefas e asocia a uma ViewBag
            ViewBag.Tarefas = _context.Tarefa.Select(e => new SelectListItem()
            {
                Value = e.TarefaID.ToString(),
                Text = e.Nome
            }).ToList();

            //vai buscar a lista de funcionarios e asocia a uma ViewBag
            ViewBag.Funcionarios = _context.Funcionarios.Select(c => new SelectListItem()
            {
                Value = c.FuncionarioId.ToString(),
                Text = c.Nome
            }).ToList();

            //var caminho = "candidaturas/" + this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Documentos = _fileController.GetFiles(caminho);
            if (User.Identity.Name == "akxeldacosta8@gmail.com")
            {
                return View(ProperView("Criar"));
            }
            else
            {
                return View(ProperView("MostrarHorario"));
            }
        }

        /// <summary>
        /// Metodo responsavel por adicionar os horarios na base de dados
        /// </summary>
        /// <param name="atribuicao"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        public IActionResult Criar([Bind("HorarioId,TarefaId,FuncionarioId")] Atribuicao atribuicao)
        {
            if (ModelState.IsValid)
            {
                atribuicao.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //estado "sendo feito"
                _context.Add(atribuicao);
                _context.SaveChanges();
                return RedirectToAction(ProperView("MostrarHorario"));
            }

            return View(atribuicao);
        }

        
        /// <summary>
        /// Metodo Responsavel por ir buscar os horarios criados na base de dados
        /// e apresenta-lo ao utilizador
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public IActionResult MostrarHorario()
        {
            var applicationDbContext = _context.Atribuicao.Include(e => e.Funcionarios).Include(e => e.Tarefa)
               .Include(e => e.Horario)
               .ToList();
            return View(applicationDbContext.ToList());
        }

        protected string _controllerName;


        /// <summary>
        /// Metodo que serve como o caminho da vista pretendida
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected String ProperView(String viewName)
        {
            return viewName;
        }
    }
}
