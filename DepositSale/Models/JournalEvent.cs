using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.Models
{
   public enum TransactionType
   {
      BankTransfer=0,
      Cash
   }

   public abstract class JournalEvent
   {
      public int ID { get; set; }
      public DateTime EventDate { get; set; }
   }

   [Table("SaleEvent")]
   public class SaleEvent : JournalEvent
   {
      public TransactionType TransactionType_e { get; set; }
      public virtual Customer AssociatedCustomer { get; set; }
      public virtual ICollection<ItemSaleEvent> SoldItems { get; set; }
   }

   [Table("RefundEvent")]
   public class RefundEvent : JournalEvent
   {
      public TransactionType TransactionType_e { get; set; }
      public virtual Provider AssociatedProvider { get; set; }
      public virtual ICollection<ItemRefundEvent> RefundItems { get; set; }
   }

   [Table("StockEvent")]
   public class StockEvent : JournalEvent
   {
      public virtual Provider AssociatedProvider { get; set; }
      public virtual ICollection<ItemDepositEvent> DepositItems { get; set; }
      public virtual ICollection<ItemOffCallingEvent> OffCallingItems { get; set; }
   }
}