using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using OyunPazari.Service.TransferObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OyunPazari.UI.Controllers
{


    public class AccountController : Controller
    {
        AppUserService _appUserService = new AppUserService();



        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            //Eğer kullanıcı zaten giriş yaptıysa, direk üye sayfasına yünlendir vb yapıları kullanabilirsiniz.

            //LoginVM içerisinde yazılan required benzeri kuralları kontrol etme işlemi.
            if (ModelState.IsValid)
            {
                //username ve passswordu eşleşen kişiyi buluyoruz.
                AppUser currentUser = _appUserService.GetByDefault(user => user.UserName == data.UserName && user.Password == data.Password);

                //Bu kişinin bulunup bulunmadığına bakıyoruz.
                if (currentUser!=null)
                {
                    //Forms Authentication için Web.Config dosyasına bakmayı unutmayınız
                    //Bu kişi için bir session yani seans oluşturuyoruz.
                    //True yapılırsa, cookie olarak açılır ve tarayıcı kapansa da saklanmaya devam eder, false yapılırsa session yani seans olarak açılır ve tarayıcı kapatıldığında kullanıcı bilgileri kaybolur.
                    //Session ve cookie arasındaki farka bakınız.

                    FormsAuthentication.SetAuthCookie(currentUser.UserName, true);

                    //Eğer rolü admin ise admin area içerisine yönlendiriyoruz.
                    if (currentUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                    //Eğer admin değilse, geldiği sayfaya döner.
                    return Redirect(Request.UrlReferrer.ToString());
                }

            }

            //İstersek, yeni kullanıcı sayfasına da yönlendirebiliriz.
            return RedirectToAction("Signup");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("sepet");
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AppUser data)
        {

            if (_appUserService.GetByDefault(x=>x.UserName==data.UserName) != null)
            {
                //return RedirectToAction("Index", "Home");
                ViewBag.Message = "Bu Kullanıcı Adı Alınmıştır!";
                return View();
            }

            //Image isterseniz product örneğindeki gibi yapabilirsiniz.
            data.Role = Role.Member;
            _appUserService.Add(data);
            _appUserService.Save();

            return RedirectToAction("Index","Home");
        }

    }
}