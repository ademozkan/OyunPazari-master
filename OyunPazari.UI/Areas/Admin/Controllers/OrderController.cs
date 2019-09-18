using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        OrderService _orderService;
        OrderDetailService _orderDetailservice;
        ProductService _productService;


        public OrderController()
        {
            _orderService = new OrderService();
            _orderDetailservice = new OrderDetailService();
            _productService = new ProductService();
        }
        public ViewResult PendingList()
        {
            return View(_orderService.ListPendingOrders());
        }

        public ViewResult ListAll()
        {
            return View(_orderService.GetActive());
        }

        public ViewResult Detail(Guid id)
        {

            return View(_orderDetailservice.GetDefault(od=>od.OrderID==id));
        }

        public RedirectToRouteResult ConfirmOrder(Guid id)
        {
            //Sipariş yakalanır.
            Order order = _orderService.GetByID(id);

            //Stoktan Düşme İşlemi Her bir sipariş detayında gezilir ve içerisindeki ürün yakalanır. Sonrasında stoklardan siparişteki miktar kadar düşülür ve ürün güncellenir.

            foreach (var item in order.OrderDetails)
            {
                Product nextProduct = _productService.GetByID(item.ProductID);
                nextProduct.UnitsInStock -= item.Quantity;
                _productService.Update(nextProduct);
                _productService.Save();
            }
            order.ModifiedBy = userID;
            order.OrderStatus = OrderStatus.Completed;
            _orderService.Update(order);
            _orderService.Save();

            return RedirectToAction("ListAll");
        }

        public RedirectToRouteResult RejectOrder(Guid id)
        {
            Order order = _orderService.GetByID(id);
            order.ModifiedBy = userID;
            order.OrderStatus = OrderStatus.Declined;
            //_orderService.Remove(order);
            _orderService.Save();
            return RedirectToAction("ListAll");
        }
    }
}