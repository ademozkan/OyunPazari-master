using OyunPazari.Model.Entities;
using OyunPazari.UI.Attributes;
using System.Web.Mvc;

namespace OyunPazari.UI.Areas.Member.Controllers
{
    [Roles(Role.Admin,Role.Member)]
    public class BaseController : Controller
    {
      
    }
}