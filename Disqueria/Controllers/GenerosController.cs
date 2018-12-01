using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disqueria.DAL;
using Disqueria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disqueria.Controllers
{
    public class GenerosController : Controller
    {
        protected readonly IGenericRepository<Genero> repo;
        public GenerosController(IGenericRepository<Genero> _repo)
        {
            this.repo = _repo;

        }
        // GET: Generos
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Generos/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetID(id));
        }

        // GET: Generos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Generos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Add(model);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Generos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: Generos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genero model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                repo.Update(model);
                repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Generos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: Generos/Delete/5
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