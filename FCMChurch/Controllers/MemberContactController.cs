using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FCMChurch.Models;

namespace FCMChurch.Controllers
{
    public class MemberContactController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /MemberContact/
        public ActionResult Index()
        {
            var membercontacts = db.MemberContacts.Include(m => m.Address).Include(m => m.Email).Include(m => m.Member).Include(m => m.Phone).Include(m => m.StateName);
            return View(membercontacts.ToList());
        }

        // GET: /MemberContact/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberContact membercontact = db.MemberContacts.Find(id);
            if (membercontact == null)
            {
                return HttpNotFound();
            }
            return View(membercontact);
        }

        // GET: /MemberContact/Create
        public ActionResult Create()

        {
            
           

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Address1");
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName");
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number");
            ViewBag.StateNameID = new SelectList(db.StateNames, "StateNameID", "State");
            return View();
        }

        // POST: /MemberContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MemberContactID,MemberID,EmailID,PhoneID,AddressID,StateNameID")] MemberContact membercontact)
        {
            if (ModelState.IsValid)
            {
                db.MemberContacts.Add(membercontact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Address1", membercontact.AddressID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", membercontact.EmailID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName LastName", membercontact.MemberID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", membercontact.PhoneID);
            ViewBag.StateNameID = new SelectList(db.StateNames, "StateNameID", "State", membercontact.StateNameID);
            return View(membercontact);
        }

        // GET: /MemberContact/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberContact membercontact = db.MemberContacts.Find(id);
            if (membercontact == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Address1", membercontact.AddressID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", membercontact.EmailID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName LastName", membercontact.MemberID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", membercontact.PhoneID);
            ViewBag.StateNameID = new SelectList(db.StateNames, "StateNameID", "State", membercontact.StateNameID);
            return View(membercontact);
        }

        // POST: /MemberContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MemberContactID,MemberID,EmailID,PhoneID,AddressID,StateNameID")] MemberContact membercontact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membercontact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "Address1", membercontact.AddressID);
            ViewBag.EmailID = new SelectList(db.Emails, "EmailID", "EmailAddress", membercontact.EmailID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName LastName", membercontact.MemberID);
            ViewBag.PhoneID = new SelectList(db.Phones, "PhoneID", "Number", membercontact.PhoneID);
            ViewBag.StateNameID = new SelectList(db.StateNames, "StateNameID", "State", membercontact.StateNameID);
            return View(membercontact);
        }

        // GET: /MemberContact/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberContact membercontact = db.MemberContacts.Find(id);
            if (membercontact == null)
            {
                return HttpNotFound();
            }
            return View(membercontact);
        }

        // POST: /MemberContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MemberContact membercontact = db.MemberContacts.Find(id);
            db.MemberContacts.Remove(membercontact);
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
