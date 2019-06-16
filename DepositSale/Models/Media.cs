using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepositSale.Models
{
   public class Media
   {
      public int ID { get; set; }
      public string MediaName { get; set; }
      public string MediaPath { get; set; }
      public string MediaDescription { get; set; }

      public virtual ICollection<Item> AssociatedItem { get; set; }
   }
}