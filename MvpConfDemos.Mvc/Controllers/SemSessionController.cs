using System.Threading;
using System.Web.Mvc;

namespace MvpConfDemos.Mvc.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class SemSessionController : Controller
    {

        public ActionResult Index(int index)
        {
            Thread.Sleep(1000);
            return Content($"{index} - {Session["Session"]} - ");
        }
    }
}