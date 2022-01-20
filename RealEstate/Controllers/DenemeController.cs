using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deneme/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deneme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deneme/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deneme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deneme/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deneme/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deneme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
