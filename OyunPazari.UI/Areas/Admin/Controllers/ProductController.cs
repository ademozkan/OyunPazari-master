using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using OyunPazari.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Admin.Controllers
{
    public class ProductController:BaseController
    {

        ProductService _productService;
        CategoryService _categoryService;

        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(_productService.GetActive());
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View(_categoryService.GetActive());
        }

        [HttpPost]
        public ActionResult Add(Product data , HttpPostedFileBase Image)
        {
            //Utility projesindeki ImageUploader Classına Bakınız.


            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            if (data.ImagePath=="0" || data.ImagePath=="1" || data.ImagePath=="2")
            {
                //Üstteki kodlardan biri geldiyse, hata alınmıştır, o durumda varsayılan bir foto yükleyelim.
                data.ImagePath = "/Uploads/gamer_logo.png";
            }





            data.CreatedBy = userID;
            _productService.Add(data);
            _productService.Save();



            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _productService.Remove(id,userID);
            _productService.Save();
            return RedirectToAction("List");

        }


        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List");

            Product guncellenecek = _productService.GetByID((Guid)id);

            ViewData["Categories"] = _categoryService.GetActive();

            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Product data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            Product guncellenecek = _productService.GetByID(data.ID);

            if (data.ImagePath!="0" && data.ImagePath!= "1" && data.ImagePath!="2")
            {
                //Hata alınmadıysa, kullanıcı yeni bir görsel eklemiştir.
                guncellenecek.ImagePath = data.ImagePath;
            }
            guncellenecek.ModifiedBy = userID;
            guncellenecek.Name = data.Name;
            guncellenecek.UnitPrice = data.UnitPrice;
            guncellenecek.UnitsInStock = data.UnitsInStock;
            guncellenecek.DisplayOnWeb = data.DisplayOnWeb;
            guncellenecek.DisplayOnMobile = data.DisplayOnMobile;
            guncellenecek.Features = data.Features;
            guncellenecek.CategoryID = data.CategoryID;

            _productService.Update(guncellenecek);
            _productService.Save();
            return RedirectToAction("List");

        }


    }
}