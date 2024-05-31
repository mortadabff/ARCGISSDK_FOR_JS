using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Géoportail.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Géoportail.Controllers
{
    public class ReclamationsController : Controller
    {
        private readonly TestContext _context;

        public ReclamationsController(TestContext context)
        {
            _context = context;
        }

        // GET: Reclamations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reclamatiosns.ToListAsync());
        }

        // GET: Reclamations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamation = await _context.Reclamatiosns
                .FirstOrDefaultAsync(m => m.Objectid1 == id);
            if (reclamation == null)
            {
                return NotFound();
            }

            return View(reclamation);
        }

        // GET: Reclamations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reclamations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Objectid,Objet,Message,DemarcheD,Mail")] Reclamatiosn reclamation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reclamation);
        }

        // GET: Reclamations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamation = await _context.Reclamatiosns.FindAsync(id);
            if (reclamation == null)
            {
                return NotFound();
            }
            return View(reclamation);
        }

        // POST: Reclamations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Objectid,Objet,Message,DemarcheD,Mail")] Reclamatiosn reclamation)
        {
            if (id != reclamation.Objectid1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamationExists(reclamation.Objectid1))
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
            return View(reclamation);
        }
        public ActionResult Zoom(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(statusCode: 400);
            }
            Reclamatiosn rec = _context.Reclamatiosns.Find(id);
            if (rec == null)
            {
                return new StatusCodeResult(statusCode: 404);
            }
            return View(rec);
        }
        // GET: Reclamations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamation = await _context.Reclamatiosns
                .FirstOrDefaultAsync(m => m.Objectid1 == id);
            if (reclamation == null)
            {
                return NotFound();
            }

            return View(reclamation);
        }

        // POST: Reclamations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamation = await _context.Reclamatiosns.FindAsync(id);
            _context.Reclamatiosns.Remove(reclamation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamationExists(int id)
        {
            return _context.Reclamatiosns.Any(e => e.Objectid1 == id);
        }
    }
}
