using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.Models
{
   public enum ItemType
   {
      Other = 0,
      Garment
   }

   public abstract class Item
   {
      [NotMapped]
      public ItemType ItemType { get; set; }

      public int ID { get; set; }
      public string Description { get; set; }
      public decimal? CatalogPrice { get; set; }
      
      public virtual Media AssociatedMedia { get; set; }

      public virtual ItemSaleEvent AssociatedSoldItem { get; set; }
      public virtual ItemRefundEvent AssociatedRefundItem { get; set; }
      public virtual ItemDepositEvent AssociatedDepositItem { get; set; }
      public virtual ItemOffCallingEvent AssociatedOffCallingItem { get; set; }

      public static Type SelectFor(ItemType type)
      {
         switch (type)
         {
            case ItemType.Other:
               return typeof(Other);
            case ItemType.Garment:
               return typeof(Garment);
            default:
               throw new Exception();
         }
      }
   }

   [Table("Garment")]
   public class Garment : Item
   {
      public Garment()
      {
         ItemType = ItemType.Garment;
      }

      public string ColorName { get; set; }
      public int ColorHexa { get; set; }
      public string Size { get; set; }
   }

   [Table("Other")]
   public class Other : Item
   {
      public Other()
      {
         ItemType = ItemType.Other;
      }
   }
}