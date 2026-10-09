namespace Haushaltssplanung.Models
{
    public class BuchungTyp
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public List<Buchung> Buchung {  get; set; } = new List<Buchung>();
    }
}
