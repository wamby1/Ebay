using Ebay.Data;
using Ebay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var ArtikelFromDb= _context.artikels.Where(x=> x.OwnerUser==User.Identity.Name).ToList();
            return View(ArtikelFromDb );
        }
        public IActionResult CreateArtikel(Artikel artikel, IEnumerable<IFormFile> files)
        {
            //user name
            artikel.OwnerUser=User.Identity.Name;
            // fIles umwandeln und in der Ar
            if (files != null)
            {
                List<ArtikelImage> artikelImages = new List<ArtikelImage>();
                artikelImages = CreateArtikelImages(files,artikel);
                artikel.ArtikelImages = artikelImages;
                

            }
            if(artikel.id==0)//artike neue dann erzeugen
            {
                artikel.PostDate = DateTime.Today;
                _context.artikels.Add(artikel);

            }
            else //artikel update
            {
                var artikelFromDB=_context.artikels.SingleOrDefault(x=>x.id==artikel.id);
                if(artikelFromDB==null) {
                    return NotFound();
                }
                artikelFromDB.Preis = artikel.Preis;
                artikelFromDB.ArtikelKategorie=artikel.ArtikelKategorie;
                artikelFromDB.Description=artikel.Description;
                artikelFromDB.ArtikelLocation=artikel.ArtikelLocation;
                artikelFromDB.ArtikelName=artikel.ArtikelName;


                
            }
           
            //todo in der Datenbank schreiben
           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteArtikel(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var artikelFromDb= _context.artikels.SingleOrDefault( x=>x.id==id);
            if (artikelFromDb == null)
            {

                return NotFound();
            }
            _context.artikels.Remove(artikelFromDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateEditArtikel(int id)
        {
            if (id != 0)
            {
                var artikelFromdb= _context.artikels.SingleOrDefault( x=>x.id==id);
                if(artikelFromdb==null)
                {
                    return NotFound();
                }
                else
                {
                    return View(artikelFromdb);
                }
            }

            return View();
        }
        public List<ArtikelImage> CreateArtikelImages(IEnumerable<IFormFile> files,Artikel artikel)
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
                        Artikel = artikel
                       
                    };

                    artikelImages.Add(artikelImage);
                }
            }

            return artikelImages;
        }

    }
}
