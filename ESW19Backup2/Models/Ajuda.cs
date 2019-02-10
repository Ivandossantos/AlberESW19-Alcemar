using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Ajuda
    {
        public int AjudaId { get; set; }
        public String Controller { get; set; }
        public String Action { get; set; }
        public String Elemento { get; set; }
        public String Texto { get; set; }

        public Ajuda()
        {

        }

        public Ajuda(String Controller, String Action, String Elemento, String Texto)
        {
            this.Controller = Controller;
            this.Action = Action;
            this.Elemento = Elemento;
            this.Texto = Texto;
        }
    }
}
