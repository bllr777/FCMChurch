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
    public class StateController : Controller
    {
        private forchris_ChurchEntities db = new forchris_ChurchEntities();

        // GET: /State/
        public ActionResult Index()
        {
            return View(db.StateNames.ToList());
        }

        // GET: /State/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateName statename = db.StateNames.Find(id);
            if (statename == null)
            {
                return HttpNotFound();
            }
            return View(statename);
        }

        // GET: /State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StateNameID,State,StateAbbreviation")] StateName statename)
        {
            if (ModelState.IsValid)
            {
                db.StateNames.Add(statename);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statename);
        }

        // GET: /State/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateName statename = db.StateNames.Find(id);
            if (statename == null)
            {
                return HttpNotFound();
            }
            return View(statename);
        }

        // POST: /State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StateNameID,State,StateAbbreviation")] StateName statename)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statename).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statename);
        }

        // GET: /State/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StateName statename = db.StateNames.Find(id);
            if (statename == null)
            {
                return HttpNotFound();
            }
            return View(statename);
        }

        // POST: /State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StateName statename = db.StateNames.Find(id);
            db.StateNames.Remove(statename);
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
