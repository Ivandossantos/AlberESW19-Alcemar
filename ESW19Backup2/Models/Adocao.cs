using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Adocao
    {
        [Key]
        [Display(Name = "ID")]
        public int AdocaoId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Nome do Cão")]
        public string NomeCao { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Data de Adocao")]
        public DateTime DataAdocao { get; set; }

        public Adocao() { }
    }
}
