using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System;
using Tools.Earn;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
