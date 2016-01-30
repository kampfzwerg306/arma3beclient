using System.Web.Mvc;
using Arma3BE.Web.Core;

namespace Arma3BE.Web.Controllers
{
    public class ErrorController : BaseController 
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}