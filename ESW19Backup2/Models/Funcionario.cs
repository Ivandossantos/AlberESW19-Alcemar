using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }


        [Display(Name = "Data de Nascimento")]
        [Range(typeof(DateTime), "1/1/1948", "1/1/2000",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada")]
        public DateTime Data { get; set; }

        public int Telemovel { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        //public Formacoes Formacao { get; set; }

        //public Dictionary<int, string> Formacao { get; set; }

        //public Funcionario()
        //{
        //    Formacao = new Dictionary<int, string>()
        //    {
        //        { 0, "Secundario"},
        //        { 1, "Licenciatura"},
        //        { 2, "Mestrado"},
        //        { 3, "Doutorado"},
        //        { 4, "Outro"},

        //    };
        //}



        //public enum Formacoes
        //{
        //    Secundario,
        //    Licenciatura, 
        //    Mestrado, 
        //    Doutoramento, 
        //    Outro
        //}

        //public Funcionario() { }
    }
}
