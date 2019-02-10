using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Cao
    {
        public int CaoId { get; set; }
        public string Nome { get; set; }

        [Range(0.0, 20.9, ErrorMessage = "A idade do cão não pode ser inferior a 0")]
        public double Idade { get; set; }

        [Display(Name = "Raça") ]
        public string Raca { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataDeEntrada { get; set; }
        
        public virtual Saude Saude { get; set; }
        


        public Cao()
        {

        }

    }
}
