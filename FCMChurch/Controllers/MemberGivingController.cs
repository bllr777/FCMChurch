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
    public class MemberGivingController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /MemberGiving/
        public ActionResult Index()
        {
            var membergivings = db.MemberGivings.Include(m => m.Member);
            return View(membergivings.ToList());
        }

        // GET: /MemberGiving/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberGiving membergiving = db.MemberGivings.Find(id);
            if (membergiving == null)
            {
                return HttpNotFound();
            }
            return View(membergiving);
        }

        // GET: /MemberGiving/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName");
            return View();
        }

        // POST: /MemberGiving/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MemberGivingID,MemberID,Tithes,Offering,Date")] MemberGiving membergiving)
        {
            if (ModelState.IsValid)
            {
                db.MemberGivings.Add(membergiving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", membergiving.MemberID);
            return View(membergiving);
        }

        // GET: /MemberGiving/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberGiving membergiving = db.MemberGivings.Find(id);
            if (membergiving == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", membergiving.MemberID);
            return View(membergiving);
        }

        // POST: /MemberGiving/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MemberGivingID,MemberID,Tithes,Offering,Date")] MemberGiving membergiving)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membergiving).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "FirstName", membergiving.MemberID);
            return View(membergiving);
        }

        // GET: /MemberGiving/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberGiving membergiving = db.MemberGivings.Find(id);
            if (membergiving == null)
            {
                return HttpNotFound();
            }
            return View(membergiving);
        }

        // POST: /MemberGiving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MemberGiving membergiving = db.MemberGivings.Find(id);
            db.MemberGivings.Remove(membergiving);
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
