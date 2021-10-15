using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ContectsController : Controller
    {
        private abcEntities3 db = new abcEntities3();

        // GET: Contects
        public ActionResult Index()
        {
            var contects = db.Contects.Include(c => c.Admin);
            return View(contects.ToList());
        }

        // GET: Contects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contect contect = db.Contects.Find(id);
            if (contect == null)
            {
                return HttpNotFound();
            }
            return View(contect);
        }

        // GET: Contects/Create
        public ActionResult Create()
        {
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_Id", "Name");
            return View();
        }

        // POST: Contects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Contact,Email,Admin_id")] Contect contect)
        {
            if (ModelState.IsValid)
            {
                db.Contects.Add(contect);
                db.SaveChanges();
                //return RedirectToAction("Second");
            }

            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_Id", "Name", contect.Admin_id);
            return View(contect);
        }

        /*public ActionResult Second()
        {
            return View();
        }*/

        // GET: Contects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contect contect = db.Contects.Find(id);
            if (contect == null)
            {
                return HttpNotFound();
            }
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_Id", "Name", contect.Admin_id);
            return View(contect);
        }

        // POST: Contects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Contact,Email,Admin_id")] Contect contect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin_id = new SelectList(db.Admins, "Admin_Id", "Name", contect.Admin_id);
            return View(contect);
        }

        // GET: Contects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contect contect = db.Contects.Find(id);
            if (contect == null)
            {
                return HttpNotFound();
            }
            return View(contect);
        }

        // POST: Contects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contect contect = db.Contects.Find(id);
            db.Contects.Remove(contect);
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
