using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESW19Backup2.Controllers
{
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment he;
        public ImageController(IHostingEnvironment e)
        {
            he = e;
        }


        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Este Metodo que contem as imagens da Galeria
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public ActionResult Add(/*string fullName, IFormFile pic*/)
        {
            //ViewData["fname"] = fullName;
            //if (pic != null)
            //{
            //    var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
            //    pic.CopyTo(new FileStream(fileName, FileMode.Create));
            //    ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);

            //}

            if (User.Identity.Name == "akxeldacosta8@gmail.com")
            {
                return RedirectToAction(nameof(ImageController.Index), "Image");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Serve para inserir a imagem na galeria
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="pic"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ActionResult Add_Next(string fullName, IFormFile pic)
        {
            ViewData["fname"] = fullName;
            if (pic != null)
            {
                var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);

            }

            return View();
        }
    }
}