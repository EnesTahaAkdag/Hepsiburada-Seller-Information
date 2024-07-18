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
        [HttpGet]
        public JsonResult SendData(StoreInfo model)
        {
            var data = new StoreInfo()
            {
                Id = model.Id,
                Link = model.Link,
                StoreName = model.StoreName,
                Telephone = model.Telephone,
                Email = model.Email,
                Address = model.Address,
                Fax = model.Fax,
                Mersis = model.Mersis,
                Category = model.Category,
                StoreScore = model.StoreScore,
                NumberOfRatings = model.NumberOfRatings,
                NumberOfFollowers = model.NumberOfFollowers,
                AverageDeliveryTime = model.AverageDeliveryTime,
                ResponseTime = model.ResponseTime,
                RatingScore = model.RatingScore,
                NumberOfComments = model.NumberOfComments,
                NumberOfProducts = model.NumberOfProducts,
                SellerName  = model.SellerName,
                VKN = model.VKN,
            };
            return Json(data);
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
            public string NumberOfProducts { get; set; }
            public string SellerName { get; set; }
            public string VKN { get; set; }
        }
    }
}