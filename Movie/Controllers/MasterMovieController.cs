using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{

    public class MasterMovieController : Controller
    {
      
        private readonly IMasterMovieService _masterMovieService;

        public MasterMovieController( IMasterMovieService masterMovieService)
        {
           //set dependency injection
            /*_masterMovieService = new MasterMovieService(_movieContext);*///รูปเเบบdependency
            _masterMovieService = masterMovieService;
        }
        // GET: MasterMovieController
        public ActionResult Index()
        {
            var movies = _masterMovieService.GetAll();
            return View(movies);
        }

        //// GET: MasterMovieController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: MasterMovieController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.Add(item);

                return RedirectToAction("Index");
            }

            return View(item);

        }

        // GET: MasterMovieController/Edit/5
        public ActionResult Edit(int id)
        {
            MasterMovie item = _masterMovieService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }
        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.Update(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterMovieController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MasterMovieController/Delete/5
        public ActionResult Delete(int id)
        {
            _masterMovieService.Delete(id);
            return RedirectToAction("index");

        }

    }
}

