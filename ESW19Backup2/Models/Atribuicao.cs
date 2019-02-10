using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Atribuicao
    {
        public int AtribuicaoId { get; set; }
    
        //public virtual ListaDeTarefas ListaDeTarefas { get; set; }

        public string UserId { get; set; }
        public int HorarioId { get; set; }
        public int TarefaId { get; set; }
        
        public int FuncionarioId { get; set; }

        [Display(Name = "Tarefa a comprir")]
        public virtual Tarefa Tarefa { get; set; }

        [Display(Name ="Horario")]
        public virtual Horarios Horario { get; set; }


        [Display(Name ="Nome do Funcionario:")]
        public virtual Funcionario Funcionarios { get; set; }

        //public virtual ICollection<ListaDeTarefas> ListaDeTarefas { get; set; } = new List<ListaDeTarefas>();

        public Atribuicao()
        {

        }
      }
}
