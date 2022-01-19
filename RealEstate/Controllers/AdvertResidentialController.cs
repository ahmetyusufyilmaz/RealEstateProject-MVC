using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstate.DataAccess;
using RealEstate.Models;
using RealEstate.Models.ViewModels;

namespace RealEstate.Controllers
{
    public class AdvertResidentialController : Controller
    {
        // GET: AdvertResidential
        public ActionResult Index()
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            List<AdvertResidential> advertResidentials = advertiesment.GetAdvertResidentials();
            List<AdverticeViewModel> adverticeViewModels = new List<AdverticeViewModel>();

            advertResidentials.ForEach(ad =>
                adverticeViewModels.Add(new AdverticeViewModel
                {
                    Date = ad.Date,
                    IsActive = ad.IsActive,
                    Title = ad.Title,
                    Explaination = ad.Explaination,
                    Msquare = ad.RealEstate.Msquare,
                    Balcony = ad.RealEstate.Balcony,
                    Furnished = ad.RealEstate.Furnished
                })
                  );
            return View(adverticeViewModels);
        }


        // GET: AdvertResidential/Details/5
        public ActionResult Details() // int id parametresi eklenecek!!!
        {
            Residential house = new Residential();
            house.ResidentialId = 1;
            house.Msquare = 160;        
            house.Heating = HeatingType.NaturalGas;
            house.FloorNumber = 2;
            house.Age = 4;
            house.Balcony = true;
            house.Furnished = false;

            User user = new User();
            user.Email = "test@test.com";
            user.FullName = "Test Testson";

            AdvertResidential advertRes = new AdvertResidential() { AdvertiseId = 1, Date = DateTime.Today, IsActive = true, Title = "Ankara'nın en merkezi yerinde ev", RealEstate = house, User = user };

            return View(advertRes);
        }

        // GET: AdvertResidential/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertResidential/Create
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

        // GET: AdvertResidential/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertResidential/Edit/5
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

        // GET: AdvertResidential/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdvertResidential/Delete/5
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
