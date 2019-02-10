using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Tarefa
    {

        public int TarefaID { get; set; }

        [Required(ErrorMessage = "Tarefa obrigatório.")]
        [Display(Name ="Tarefa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Tarefa obrigatório.")]
        [Display(Name = "Tarefa")]
        public string Descricao { get; set; }

        public virtual ICollection<Atribuicao> Candidaturas { get; } = new List<Atribuicao>();

        public Tarefa()
        {

        }
    }
}
