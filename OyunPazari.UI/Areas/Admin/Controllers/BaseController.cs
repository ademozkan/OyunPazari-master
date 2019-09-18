using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using OyunPazari.UI.Attributes;
using System;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Admin.Controllers
{
    [Roles(Role.Admin)]
    public class BaseController : Controller
    {
        protected AppUserService _appUserService = new AppUserService();

        protected Guid userID { get { return _appUserService.GetIDByUserName(HttpContext.User.Identity.Name); } }

    }
}