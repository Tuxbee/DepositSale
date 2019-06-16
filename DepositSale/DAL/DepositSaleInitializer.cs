using System;
using System.Collections.Generic;
using System.Data.Entity;
using DepositSale.Models;

namespace DepositSale.DAL
{
   public class DepositSaleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DepositSaleContext>
   {
      protected override void Seed(DepositSaleContext context)
      {
         // Add the anonymous contact
         var contact = new Contact() { FirstName = "Anonymous", LastName = "Anonymous", RegisterDate = DateTime.Now, Street = "Anonymous", PostCode = "0000", City = "Anonymous", CountryCode = "BE", EmailAddress = "Anonymous@Anonymous.be", PhoneNumber = "+3200000000" };
         var provider = new Provider();
         provider.IBANAccount = "BE68539007547034";
         provider.AssociatedContact = contact;
         var customer = new Customer();
         customer.AssociatedContact = contact;

         context.Customers.Add(customer);
         context.Providers.Add(provider);
         context.SaveChanges();
      }
   }
}