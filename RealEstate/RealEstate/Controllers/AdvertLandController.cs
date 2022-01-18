using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Controllers
{
    public class AdvertLandController : Controller
    {
        // GET: AdvertLand
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdvertLand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertLand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertLand/Create
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

        // GET: AdvertLand/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertLand/Edit/5
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

        // GET: AdvertLand/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertLand/Delete/5
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
