using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Data.Entity;
using System.Threading.Tasks;
using Hepsiburada_Seller_Information.Models;
using System.Text.RegularExpressions;
using System.Web.Management;
using HtmlAgilityPack;
using Newtonsoft.Json;

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

        public class StoreInfo
        {
            public int Id { get; set; }
            public string Link { get; set; }
            public string StoreName { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Fax { get; set; }
            public string Mersis { get; set; }
            public string Category { get; set; }
            public decimal StoreScore { get; set; }
            public int NumberOfRating { get; set; }
            public int NumberOfFollowers { get; set; }
            public int AverageDeliveryTime { get; set; }
            public int ResponseTime { get; set; }
            public string RatingScore { get; set; }
            public decimal NumberOfComments { get; set; }
            public bool FastSeller { get; set; }
            public int NumberOfProducts { get; set; }
            public string SellerName { get; set; }
            public string VKN { get; set; }
        }

    }
}