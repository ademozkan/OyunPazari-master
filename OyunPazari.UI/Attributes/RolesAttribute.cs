using OyunPazari.Model.Entities;
using OyunPazari.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyunPazari.UI.Attributes
{
    public class RolesAttribute : AuthorizeAttribute
    {
        Role[] _roles;
        AppUserService _appUserService;
        public RolesAttribute(params Role[] roles)
        {
            _appUserService = new AppUserService();
            _roles = new Role[roles.Length];
            Array.Copy(roles, _roles, roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Forms authentication anında olutuştuurlan seansta kulannıcının usernameini saklamıştık. Bunun kontorlü için account controller içerisine bakabilirsiniz. FormsAuth ile kullanıcı giriş yaptığında httpcontext sınıfından o kullanıcı ile ilgili saklanan bilgiye erişebiliriz.

            string userName = HttpContext.Current.User.Identity.Name;

            //Kullanıcının adının boş gelmediğinden emin oluyoruz.

            if (!string.IsNullOrWhiteSpace(userName))
            {
                //Kullanıcının username sütunu eşsiz olmalıdır. Yoksa email gibi bir sütunu tutabilirsiniz.

                //Kullanıcı adı eşleşen user nesnes, yakalanır.
                AppUser currentUser = _appUserService.GetByDefault(user => user.UserName == userName);

                foreach (Role nextRole in _roles)
                {
                    if (currentUser.Role == nextRole)
                    {
                        return true;
                    }
                }

                return false;
            }
            //İstersek, Error controller açar ve unauthorized sayfasını hazırlarız.
            HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
            return false;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/Unauthorized");
        }

    }
}