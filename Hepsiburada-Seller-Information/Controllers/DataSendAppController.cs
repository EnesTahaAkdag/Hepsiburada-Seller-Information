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

        public ActionResult MarketPlaceData(int? page, int? pageSize)
        {
            try
            {
                int totalCount = db.Seller_Information.Count();
                int currentPage = page ?? 1;
                pageSize = pageSize ?? 240;
                int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize.GetValueOrDefault());

                var data = (from c in db.Seller_Information
                            orderby c.ID
                            select new SellerInformationViewModel
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
                            })
                            .Skip((currentPage - 1) * pageSize.GetValueOrDefault())
                            .Take(pageSize.GetValueOrDefault())
                            .ToList();

                return Json(new ApiResponse
                {
                    Success = true,
                    ErrorMessage = null,
                    Data = data,
                    Page = currentPage,
                    PageSize = pageSize.GetValueOrDefault(),
                    TotalCount = totalCount,
                    TotalPage = totalPage
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}