using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductService _pService = new ProductService();

        //Kategori id'sine göre ürünleri döndürür.
        public ActionResult List(Guid? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            return View(_pService.GetProductsByCategoryID((Guid)id));
        }

        public ActionResult Detail(Guid? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");

            return View(_pService.GetProductByID((Guid)id));
        }
    }
}