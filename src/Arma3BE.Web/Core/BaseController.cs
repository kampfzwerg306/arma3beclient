using System.Web.Mvc;

namespace Arma3BE.Web.Core
{
    [LoggingFilter]
    [Authorize]
    public abstract class BaseController : Controller
    {
         
    }
}