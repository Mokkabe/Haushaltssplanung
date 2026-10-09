
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Haushaltssplanung.Models;

public class BuchungController : Controller
{
    private readonly HaushaltssplanungContext _context;

    public BuchungController(HaushaltssplanungContext context)
    {
        _context = context;
    }

    // GET: BUCHUNGS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Buchung.ToListAsync());
    }

    // GET: BUCHUNGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buchung = await _context.Buchung
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buchung == null)
        {
            return NotFound();
        }

        return View(buchung);
    }

    // GET: BUCHUNGS/Create
    public IActionResult Create()
    {
        SetViewData();
        return View();
    }

    // POST: BUCHUNGS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Betrag,Datum,Beschreibung,KategorieId,BuchungTyp,Kategorie")] Buchung buchung)
    {
        SetViewData();
        if (ModelState.IsValid)
        {
           
            _context.Add(buchung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(buchung);
    }

    // GET: BUCHUNGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        SetViewData();
        if (id == null)
        {
            return NotFound();
        }

        var buchung = await _context.Buchung.FindAsync(id);
        if (buchung == null)
        {
            return NotFound();
        }
        return View(buchung);
    }

    // POST: BUCHUNGS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Betrag,Datum,Beschreibung,KategorieId,BuchungTyp,Kategorie")] Buchung buchung)
    {
        SetViewData();
        if (id != buchung.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(buchung);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuchungExists(buchung.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(buchung);
    }

    // GET: BUCHUNGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buchung = await _context.Buchung
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buchung == null)
        {
            return NotFound();
        }

        return View(buchung);
    }

    // POST: BUCHUNGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var buchung = await _context.Buchung.FindAsync(id);
        if (buchung != null)
        {
            _context.Buchung.Remove(buchung);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BuchungExists(int? id)
    {
        return _context.Buchung.Any(e => e.Id == id);
    }

    private void SetViewData()
    {
        var buchungstypen = _context.BuchungTyp.ToList();
        var kategorien = _context.Kategorie.ToList();
        ViewData["buchungstypen"] = buchungstypen;
        ViewData["kategorien"] = kategorien;

        
    }
}
