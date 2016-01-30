using System.Linq;
using System.Web.Mvc;
using Arma3BE.Web.Models;

namespace Arma3BE.Web.Controllers
{
    public class ServerController : Controller
    {
        //
        // GET: /Server/

        public ActionResult Index()
        {
            var model = new ServerModel();
            model.Players = MvcApplication.StateServer.Players.ToList();
            return View(model);
        }
    }
}