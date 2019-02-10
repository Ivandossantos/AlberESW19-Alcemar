using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ESW19Backup2.Models;
using Microsoft.EntityFrameworkCore.Design;
using ESW19Backup2.Models.Apoios;
using ESW19Backup2.Models.Upload;

namespace ESW19Backup2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ESW19Backup2.Models.Image> Image { get; set; }
        public DbSet<Erro> Erros { get; set; }
        

        public DbSet<ESW19Backup2.Models.Cao> Cao { get; set; }

        public DbSet<ESW19Backup2.Models.Ajuda> Ajudas { get; set; }

        public DbSet<ESW19Backup2.Models.Apoios.TipoApadrinhamento> TipoApadrinhamento { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //2º metodo para desenhar 
        public class ToDoContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-ESW19Backup2-2A866569-96D8-46FE-8FC2-FD4829B61570;Trusted_Connection=True;MultipleActiveResultSets=true");
                return new ApplicationDbContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<ESW19Backup2.Models.Tarefa> Tarefa { get; set; }
        public DbSet<ESW19Backup2.Models.Funcionario> Funcionarios { get; set; }
    

        public DbSet<Estado> Estados { get; set; }

        public DbSet<ESW19Backup2.Models.Horarios> Horarios { get; set; }

        public DbSet<ESW19Backup2.Models.Atribuicao> Atribuicao { get; set; }

        public DbSet<ESW19Backup2.Models.Saude> Saude { get; set; }

        public DbSet<ESW19Backup2.Models.Evento> Evento { get; set; }
        

        public DbSet<ESW19Backup2.Models.Adocao> Adocao { get; set; }

        public DbSet<ESW19Backup2.Models.Voluntario> Voluntario { get; set; }

        public DbSet<ESW19Backup2.Models.Socios> Socios { get; set; }

        public DbSet<ESW19Backup2.Models.Apoios.Area> Areas { get; set; }

        public DbSet<ESW19Backup2.Models.Apoios.Apadrinhar> Apadrinhar { get; set; }

        public DbSet<ESW19Backup2.Models.ReportarOcorrencia> ReportarOcorrencia { get; set; }

        public DbSet<ESW19Backup2.Models.Upload.FileDetails> FileDetails { get; set; }

        public DbSet<ESW19Backup2.Models.Upload.FilesViewModel> FilesViewModel { get; set; }

        public DbSet<ESW19Backup2.Models.TipoPrioridade> TipoPrioridades { get; set; }
        






    }
}
