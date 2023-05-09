using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_SolCar;
using Projeto_SolCar.Entidades;

namespace Projeto_SolCar.Controllers
{
    public class PlanosController : Controller
    {
        private readonly Contexto db;

        public PlanosController(Contexto context)
        {
            db = context;
        }

        // GET: Planos
        public async Task<IActionResult> Index()
        {
              return db.Planos != null ? 
                          View(await db.Planos.ToListAsync()) :
                          Problem("Entity set 'Contexto.Planos'  is null.");
        }

        // GET: Planos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Planos == null)
            {
                return NotFound();
            }

            var planos = await db.Planos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planos == null)
            {
                return NotFound();
            }

            return View(planos);
        }

        // GET: Planos/Create
        public IActionResult CadastroSeguroCasa()
        {
            return View();
        }

        public IActionResult CadastroSeguroCarro()
        {
            return View();
        }

        // POST: Planos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroSeguroCasa([Bind("Id,Observacao")] Planos planos)
        {
            if (ModelState.IsValid)
            {
                db.Add(planos);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroSeguroCarro([Bind("Id,Observacao")] Planos planos)
        {
            if (ModelState.IsValid)
            {
                db.Add(planos);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planos);
        }



        // GET: Planos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Planos == null)
            {
                return NotFound();
            }

            var planos = await db.Planos.FindAsync(id);
            if (planos == null)
            {
                return NotFound();
            }
            return View(planos);
        }

        // POST: Planos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Observacao")] Planos planos)
        {
            if (id != planos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(planos);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanosExists(planos.Id))
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
            return View(planos);
        }

        // GET: Planos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Planos == null)
            {
                return NotFound();
            }

            var planos = await db.Planos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planos == null)
            {
                return NotFound();
            }

            return View(planos);
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Planos == null)
            {
                return Problem("Entity set 'Contexto.Planos'  is null.");
            }
            var planos = await db.Planos.FindAsync(id);
            if (planos != null)
            {
                db.Planos.Remove(planos);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanosExists(int id)
        {
          return (db.Planos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
