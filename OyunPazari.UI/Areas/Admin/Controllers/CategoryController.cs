using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        CategoryService _categoryService = new CategoryService();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            //Burada isterseniz aynı isimde kategori var mı kontrol edebilirsiniz.
            data.CreatedBy = userID;
            _categoryService.Add(data);
            _categoryService.Save();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View(_categoryService.GetActive());
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id,userID);
            _categoryService.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(Guid id)
        {
            //Gelen id'ye sahip kategori kaydı yakalnır.
            Category guncellenecek = _categoryService.GetByID(id);
            //Ekrana aktarılır.
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult Update(Category data)
        {
            Category guncellenecek = _categoryService.GetByID(data.ID);
            guncellenecek.Name = data.Name;
            guncellenecek.Description = data.Description;
            guncellenecek.ModifiedBy = userID;
            _categoryService.Update(guncellenecek);
            _categoryService.Save();
            return RedirectToAction("List");
        }

    }
}