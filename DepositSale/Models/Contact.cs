using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.Models
{
   public class Contact
   {
      public int ID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime RegisterDate { get; set; }
      public string Street { get; set; }
      public string PostCode { get; set; }
      public string City { get; set; }
      public string CountryCode { get; set; }
      public string EmailAddress { get; set; }
      public string PhoneNumber { get; set; }

      public virtual Provider AssociatedProvider { get; set; }
      public virtual Customer AssociatedCustomer { get; set; }
   }
}