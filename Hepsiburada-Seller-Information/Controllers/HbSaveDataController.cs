﻿using Hepsiburada_Seller_Information.Models;
using Hepsiburada_Seller_Information.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Hepsiburada_Seller_Information.Controllers
{
    public class HbSaveDataController : Controller
    {
        private HepsiburadaSellerInformationEntities db = new HepsiburadaSellerInformationEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var dataList = db.Seller_Information.ToList();
            return View(dataList);
        }

        [HttpPost]
        public ActionResult Index(SellerInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
                if (dataControl != null)
                {
                    return Json(new { success = false, message = "Mağaza zaten var." });
                }
                else
                {
                    var newStore = new Seller_Information
                    {
                        Link = model.Link,
                        StoreName = model.StoreName,
                    };
                    db.Seller_Information.Add(newStore);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Yeni mağaza başarıyla eklendi." });
                }
            }
            return Json(new { success = false, message = "Geçersiz veri girişi." });
        }

        [HttpGet]
        public JsonResult GetRandomUrl()
        {
            var randomUrl = db.Seller_Information
                                .OrderBy(r => Guid.NewGuid())
                                .Select(r => r.Link)
                                .FirstOrDefault();
            if (!string.IsNullOrEmpty(randomUrl))
            {
                return Json(new { success = true, url = randomUrl }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Rastgele URL bulunamadı." }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetRandomUrls()
        {
            var randomUrl = db.Seller_Information
                                .OrderBy(r => Guid.NewGuid())
                                .Select(r => r.Link)
                                .FirstOrDefault();
            if (!string.IsNullOrEmpty(randomUrl))
            {
                return Json(new { success = true, url = randomUrl }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "Rastgele URL bulunamadı." }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UpdateCategory(SellerInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
                if (dataControl == null)
                {
                    return Json(new { success = false, message = "Böyle bir mağaza yok." });
                }
                else
                {
                    dataControl.Category = model.Category;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Kategori başarıyla güncellendi.", updatedCategory = dataControl.Category });
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Geçersiz model doğrulama.", errors });
        }

        [HttpGet]
        public JsonResult CheckData(SellerInformationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Geçersiz model doğrulama.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = "Veriler doğrulandı." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateData(SellerInformationViewModel model)
        {

            var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
            if (dataControl == null)
            {
                return Json(new { success = false, message = "Böyle bir mağaza yok." });
            }
            else
            {
                dataControl.Email = model.Email;
                dataControl.StoreScore = model.StoreScore;
                dataControl.NumberOfRatings = model.NumberOfRatings;
                dataControl.NumberOfFollowers = model.NumberOfFollowers;
                dataControl.AverageDeliveryTime = model.AverageDeliveryTime;
                dataControl.ResponseTime = model.ResponseTime;
                dataControl.RatingScore = model.RatingScore;
                dataControl.NumberOfComments = model.NumberOfComments;
                dataControl.NumberOfProducts = model.NumberOfProducts;
                dataControl.VKN = model.VKN;
                db.SaveChanges();
                return Json(new { success = true, message = "Veri başarıyla güncellendi." });
            }
        }
        [HttpPost]
        public ActionResult UpData(SellerInformationViewModel model)
        {
            var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
            if (dataControl == null)
            {
                return Json(new { success = false, message = "Böyle bir mağaza yok." });
            }
            else
            {
                dataControl.SellerName = model.SellerName;
                dataControl.Telephone = model.Telephone;
                dataControl.Address = model.Address;
                dataControl.Fax= model.Fax;
                dataControl.Mersis = model.Mersis;
                db.SaveChanges();
                return Json(new { success = true, message = "Veri başarıyla güncellendi." });
            }
        }
    }
}