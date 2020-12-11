using System.Threading;
using System.Web.Mvc;

namespace MvpConfDemos.Mvc.Controllers
{
    public class ComSessionController : Controller
    {
        public ActionResult Index(int index)
        {
            Thread.Sleep(1000);
            return Content($"{index} - {Session["Session"]} - ");
        }
    }
}