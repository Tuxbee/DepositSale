using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepositSale.Models;

namespace DepositSale.Binders
{
   public class ItemModelBinder : DefaultModelBinder
   {
      protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
      {
         ItemType ItemType = GetValue<ItemType>(bindingContext, "ItemType");

         Type model = Item.SelectFor(ItemType);

         Item instance = (Item)base.CreateModel(controllerContext, bindingContext, model);

         bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => instance, model);

         return instance;
      }

      private T GetValue<T>(ModelBindingContext bindingContext, string key)
      {
         ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);

         bindingContext.ModelState.SetModelValue(key, valueResult);

         return (T)valueResult.ConvertTo(typeof(T));
      }
   }
}