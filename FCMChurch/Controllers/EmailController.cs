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
    public class EmailController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /Email/
        public ActionResult Index()
        {
            var emails = db.Emails.Include(e => e.ContactType);
            return View(emails.ToList());
        }

        // GET: /Email/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // GET: /Email/Create
        public ActionResult Create()
        {
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type");
            return View();
        }

        // POST: /Email/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmailID,EmailAddress,ContactTypeID")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", email.ContactTypeID);
            return View(email);
        }

        // GET: /Email/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", email.ContactTypeID);
            return View(email);
        }

        // POST: /Email/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmailID,EmailAddress,ContactTypeID")] Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", email.ContactTypeID);
            return View(email);
        }

        // GET: /Email/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email email = db.Emails.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        // POST: /Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Email email = db.Emails.Find(id);
            db.Emails.Remove(email);
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
