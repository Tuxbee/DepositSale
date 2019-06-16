using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.Models
{
   public abstract class ItemEvent
   {
      [Key, ForeignKey("AssociatedItem")]
      public int ItemId { get; set; }
      public virtual Item AssociatedItem { get; set; }
   }

   public class ItemSaleEvent : ItemEvent
   {
      [ForeignKey("AssociatedSaleEvent")]
      public int SaleEventId { get; set; }
      public virtual SaleEvent AssociatedSaleEvent { get; set; }

      public decimal SoldPrice { get; set; }
   }

   public class ItemRefundEvent : ItemEvent
   {
      [ForeignKey("AssociatedRefundEvent")]
      public int RefundEventId { get; set; }
      public virtual RefundEvent AssociatedRefundEvent { get; set; }

      public decimal RefundPrice { get; set; }
   }

   public class ItemStockEvent : ItemEvent
   {
      [ForeignKey("AssociatedStockEvent")]
      public int StockEventId { get; set; }
      public virtual StockEvent AssociatedStockEvent { get; set; }
   }

   public class ItemDepositEvent : ItemStockEvent
   {
   }

   public class ItemOffCallingEvent : ItemStockEvent
   {
   }
}