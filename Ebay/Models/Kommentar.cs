using System;

namespace Ebay.Models
{
    public class Kommentar
    {
        public int Id { get; set; }
        public string Inhalt { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public string OwnerUser { get; set; }
    }
}
