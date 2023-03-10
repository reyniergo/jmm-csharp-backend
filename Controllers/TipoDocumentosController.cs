using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSHARP_TEST1.Data;
using CSHARP_TEST1.Models;

namespace CSHARP_TEST1.Controllers
{
    public class TipoDocumentosController : Controller
    {
        private readonly CSHARP_TEST1Context _context;

        public TipoDocumentosController(CSHARP_TEST1Context context)
        {
            _context = context;
        }

        // GET: TipoDocumentos
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoDocumentos.ToListAsync());
        }

        // GET: TipoDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.CodDoc == id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDoc,Titulo,Inactivo")] TipoDocumentos tipoDocumentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }
            return View(tipoDocumentos);
        }

        // POST: TipoDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodDoc,Titulo,Inactivo")] TipoDocumentos tipoDocumentos)
        {
            if (id != tipoDocumentos.CodDoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentosExists(tipoDocumentos.CodDoc))
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
            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.CodDoc == id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            return View(tipoDocumentos);
        }

        // POST: TipoDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDocumentos == null)
            {
                return Problem("Entity set 'CSHARP_TEST1Context.TipoDocumentos'  is null.");
            }
            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumentos != null)
            {
                _context.TipoDocumentos.Remove(tipoDocumentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentosExists(int id)
        {
          return _context.TipoDocumentos.Any(e => e.CodDoc == id);
        }
    }
}
