using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Controllers
{
    public class PageController : Controller
    {
        public PartialViewResult MainMenu()
        {
            CategoryService _categoryService = new CategoryService();

            return PartialView("_mainMenu",_categoryService.GetActive());
        }
    }
}