using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using OyunPazari.Service.TransferObjects.DataTransferObjects;
using OyunPazari.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Member.Controllers
{

    public class CartController : BaseController
    {
        ProductService _productService;
        AppUserService _appUserService;
        public CartController()
        {
            _appUserService = new AppUserService();
            _productService = new ProductService();
        }

        public JsonResult List()
        {
            //Sepet var mı ? 
            //Sepet session içerisinde saklanacak yani sepet tarayıcı kapandığında yok olacak.
            if (Session["sepet"]!=null)
            {
                Cart cart = Session["sepet"] as Cart;
                return Json(cart.MyCart, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty",JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Guid id)
        {
            //Gelen idye ait ürünü yakalamalıyız.
            Product sepeteEklenecekUrun = _productService.GetByID(id);

            //Sonrasında bu ürün içerisinden gerekli özellikleri alıp, sepet elemanına çevirmeliyiz.
            CartItem sepetElemani = new CartItem();
            sepetElemani.ID = sepeteEklenecekUrun.ID;
            sepetElemani.ProductName = sepeteEklenecekUrun.Name;
            sepetElemani.UnitPrice = sepeteEklenecekUrun.UnitPrice;
            sepetElemani.ImagePath = sepeteEklenecekUrun.ImagePath;
            sepetElemani.Quantity = 1; //Metot her çağırılışında bir adet ekleyeceğiz.

            Cart cart;


            //Daha önceden bir sepet var mı onu kontrol ediyoruz. Yoksa sepet oluşturulacak.
            if (Session["sepet"] != null)
            {
                //Session içerisinde sepet varsa, object tipinde gelecektir. O nesneyi cast ederek almalı ve yeni(veya miktarı arttırılacak) ürünü sepete eklemeliyiz.
                cart = Session["sepet"] as Cart;
                cart.AddItem(sepetElemani);
                //Son olarak , sepetin son halini tekrar aynı session içerisine atmalıyız.
                Session["sepet"] = cart;
            }
            else
            {
                //Session'da sepet yoksa, yeni bir session oluştur.
                cart = new Cart();
                cart.AddItem(sepetElemani);
                Session.Add("sepet", cart);
            }

            return Json(cart.MyCart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CartItemCount()
        {
            if (Session["sepet"]!=null)
            {
                Cart cart = Session["sepet"] as Cart;
                return Json(cart.MyCart.Count,JsonRequestBehavior.AllowGet);
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }
        
        public ViewResult Index()
        {
            ViewBag.User = _appUserService.GetuserByUserName(HttpContext.User.Identity.Name);
            return View();
        }
    }
}