using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductService _pService = new ProductService();


            return View(_pService.GetLatestProducts(3));
        }
    }
}