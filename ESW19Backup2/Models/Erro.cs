using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Erro
    {
        public int ErroId { get; set; }
        public String Codigo { get; set; }
        public String Mensagem { get; set; }

        public Erro()
        {

        }

        public Erro(String Codigo, String Mensagem)
        {
            this.Codigo = Codigo;
            this.Mensagem = Mensagem;
        }
    }
}

