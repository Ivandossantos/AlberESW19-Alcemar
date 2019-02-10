using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models.Upload
{
    public class FileDetails
    {
        public int FileDetailsId { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }

        [Range(1, 5, ErrorMessage = "A propriedade tem que ser de 1 a 5")]
        [Required]
        public string Prioridade { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        public int TipoPrioridade { get; set; }

        [Required(ErrorMessage = "Tem que escolher uma prioridade")]
        [Display(Name = "Prioridade")]
        public virtual TipoPrioridade TiposDeAjuda { get; set; }
    }


    public class FilesViewModel
    {

        public int FilesViewModelID { get; set; }

        public List<FileDetails> Files { get; set; }
            = new List<FileDetails>();

        [Range(1, 5, ErrorMessage = "A propriedade tem que ser de 1 a 5")]
        [Required]
        [Display(Name = "Prioridade")]
        public string Propriedade { get; set; }


        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        public int TipoPrioridade { get; set; }

        [Required(ErrorMessage = "Tem que escolher uma prioridade")]
        [Display(Name = "Prioridade")]
        public virtual TipoPrioridade TiposDeAjuda { get; set; }


    }
}
