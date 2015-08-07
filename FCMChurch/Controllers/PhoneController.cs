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
    public class PhoneController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /Phone/
        public ActionResult Index()
        {
            var phones = db.Phones.Include(p => p.ContactType);
            return View(phones.ToList());
        }

        // GET: /Phone/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // GET: /Phone/Create
        public ActionResult Create()
        {
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type");
            return View();
        }

        // POST: /Phone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PhoneID,AreaCode,Number,ContactTypeID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", phone.ContactTypeID);
            return View(phone);
        }

        // GET: /Phone/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", phone.ContactTypeID);
            return View(phone);
        }

        // POST: /Phone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PhoneID,AreaCode,Number,ContactTypeID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactTypeID = new SelectList(db.ContactTypes, "ContactTypeID", "Type", phone.ContactTypeID);
            return View(phone);
        }

        // GET: /Phone/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: /Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Phone phone = db.Phones.Find(id);
            db.Phones.Remove(phone);
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
