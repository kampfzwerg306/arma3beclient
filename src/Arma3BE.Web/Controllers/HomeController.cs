using System.Web.Mvc;
using Arma3BE.Web.Core;
using Arma3BE.Web.Models;

namespace Arma3BE.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILog _log;

        public HomeController(ILog log)
        {
            _log = log;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            _log.Info(string.Format("{0} call {1}", User.Identity.Name, "Index"));

            var model = new HomeModel();
            return View(model);
        }
    }
}
