using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternApp.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetailController
        public IActionResult Index(decimal total)
        {
            //factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            //products objeto que genera esta fabricada
            var localEarn = localEarnFactory.GetEarn();
            var foreignEarn = foreignEarnFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }

    }
}
