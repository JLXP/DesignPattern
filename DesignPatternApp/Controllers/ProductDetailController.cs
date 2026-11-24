using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesignPatternApp.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _localEarnFactory;
        private ForeignEarnFactory _foreignEarnFactory;

        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }
        // GET: ProductDetailController
        public IActionResult Index(decimal total)
        {
            //factories
            //LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            //ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.30m, 20);

            //products objeto que genera esta fabricada
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = _foreignEarnFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);

            return View();
        }

    }
}
