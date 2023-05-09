namespace Ebay.Models
{
    public class ArtikelImage
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; } // byte array da die daten convertiert und in ein array gespeichert werden
        public string OwnerUser { get; set; }
    }
}
