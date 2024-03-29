﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Projeto_SolCar.Entidades;
using Projeto_SolCar.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Projeto_SolCar.Controllers
{

    //[Authorize(AuthenticationSchemes = "CookieAuthentication")]

    public class ClientesController : Controller
    {



        private readonly Contexto db;
        // GET: ClientesController


        
       

        public ClientesController (Contexto contexto)
        {
            db = contexto;
        }

        public ActionResult SelecionarPlano(int id)
        {
            return View(db.Clientes.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public JsonResult Ajax(string query)
        {
            return Json(db.Clientes.Where(a => a.Nome.Contains(query)));
        }
        

        public ActionResult Consulta()
        {
           
          return View(db.Clientes.ToList());
        
        }

        public ActionResult ConsultaPlano()
        {
            return View(db.Clientes.ToList());
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            //PlanosViewModel model = new PlanosViewModel();
            //model.Seguro_Casa = db.Planos.ToList();
            var Cliente = db.Clientes.Where(a => a.Id == id).FirstOrDefault();

            var PlanosViewModel = new PlanosViewModel
            {
                Nome = Cliente.Nome,
                Telefone = Cliente.Telefone,
                RG = Cliente.RG,
                CEP = Cliente.CEP,
                Email = Cliente.Email,
                Bairro = Cliente.Bairro,
                Data_nasc = Cliente.Data_nasc,
                Cidade = Cliente.Cidade,
                CPF = Cliente.CPF,
                Sexo = Cliente.Sexo,
                Endereco = Cliente.Endereco,
                Estado = Cliente.Estado,
                Id = Cliente.Id

            };

            PlanosViewModel.Seguro_Carro = db.SeguroCarro.Where(x=> x.Clientes.Id == id).ToList();
            PlanosViewModel.Seguro_Casa = db.SeguroCasa.Where(x=> x.Clientes.Id ==id).ToList();

            return View(PlanosViewModel);
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
                db.Clientes.Add(collection);
                db.SaveChanges();
                return RedirectToAction("SelecionarPlano", "Clientes", new { id = collection.Id } );
            }
            catch
            {
                return View();
            }
        }


        public IActionResult direcionaPlanoCarro()
        {
            return RedirectToAction("ListaPlanoCarro", "Planos");

        }

        



        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Clientes.Where(a=> a.Id == id).FirstOrDefault());
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Clientes collection)
        {
            try
            {
                db.Clientes.Update(collection);
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
            //db.Clientes.Remove(db.Clientes.Where(a => a.Id == id).FirstOrDefault());
            var Clientes = db.Clientes.Where(a => a.Id == id).Include(a => a.Planos).First();
            db.Remove(Clientes);
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


        //Informações de LOGIN e LOGOFF




    }

}
