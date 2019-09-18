using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Member.Controllers
{
    public class PageController : Controller
    {
        public ActionResult ShoppingCart()
        {
            return PartialView("_shoppingCart");
        }
    }
}