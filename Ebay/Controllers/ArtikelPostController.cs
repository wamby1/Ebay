using Ebay.Data;
using Ebay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace Ebay.Controllers
{
    public class ArtikelPostController : Controller
        
    {
        private readonly ApplicationDbContext _context;
        public ArtikelPostController( ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateArtikel(Artikel artikel, IEnumerable<IFormFile> files)
        {
            // fIles umwandeln und in der Ar
            //todo in der Datenbank schreiben
            return RedirectToAction("Index");
        }
        public IActionResult CreateEditArtikel(int id)
        {
            return View();
        }
        public List<ArtikelImage> CreateArtikelImages(IEnumerable<IFormFile> files, string ownerUser)
        {
            List<ArtikelImage> artikelImages = new List<ArtikelImage>();

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    byte[] imageData;

                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        imageData = memoryStream.ToArray();
                    }

                    ArtikelImage artikelImage = new ArtikelImage
                    {
                        ImageData = imageData,
                       
                    };

                    artikelImages.Add(artikelImage);
                }
            }

            return artikelImages;
        }

    }
}
