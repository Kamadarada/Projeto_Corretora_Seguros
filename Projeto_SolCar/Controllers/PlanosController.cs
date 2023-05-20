using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_SolCar;
using Projeto_SolCar.Entidades;
using Projeto_SolCar.Models;

namespace Projeto_SolCar.Controllers
{

    //[Authorize(AuthenticationSchemes = "CookieAuthentication")]

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
        public IActionResult CadastroSeguroCasa(CadastroCasaInsert data)
        {

            Clientes cliente = db.Clientes.Where(a => a.Id == data.ClienteId).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest();
            }


            SeguroCasa seguroCasa = new SeguroCasa
            {
                TipoResedência = data.TipoResedência,
                TipoCobertura = data.TipoCobertura,
                Basica = data.Basica,
                DanosMorais = data.DanosMorais,
                DanosEletricos = data.DanosEletricos,
                Equipamentos = data.Equipamentos,
                Aluguel = data.Aluguel,
                Vidros = data.Vidros,
                Roubo = data.Roubo,
                Vendaval = data.Vendaval,
                Alagamentos = data.Alagamentos,
                Impacto = data.Impacto,
                Desmoronamento = data.Desmoronamento,
                Observacao = data.Observacao,
                DataContratoCasa = data.DataContratoCasa,
                DataExpiraCasa = data.DataExpiraCasa,
                Clientes = cliente
                

            };



            //db.cliente?.Planos?.Add(seguroCasa);

            db.Planos.Add(seguroCasa); // Este está funcionando, porém não recebe os clientes.Id. Está passando como NULL

            db.SaveChanges();
            return RedirectToAction("Consulta", "Clientes");
        }

        // POST: Planos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroSeguroCarro(CadastroCarroInsert data)
        {

            Clientes cliente = db.Clientes.Where(a => a.Id == data.ClienteId).FirstOrDefault();

            if (cliente == null)
            {
                return BadRequest();
            }

            SeguroCarro seguroCarro = new SeguroCarro
            {
                Chassi = data.Chassi,
                Placa = data.Placa,
                AnoFabricacao = data.AnoFabricacao,
                AnoModelo = data.AnoModelo,
                Modelo = data.Modelo,
                Marca = data.Marca,
                Quilometragem = data.Quilometragem,
                FIPE = data.FIPE,
                TipoCobertura = data.TipoCobertura,
                Descricao = data.Descricao,
                DataContratoCarro = data.DataContratoCarro,
                DataExpiraCarro = data.DataExpiraCarro,
                Clientes = cliente

            };

            //cliente?.Planos?.Add(seguroCarro); 

            db.Planos.Add(seguroCarro); // Gambiarra
            
            db.SaveChanges();
            return RedirectToAction("Consulta", "Clientes");
        }

        public ActionResult ListaPlanoCarro()
        {
            return View(db.SeguroCarro.ToList());
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
