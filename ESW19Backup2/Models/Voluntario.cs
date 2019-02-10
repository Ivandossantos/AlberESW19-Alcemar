using ESW19Backup2.Models.Apoios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Voluntario
    {

        [Key]
        [Display(Name = "ID")]
        public int VoluntarioId { get; set; }

        [Required(ErrorMessage = "Tem que introduzir o seu Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tem que introduzir o seu Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tem que introduzir o seu Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Tem que introduzir a sua Profissão")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "Área a que se propõe")]
        public int AreaId { get; set; }

        [Display(Name = "Área a que se propõe")]
        public virtual Models.Apoios.Area Area { get; set; }





        



        //[Display(Name = "DataInicio")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime DataInicio { get; set; }

        //[Display(Name = "DataFim")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime DataFim { get; set; }

        public Voluntario()
        {

        }
    }
}
