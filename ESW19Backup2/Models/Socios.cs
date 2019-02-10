using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Socios
    {
        [Key]
        [Display(Name = "ID")]
        public int SociosId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "BI/Cartão Cidadao")]
        public int CartaoCidadao { get; set; }

        [Display(Name = "Profissao")]
        public string PRofissao { get; set; }

        [Display(Name = "Contribuinte / NIPC")]
        public int Contribuinte { get; set; }

        public Socios() { }
       
    }
}
