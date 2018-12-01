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
    public class DiscograficasController : Controller
    {
        protected readonly IGenericRepository<Discografica> repo;

        public DiscograficasController(IGenericRepository<Discografica> _repo)
        {
            this.repo = _repo;

        }
        // GET: Canciones
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        // GET: Canciones/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetID(id));
        }

        // GET: Canciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discografica/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Discografica model)
        {
            try
            {
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

        // GET: Discografica/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: Discografica/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Discografica model)
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

        // GET: Discografica/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetID(id));
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("delete")]
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