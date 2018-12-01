using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disqueria.DAL;
using Disqueria.Models;
using Disqueria.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disqueria.Controllers
{
    public class DiscosController : Controller
    {
        //creao una instancia del "service";
        protected readonly IDiscoRepository repo;
        public DiscosController(IDiscoRepository _repo)
        {
            // lo llamo y lo inicializo en el controlador
            this.repo = _repo;

        }
        // GET: Discos
        public ActionResult Index()
        {
            return View(repo.Grilla());
        }

        public ActionResult Grilla(string filter = null, int page = 1,
          int pageSize = 5, string sort = "Nombre", string sortdir = "ASC")
        {
            var ret = repo.PagedGrid(pageSize, page, filter, sort, sortdir);
            ViewBag.filter = filter;


            return View(ret);
        }

        // GET: Discos/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetID(id));
        }

        // GET: Discos/Create
        public ActionResult Create()
        {
            
            return View(repo.Get_Edicion(null));
        }

        // POST: Discos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscoEdicion vm)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Add(vm.Edicion); //hasta acá recibe todos los datos a guardar.
                repo.Save();        // se rompe al hacer el Save()
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Discos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.Get_Edicion(id));
        }

        // POST: Canciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscoEdicion vm)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Update(vm.Edicion);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Canciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                repo.Del(id);
                repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}