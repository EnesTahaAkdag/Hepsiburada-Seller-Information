using Hepsiburada_Seller_Information.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Hepsiburada_Seller_Information.Controllers
{
    public class HbSaveDataController : Controller
    {
        HepsiburadaSellerInformationEntities db = new HepsiburadaSellerInformationEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var dataList = db.Seller_Information.ToList();
            return View(dataList);
        }
        [HttpPost]
        public ActionResult Index(StoreInfo model)
        {
            if (ModelState.IsValid)
            {
                var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
                if (dataControl != null)
                {
                    return Json(new { success = false, Message = "Mağza Zaten Var" });
                }
                else
                {
                    var models = new Seller_Information
                    {
                        Link = model.Link,
                        StoreName = model.StoreName,
                    };
                    db.Seller_Information.Add(models);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Gelen Veri:" + models });
                }
            }
            return Json(new { success = false, message = "Veri Gelmedi" });
        }
        [HttpGet]
        public JsonResult getUrl()
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
        public ActionResult UpdateCategory(StoreInfo model)
        {
            if (ModelState.IsValid)
            {
                var dataControl = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
                if (dataControl == null)
                {
                    return Json(new { success = false, message = "Böyle Bir Mağaza Yok" });
                }
                else
                {
                    dataControl.Category = model.Category;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Kategori başarıyla güncellendi.", updatedCategory = dataControl.Category });
                }
            }
            return Json(new { success = false, message = "Kategori Gelmedi" });
        }

        [HttpPost]
        public ActionResult updatedata(StoreInfo model)
        {
            if (!ModelState.IsValid)
            {
                var datacontrol = db.Seller_Information.FirstOrDefault(m => m.StoreName == model.StoreName);
                if (datacontrol == null)
                {
                    return Json(new { success = false, message = "Böyle Bir Mağaza Yok" });
                }
                else
                {
                    datacontrol.StoreScore = model.StoreScore;
                    datacontrol.NumberOfFollowers = model.NumberOfFollowers;
                    datacontrol.NumberOfProducts = model.NumberOfProducts;
                    datacontrol.RatingScore = model.RatingScore;
                    datacontrol.AverageDeliveryTime = model.AverageDeliveryTime;
                    datacontrol.ResponseTime = model.ResponseTime;
                    datacontrol.Email = model.Email;
                    datacontrol.NumberOfRatings = model.NumberOfRatings;
                    datacontrol.NumberOfComments = model.NumberOfComments;
                }
                db.SaveChanges();
                return Json(new { success = true, message = "Güncelleme Başarılı"});
            }
            return Json(new { success = false, message = "Veriler Kaydedilmedi" });

        }
        public class StoreInfo
        {
            public long Id { get; set; }
            public string Link { get; set; }
            public string StoreName { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Fax { get; set; }
            public string Mersis { get; set; }
            public string Category { get; set; }
            public decimal StoreScore { get; set; }
            public int NumberOfRatings { get; set; }
            public int NumberOfFollowers { get; set; }
            public string AverageDeliveryTime { get; set; }
            public string ResponseTime { get; set; }
            public decimal RatingScore { get; set; }
            public int NumberOfComments { get; set; }
            public int NumberOfProducts { get; set; }
            public string SellerName { get; set; }
            public string VKN { get; set; }
        }
    }
}