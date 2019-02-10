using ESW19Backup2.Controllers;
using ESW19Backup2.Data;
using ESW19Backup2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private DbContextOptionsBuilder<ApplicationDbContext> options;
        private ApplicationDbContext _dbContext;

        public UnitTest1()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(options.Options);
        }



        [Fact]
        public void Test1()
        {

        }

        //[Fact]
        //public async System.Threading.Tasks.Task Criar_Funcionarios()
        //{
        //    FuncionariosController funcionario = new FuncionariosController(_dbContext);
        //    Funcionarios fun = new Funcionarios();
        //    fun.Nome = "Alcemar";
        //    fun.Sobrenome = "Costa";
        //    fun.DataDeNascimento = new DateTime(1995, 11, 04);
        //    DateTime inicio = new DateTime(2018, 12, 22);
        //    DateTime fim = new DateTime(2018, 12, 21);
        //    fun.Sexo = "M";
        //    fun.Telemovel = 913289457;
        //    fun.Nacionalidade = "CV";
        //    fun.MoradaFiscal = "Setubal";
          
        //    ApplicationUser user = new ApplicationUser { Nome = "Renata Figueiredo", DataNascimento = "14/09/1996", Contato = "934722153" };
        //    Horarios h = new Horarios { Hora = "22/12/2018 10hr para 22/12/2018 18hr" };
            
        //    var result = funcionario.Criar(fun);

        //    Assert.IsType<RedirectToActionResult>(result);
            
        //}

       
        [Fact]
        public async System.Threading.Tasks.Task Test_Mostrar_Galeria()
        {
            ImageController img = new ImageController(null);
            var resultado = img.Index();
            Assert.IsType<ViewResult>(resultado);
        }

    }
}
