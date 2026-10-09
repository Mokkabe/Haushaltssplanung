using Microsoft.EntityFrameworkCore;

public class HaushaltssplanungContext(DbContextOptions<HaushaltssplanungContext> options) : DbContext(options)
{
    public DbSet<Haushaltssplanung.Models.Buchung> Buchung { get; set; } = default!;
    public DbSet<Haushaltssplanung.Models.BuchungTyp> BuchungTyp { get; set; } = default!;
    public DbSet<Haushaltssplanung.Models.Kategorie> Kategorie { get; set; } = default!;

}
