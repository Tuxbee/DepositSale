using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.Models
{
   public class Provider
   {
      [Key, ForeignKey("AssociatedContact")]
      public int ContactId { get; set; }
      public virtual Contact AssociatedContact { get; set; }

      public string IBANAccount { get; set; }

      public virtual ICollection<RefundEvent> AssociatedRefundEvent { get; set; }
      public virtual ICollection<StockEvent> AssociatedStockEvent { get; set; }
   }

   public class Customer
   {
      [Key, ForeignKey("AssociatedContact")]
      public int ContactId { get; set; }
      public virtual Contact AssociatedContact { get; set; }
      public virtual ICollection<SaleEvent> AssociatedSaleEvent { get; set; }
   }
}