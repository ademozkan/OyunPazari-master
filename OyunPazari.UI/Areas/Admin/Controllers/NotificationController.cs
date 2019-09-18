using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Admin.Controllers
{
    public class NotificationController : BaseController
    {

        public ActionResult OrderNotificationTOP()
        {
            OrderService _orderService = new OrderService();
            return PartialView("_OrderNotificationTOP" , _orderService.LastOrders(3));
        }
    }
}