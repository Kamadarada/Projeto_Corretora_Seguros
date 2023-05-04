using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Projeto_SolCar.Entidades;

namespace Projeto_SolCar.Controllers
{
    public class ClientesController : Controller
    {

        private readonly Contexto db;
        // GET: ClientesController


        public ClientesController (Contexto contexto)
        {
            db = contexto;
        }

        public ActionResult Consulta()
        {
            return View(db.CLIENTES.ToList());
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View(db.CLIENTES.Where(a => a.Id == id).FirstOrDefault());
        }

        // GET: ClientesController/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Clientes collection)
        {
            try
            {
                db.CLIENTES.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                return View();
            }
        }





        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.CLIENTES.Where(a=> a.Id == id).FirstOrDefault());
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Clientes collection)
        {
            try
            {
                db.CLIENTES.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            db.CLIENTES.Remove(db.CLIENTES.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Consulta");
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Consulta));
            }
            catch
            {
                return View();
            }
        }
    }
}
