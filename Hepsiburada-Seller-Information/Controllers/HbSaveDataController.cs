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


namespace Hepsiburada_Seller_Information.Controllers
{
    public class HbSaveDataController : Controller
    {
        HepsiburadaSellerInformationEntities db = new HepsiburadaSellerInformationEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
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
        public class StoreInfo
        {
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
        }

    }
}