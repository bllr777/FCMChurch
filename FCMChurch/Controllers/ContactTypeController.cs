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
    public class ContactTypeController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /ContactType/
        public ActionResult Index()
        {
            return View(db.ContactTypes.ToList());
        }

        // GET: /ContactType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = db.ContactTypes.Find(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        // GET: /ContactType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ContactTypeID,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                db.ContactTypes.Add(contacttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacttype);
        }

        // GET: /ContactType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = db.ContactTypes.Find(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        // POST: /ContactType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ContactTypeID,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacttype);
        }

        // GET: /ContactType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = db.ContactTypes.Find(id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        // POST: /ContactType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ContactType contacttype = db.ContactTypes.Find(id);
            db.ContactTypes.Remove(contacttype);
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
