namespace Haushaltssplanung.Models
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string? Farbe {  get; set; }
     
        public List<Buchung> Buchung { get; set; } = new List<Buchung>();
    }
}
