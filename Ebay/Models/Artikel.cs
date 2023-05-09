using System;
using System.Collections.Generic;

namespace Ebay.Models
{
    public class Artikel
    {
        
        public int id { get; set; }
        public string ArtikelKategorie { get; set; }
        public string ArtikelLocation { get; set; }
        public string Description { get; set; }
        public int Preis { get; set; }
        public DateTime PostDate { get; set; }
       
        public string OwnerUser { get; set; }
        public int gesehen { get; set; }
        public List<ArtikelImage> ArtikelImages { get; set; }
        public List<Kommentar> Kommentare { get; set; }
        public Artikel()
        {
            this.ArtikelImages = new List<ArtikelImage>();
            this.Kommentare = new List<Kommentar>();
        }
      
    }
}
