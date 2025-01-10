using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace MVC.DesignPatterns.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _localEarnFactory;
        private EarnFactory _foreignEarnFactory;

        public ProductDetailController(LocalEarnFactory localEarnFactory, EarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }

        public IActionResult Index(decimal total)
        {

            //Products 
            var localEarn = _localEarnFactory.CreateEarn();
            var foreign = _foreignEarnFactory.CreateEarn();

            ViewBag.Total = total + localEarn.Earn(total);  
            ViewBag.TotalForeign = total + foreign.Earn(total);

            return View();
        }
    }
}
