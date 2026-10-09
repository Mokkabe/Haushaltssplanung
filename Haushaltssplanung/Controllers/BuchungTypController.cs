
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Haushaltssplanung.Models;

public class BuchungTypController : Controller
{
    private readonly HaushaltssplanungContext _context;

    public BuchungTypController(HaushaltssplanungContext context)
    {
        _context = context;
    }

    // GET: BUCHUNGTYPS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.BuchungTyp.ToListAsync());
    }

    // GET: BUCHUNGTYPS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buchungtyp = await _context.BuchungTyp
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buchungtyp == null)
        {
            return NotFound();
        }

        return View(buchungtyp);
    }

    // GET: BUCHUNGTYPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BUCHUNGTYPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Bezeichnung,Buchung")] BuchungTyp buchungtyp)
    {
        if (ModelState.IsValid)
        {
            _context.Add(buchungtyp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(buchungtyp);
    }

    // GET: BUCHUNGTYPS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buchungtyp = await _context.BuchungTyp.FindAsync(id);
        if (buchungtyp == null)
        {
            return NotFound();
        }
        return View(buchungtyp);
    }

    // POST: BUCHUNGTYPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Bezeichnung,Buchung")] BuchungTyp buchungtyp)
    {
        if (id != buchungtyp.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(buchungtyp);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuchungTypExists(buchungtyp.Id))
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
        return View(buchungtyp);
    }

    // GET: BUCHUNGTYPS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buchungtyp = await _context.BuchungTyp
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buchungtyp == null)
        {
            return NotFound();
        }

        return View(buchungtyp);
    }

    // POST: BUCHUNGTYPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var buchungtyp = await _context.BuchungTyp.FindAsync(id);
        if (buchungtyp != null)
        {
            _context.BuchungTyp.Remove(buchungtyp);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BuchungTypExists(int? id)
    {
        return _context.BuchungTyp.Any(e => e.Id == id);
    }
}
