using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepositSale.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepositSale.VM
{
   [NotMapped]
   public class ContactVM
   {
      public ContactVM()
      {
         EditedContact = new Contact();
         EditedContact.AssociatedCustomer = new Customer();
         EditedContact.AssociatedCustomer.AssociatedContact = EditedContact;
         EditedContact.AssociatedProvider = new Provider();
         EditedContact.AssociatedProvider.AssociatedContact = EditedContact;
      }

      public ContactVM(Contact Contact)
      {
         EditedContact = new Contact();
         EditedContact.AssociatedCustomer = new Customer();
         EditedContact.AssociatedCustomer.AssociatedContact = EditedContact;
         EditedContact.AssociatedProvider = new Provider();
         EditedContact.AssociatedProvider.AssociatedContact = EditedContact;

         UpdateFromModelContact(Contact);
      }

      public Contact EditedContact { get; set; }
      public bool IsCustomer { get; set; }
      public bool IsProvider { get; set; }

      public Contact GetModelContact()
      {
         Contact ModelContact = new Contact();
         DepositSale.Helper.Helper.CopyPropertiesTo(EditedContact, ModelContact);
         ModelContact.AssociatedCustomer = null;
         ModelContact.AssociatedProvider = null;

         if (IsCustomer)
         {
            ModelContact.AssociatedCustomer = new Customer();
            DepositSale.Helper.Helper.CopyPropertiesTo(EditedContact.AssociatedCustomer, ModelContact.AssociatedCustomer);
            ModelContact.AssociatedCustomer.AssociatedContact = ModelContact;
         }
         if (IsProvider)
         {
            ModelContact.AssociatedProvider = new Provider();
            DepositSale.Helper.Helper.CopyPropertiesTo(EditedContact.AssociatedProvider, ModelContact.AssociatedProvider);
            ModelContact.AssociatedProvider.AssociatedContact = ModelContact;
         }

         return ModelContact;
      }

      public void UpdateFromModelContact(Contact ModelContact)
      {
         Customer OldAssociatedCustomer = EditedContact.AssociatedCustomer;
         Provider OldAssociatedProvider = EditedContact.AssociatedProvider;

         DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact, EditedContact);
         EditedContact.AssociatedCustomer = OldAssociatedCustomer;
         EditedContact.AssociatedProvider = OldAssociatedProvider;

         IsCustomer = (ModelContact.AssociatedCustomer != null) ? true : false;
         if (IsCustomer)
         {
            DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact.AssociatedCustomer, EditedContact.AssociatedCustomer);
            EditedContact.AssociatedCustomer.AssociatedContact = EditedContact;
         }
         IsProvider = (ModelContact.AssociatedProvider != null) ? true : false;
         if (IsProvider)
         {
            DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact.AssociatedProvider, EditedContact.AssociatedProvider);
            EditedContact.AssociatedProvider.AssociatedContact = EditedContact;
         }
      }
   }
}