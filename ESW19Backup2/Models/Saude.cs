using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models
{
    public class Saude
    {
        public int SaudeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = ("Data da Vacina"))]
        public DateTime DataVacina { get; set; }

        [Display(Name = "Estado")]
        public virtual Estado Estado { get; set; }

        [Required(ErrorMessage ="{0} é Obrigatorio")]
        public string Avaliacao { get { return this.Avaliar(Estado); } }

        public int CaoId { get; set; }
      
        public virtual Cao Cao { get; set; }

        public string Avaliar(Estado value)
        {
            string estado = value.Nome;

            switch (estado)
            {
                case "em Espera":
                case "Em Espera":
                    return "Ainda não foi vacinado";
                case "vacinado":
                case "Vacinado":
                    return " Ja foi vacinado";
                case "cancelado":
                case"Cancelado":
                    return "A Vacina foi cancelado, contato a Clinica para saber de mais informações";


               default:
                    return "Não Existe vacinas para marcar";

            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime expectedFormatDate;
            List<ValidationResult> res = new List<ValidationResult>();
            if (DataVacina < DateTime.Today)
            {
                ValidationResult mss = new ValidationResult("A data inserida deve ser superior ou igual a de hoje");
                res.Add(mss);
            }
            return res;

            if (!DateTime.TryParseExact(DataVacina.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out expectedFormatDate))
            {
                ValidationResult mss = new ValidationResult("A data inserida não está no formato indicado");
                res.Add(mss);
            }

        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
