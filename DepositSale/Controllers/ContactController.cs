using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepositSale.DAL;
using DepositSale.Models;
using DepositSale.VM;

namespace DepositSale.Controllers
{
    public class ContactController : Controller
    {
        private DepositSaleContext db = new DepositSaleContext();

        // GET: Contact
        public ActionResult Index()
        {
            var contacts = db.Contacts;
            return View(contacts.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ContactVM contactVM = new ContactVM(contact);
            return View(contactVM);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactVM contact)
        {
            if (ModelState.IsValid)
            {
                Contact ModelContact = contact.GetModelContact();
                db.Contacts.Add(ModelContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ContactVM contactVM = new ContactVM(contact);
            return View(contactVM);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactVM contact)
        {
            if (ModelState.IsValid)
            {  
               Contact ModelContact = contact.GetModelContact();
               Contact DBContact = db.Contacts.Find(ModelContact.ID);

               if (ModelContact.AssociatedCustomer == null)
               {
                  if (DBContact.AssociatedCustomer != null)
                     db.Customers.Remove(DBContact.AssociatedCustomer);
               }
               else
               {
                  if (DBContact.AssociatedCustomer == null)
                  {
                     DBContact.AssociatedCustomer = new Customer();
                     DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact.AssociatedCustomer, DBContact.AssociatedCustomer);
                     DBContact.AssociatedCustomer.AssociatedContact = DBContact;
                     DBContact.AssociatedCustomer.ContactId = 0;
                  }
                  else
                  {
                     // Update customer specific information
                  }
               }

               if (ModelContact.AssociatedProvider == null)
               { 
                  if (DBContact.AssociatedProvider != null)
                     db.Providers.Remove(DBContact.AssociatedProvider);
               }
               else
               {
                  if (DBContact.AssociatedProvider == null)
                  {
                     DBContact.AssociatedProvider = new Provider();
                     DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact.AssociatedProvider, DBContact.AssociatedProvider);
                     DBContact.AssociatedProvider.AssociatedContact = DBContact;
                     DBContact.AssociatedProvider.ContactId = 0;
                  }
                  else
                  {
                     // Update Provider specific information
                     DBContact.AssociatedProvider.IBANAccount = ModelContact.AssociatedProvider.IBANAccount;
                     db.Entry(DBContact.AssociatedProvider).State = EntityState.Modified;
                  }
               }

               {
                  // Update Contact specific information
                  Customer OldCustomer = DBContact.AssociatedCustomer;
                  Provider OldProvider = DBContact.AssociatedProvider;
                  DepositSale.Helper.Helper.CopyPropertiesTo(ModelContact, DBContact);
                  DBContact.AssociatedCustomer = OldCustomer;
                  DBContact.AssociatedProvider = OldProvider;
            }

                db.Entry(DBContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact.AssociatedCustomer != null)
               db.Customers.Remove(contact.AssociatedCustomer);
            if (contact.AssociatedProvider != null)
               db.Providers.Remove(contact.AssociatedProvider);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
