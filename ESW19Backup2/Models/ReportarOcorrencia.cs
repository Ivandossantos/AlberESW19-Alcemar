using ESW19Backup2.Models.Upload;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ESW19Backup2.Models
{
    public class ReportarOcorrencia
    {
        public int ReportarOcorrenciaId { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        [Display(Name ="Inserir Imagem")]
        public string ImagePath { get; set; }

        public string Name { get; set; }

        public int TipoPrioridade { get; set; }

        [Range(1,5, ErrorMessage = "A propriedade tem que ser de 1 a 5")]
        [Required]
        public string Propriedade { get; set; }



        [Required(ErrorMessage = "Tem que escolher uma prioridade")]
        [Display(Name = "Prioridade")]
        public virtual TipoPrioridade TiposDeAjuda { get; set; }

        public List<FileDetails> Files { get; set; }
           = new List<FileDetails>();

        //public IFormFile MyProperty { get; set; }

    }
}
