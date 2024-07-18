using Hepsiburada_Seller_Information.Models;
using Hepsiburada_Seller_Information.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Hepsiburada_Seller_Information.Controllers
{
    public class DataSendAppController : Controller
    {
        private HepsiburadaSellerInformationEntities db = new HepsiburadaSellerInformationEntities();

        [HttpGet]
        public ActionResult MarketPlaceData()
        {
            var data = (from c in db.Seller_Information
                        select new SellerInformationViewModel()
                        {
                            Id = c.ID,
                            Link = c.Link,
                            StoreName = c.StoreName,
                            Telephone = c.Telephone,
                            Email = c.Email,
                            Address = c.Address,
                            Fax = c.Fax,
                            Mersis = c.Mersis,
                            Category = c.Category,
                            StoreScore = c.StoreScore,
                            NumberOfRatings = c.NumberOfRatings,
                            NumberOfFollowers = c.NumberOfFollowers,
                            AverageDeliveryTime = c.AverageDeliveryTime,
                            ResponseTime = c.ResponseTime,
                            RatingScore = c.RatingScore,
                            NumberOfComments = c.NumberOfComments,
                            NumberOfProducts = c.NumberOfProducts,
                            SellerName = c.SellerName,
                            VKN = c.VKN,
                        })/*.Skip(0)*/.Take(10).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}