using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Models.Apoios
{
    public class Area
    {
        public int AreaId { get; set; }

        [Display(Name = "Área a que se propõe")]
        public string Nomes { get; set; }
    }
}
