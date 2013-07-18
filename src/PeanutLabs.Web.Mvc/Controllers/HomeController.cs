using System.Web.Mvc;
using PeanutLabs.Configuration;
using PeanutLabs.Web.Mvc.Lib;

namespace PeanutLabs.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsAppSettings());
            ViewBag.IframeUrl = peanutLabsUrl.IframeUrl(publisherUserId: 1508);
            return View();
        }

        public ActionResult Callback()
        {
            var callback = new PeanutLabsCallbackSample(new PeanutLabsAppSettings());
            callback.Process(new RequestCallback("customParameter", "customParameter2"));
            return null;
        }
    }
}