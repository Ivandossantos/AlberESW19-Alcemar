using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Horarios
    {

        /// <summary>Variavel que guarda o identificador da tarefa</summary>
        public int HorariosID { get; set; }
     
        [Required(ErrorMessage ="Introduza hora")]
        public string Hora { get; set; }

        

     

        [Required(ErrorMessage = "Introduza a Data")]
        public DayOfWeek Data { get; set; }

        public virtual ICollection<Atribuicao> Atribuicaos { get; } = new List<Atribuicao>();
        public virtual ICollection<Tarefa> Tarefas { get; } = new List<Tarefa>();
        public Horarios()
        {

        }

    }

   

  
}
