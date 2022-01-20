using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RealEstate.DataAccess;
using RealEstate.Models;
using RealEstate.Models.ViewModels;
using RealEstate.ModelBase;
using System.Web.UI.WebControls;

namespace RealEstate.Controllers
{
    public class AdvertResidentialController : Controller
    {
        private static AdvertResidential _advertResidential { get; set; }
        public static AdvertResidential advertResidential
        {
            get
            {
                if (_advertResidential == null)
                    _advertResidential = new AdvertResidential();
                return _advertResidential;
            }
            set
            {
                _advertResidential = value;
            }
        }

        // GET: AdvertResidential
        public ActionResult Index()
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            List<AdvertResidential> advertResidentials = advertiesment.GetAdvertResidentials();
            List<AdverticeViewModel> adverticeViewModels = new List<AdverticeViewModel>();

            advertResidentials.ForEach(advert =>
                adverticeViewModels.Add(new AdverticeViewModel
                {
                    Date = advert.Date,
                    IsActive = advert.IsActive,
                    Title = advert.Title,
                    Explaination = advert.Explaination,
                    Msquare = advert.RealEstate.Msquare,
                    Balcony = advert.RealEstate.Balcony,
                    Furnished = advert.RealEstate.Furnished,
                    UserId = advert.UserId,
                    AdvertType = advert.AdvertType,
                    Heating = advert.RealEstate.Heating

                })
                  ); ;
            return View(adverticeViewModels);
        }


        // GET: AdvertResidential/Details/5
        public ActionResult Details(int id) // int id parametresi eklenecek!!!
        {
            AdvertResidentialDal advertiesment = new AdvertResidentialDal(new ResidentialDal());
            var result = advertiesment.GetResidentialById(id);
            AdverticeViewModel vm;
            vm = new AdverticeViewModel()
            {

                AdvertId = result.AdvertiseId,
                Date = result.Date,
                IsActive = result.IsActive,
                Title = result.Title,
                Explaination = result.Explaination,
                Msquare = result.RealEstate.Msquare,
                Balcony = result.RealEstate.Balcony,
                Furnished = result.RealEstate.Furnished,
                AddressId = result.RealEstate.AddressID,
                Age = result.RealEstate.Age,
                FloorNumber = result.RealEstate.FloorNumber,
                Heating = result.RealEstate.Heating,
                SellType = result.RealEstate.SellType,
                AdvertType = result.AdvertType


            };

            return View(vm);
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
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                FormsAuthentication.SetAuthCookie("admin", false);
                return RedirectToAction("Create");
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Search(string arananKelime)
        {
            List<AdvertResidential> residentials = new List<AdvertResidential>();
            residentials = AdvertResidentialDal.Current.Search(arananKelime);

            //TempData["arananKelime"] = arananKelime;
            return View(residentials);
        }

        [HttpPost]
        public ActionResult Create(Residential residential)
        {
            object insertedID = ResidentialDal.Current.Create(residential);
            residential.ResidentialId = Convert.ToInt32(insertedID);

            if (Convert.ToInt32(insertedID) > 0)
            {
                // Kaydetme başarılı ise fotoğrafı yükle.
                if (residential.Foto != null)
                {
                    FotoUpload(advertResidential);
                }
            }
            TempData["insertedID"] = insertedID.ToString();
            return RedirectToAction("Index");
        }

        [NonAction] // Bu metot controller acction'ı değildir.

        private void FotoUpload(AdvertResidential advertResidential)
        {
            string userPath = Server.MapPath($"~/UploadedFiles/Residentials/{advertResidential.AdvertiseId }/");
            if (!Directory.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
            }
            string fotoPath = Path.Combine(userPath, Path.GetFileName(advertResidential.Foto.FileName));
            advertResidential.Foto.SaveAs(fotoPath);
            advertResidential.FotoAdres = advertResidential.AdvertiseId + "/" + advertResidential.Foto.FileName;
            AdvertResidentialDal.Current.Update(advertResidential);
        }




    }
}
