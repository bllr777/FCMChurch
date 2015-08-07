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
    public class MemberTypeController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /MemberType/
        public ActionResult Index()
        {
            return View(db.MemberTypes.ToList());
        }

        // GET: /MemberType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberType membertype = db.MemberTypes.Find(id);
            if (membertype == null)
            {
                return HttpNotFound();
            }
            return View(membertype);
        }

        // GET: /MemberType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MemberType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MemberTypeID,Type")] MemberType membertype)
        {
            if (ModelState.IsValid)
            {
                db.MemberTypes.Add(membertype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membertype);
        }

        // GET: /MemberType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberType membertype = db.MemberTypes.Find(id);
            if (membertype == null)
            {
                return HttpNotFound();
            }
            return View(membertype);
        }

        // POST: /MemberType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MemberTypeID,Type")] MemberType membertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membertype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membertype);
        }

        // GET: /MemberType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberType membertype = db.MemberTypes.Find(id);
            if (membertype == null)
            {
                return HttpNotFound();
            }
            return View(membertype);
        }

        // POST: /MemberType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MemberType membertype = db.MemberTypes.Find(id);
            db.MemberTypes.Remove(membertype);
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
