using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using OyunPazari.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Member.Controllers
{
    public class OrderController : BaseController
    {
        OrderService _orderService;
        AppUserService _appUserService;

        public OrderController()
        {
            _orderService = new OrderService();
            _appUserService = new AppUserService();
        }

        public RedirectToRouteResult Create()
        {
            //Sepet boşsa alttaki işlemleri yapmaya gerek yok.
            if (Session["sepet"] == null)
            {
                return RedirectToAction("Index","Home",new{area=""});
            }

            //Sepeti yakalama
            Cart cart = Session["sepet"] as Cart;

            //Eğer sepetteki ürün sayısı 0 ise 
            if (cart.MyCart.Count<=0)
            {
                TempData["message"] = "Sepet Boş Olamaz!";
                return RedirectToAction("Index","Cart");
            }

            //Yeni sipariş oluşturuyoruz.
            Order newOrder = new Order();

            //Siparişi veren kullanıcı yakalıyoruz.
            AppUser currentUser = _appUserService.GetuserByUserName(HttpContext.User.Identity.Name);

            //Siparişe kullanıcıyı atıyoruz
            newOrder.AppUserID = currentUser.ID;

            decimal totalPrice = 0;

            foreach (var item in cart.MyCart)
            {
                totalPrice += item.Quantity * item.UnitPrice;

                newOrder.OrderDetails.Add(new OrderDetail {
                    ProductID = item.ID,
                    Quantity=item.Quantity,
                    UnitPrice=item.UnitPrice
                });
            }

            newOrder.OrderStatus = OrderStatus.Ordered;
            newOrder.OrderDate = DateTime.Now;
            newOrder.TotalPrice = totalPrice;
            _orderService.Add(newOrder);
            _orderService.Save();
            Session.Remove("sepet");
            return RedirectToAction("Index","Home",new { area=""});


            
        }
    }
}