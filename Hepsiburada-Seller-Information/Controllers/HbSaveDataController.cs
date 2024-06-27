using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Hepsiburada_Seller_Information.Controllers
{
    public class HbSaveDataController : Controller
    {
        // GET: HbSaveData
        public ActionResult Index(string StoreName)
        {
            return View();
        }

        public class Store
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
            public string RatingScore { get; set; } // Assuming rating score can have decimals
            public decimal NumberOfComments { get; set; }
            public bool FastSeller { get; set; } // Assuming FastSeller is a boolean (true/false)
            public int NumberOfProducts { get; set; }
            public string SellerName { get; set; }
        }

    }
}