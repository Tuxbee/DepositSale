using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepositSale.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }

      public ActionResult Stock()
      {
         ViewBag.Message = "Your Stock page.";

         return View();
      }

      public ActionResult Deposit()
      {
         ViewBag.Message = "Your Deposit page.";

         return View();
      }

      public ActionResult OffCalling()
      {
         ViewBag.Message = "Your OffCalling page.";

         return View();
      }

      public ActionResult Sale()
      {
         ViewBag.Message = "Your Sale page.";

         return View();
      }

      public ActionResult Refund()
      {
         ViewBag.Message = "Your Refund page.";

         return View();
      }
   }
}