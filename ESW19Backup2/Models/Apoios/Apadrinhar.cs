using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models.Apoios
{
    public class Apadrinhar
    {
        public int ApadrinharId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome Padrinho/Madrinha")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Morada é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Morada/Localidade")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "O Numero de Telefone é obrigatório", AllowEmptyStrings = false)]
        [Range(910000000, 999999999, ErrorMessage = "O número de telefone está incorreto")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tem que escolher um tipo de ajuda")]
        [Display(Name = "Tipo de Ajuda")]
        public int TipoApadrinhamentoId { get; set; }

        [Required(ErrorMessage = "Tem que escolher um tipo de ajuda")]
        [Display(Name = "Tipo de Ajuda")]
        public virtual TipoApadrinhamento TiposDeAjuda { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Nome do Cão")]
        public string NomeCao { get; set; }
    }
}
