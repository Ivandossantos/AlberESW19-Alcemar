using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;





namespace ESW19Backup2.Models
{
    public partial class Image
    {

        public int ImageID { get; set; }

        public int ImageSize { get; set; }

        public string FileName { get; set; }

        public byte[] ImageData { get; set; }

        //[Required(ErrorMessage = "Por favor Selecione uma imagem")]
        //public IFormFile File { get; set; }

        //public string ImagePath { get; set; }

       
    }
}
