using System.ComponentModel.DataAnnotations;

namespace Haushaltssplanung.Models
{
    public class Buchung
    {
        public int Id { get; set; }
        public decimal Betrag { get; set; }
        public DateTimeOffset Datum { get; set; }
        [MaxLength(50)]
        public string Beschreibung { get; set; }
        public int KategorieId { get; set; }
        public int BuchungTypId { get; set; }
        public Kategorie  Kategorie { get; set; }
        public BuchungTyp BuchungTyp { get; set; }


    }
}
