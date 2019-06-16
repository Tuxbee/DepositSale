using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepositSale.Models;
using DepositSale.Binders;

namespace DepositSale
{
   public class BinderConfig
   {
      public static void RegisterBinders(ModelBinderDictionary Binders)
      {
         Binders.Add(typeof(Item), new ItemModelBinder());
      }
   }
}