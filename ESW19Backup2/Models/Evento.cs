using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Evento
    {
        public int EventoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Hora de Início")]
        public string HoraInicio { get; set; }

        [Display(Name = "Hora de Fim")]
        public string HoraFim { get; set; }

        [Display(Name = "Local")]
        public string Local { get; set; }

        [Display(Name = "Preço")]
        public double preco { get; set; }
        

    }
}