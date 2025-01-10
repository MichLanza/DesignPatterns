using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace MVC.DesignPatterns.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //Factories
            LocalEarnFactory localEarnFactory = new LocalEarnFactory(0.20m);
            ForeignEarnFactory foreignEarnFactory = new ForeignEarnFactory(0.20m,0.1m);

            //Products 
            var localEarn = localEarnFactory.CreateEarn();
            var foreign = foreignEarnFactory.CreateEarn();

            ViewBag.Total = total + localEarn.Earn(total);  
            ViewBag.TotalForeign = total + foreign.Earn(total);

            return View();
        }
    }
}
