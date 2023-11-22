using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlowerMarket.Models;

namespace FlowerMarket.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly DBase _context;

        public AdminPanelController(DBase context)
        {
            _context = context;
        }

        // GET: AdminPanel
        public async Task<IActionResult> Index()
        {
              return _context.data != null ? 
                          View(await _context.data.ToListAsync()) :
                          Problem("Entity set 'DBase.data'  is null.");
        }

        // GET: AdminPanel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.data == null)
            {
                return NotFound();
            }

            var flowerModel = await _context.data
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerModel == null)
            {
                return NotFound();
            }

            return View(flowerModel);
        }

        // GET: AdminPanel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Img,Price")] FlowerModel flowerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flowerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flowerModel);
        }

        // GET: AdminPanel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.data == null)
            {
                return NotFound();
            }

            var flowerModel = await _context.data.FindAsync(id);
            if (flowerModel == null)
            {
                return NotFound();
            }
            return View(flowerModel);
        }

        // POST: AdminPanel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Img,Price")] FlowerModel flowerModel)
        {
            if (id != flowerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flowerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerModelExists(flowerModel.Id))
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
            return View(flowerModel);
        }

        // GET: AdminPanel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.data == null)
            {
                return NotFound();
            }

            var flowerModel = await _context.data
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flowerModel == null)
            {
                return NotFound();
            }

            return View(flowerModel);
        }

        // POST: AdminPanel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.data == null)
            {
                return Problem("Entity set 'DBase.data'  is null.");
            }
            var flowerModel = await _context.data.FindAsync(id);
            if (flowerModel != null)
            {
                _context.data.Remove(flowerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerModelExists(int id)
        {
          return (_context.data?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
