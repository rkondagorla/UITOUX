using Microsoft.AspNetCore.Mvc;

namespace UITOUX.Web.UI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult InvestorRelations()
        {
            return View();
        }
        public IActionResult SellersRelations()
        {
            return View();
        }
        public IActionResult ReturnPolicy()
        {
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult Disclaimer()
        {
            return View();
        }
        public IActionResult TermsOfUse()
        {
            return View();
        }
        public IActionResult BuyerTermsAndConditions()
        {
            return View();
        }
        public IActionResult SellerTermsAndConditions()
        {
            return View();
        }
    }
}
