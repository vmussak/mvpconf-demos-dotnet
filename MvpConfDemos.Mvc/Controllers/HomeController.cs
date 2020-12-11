using System.Web.Mvc;

namespace MvpConfDemos.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Session"] = "123";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}