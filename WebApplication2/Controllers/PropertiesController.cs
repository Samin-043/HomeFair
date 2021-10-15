using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PropertiesController : Controller
    {
        

        private abcEntities3 db = new abcEntities3();


        // GET: Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        // GET: Properties/Details
        public ActionResult Details()
        {

            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            var id = 1000;
            foreach (var item in id)
            {
                Property property = db.Properties.Find(id);
                if (property == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(property);
                }
            }
            return View();*/
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.Agent_id = new SelectList(db.Agents, "Agent_Id", "AgentName");
            ViewBag.PropertyType_Id = new SelectList(db.PropertyTypes, "PropertyType_Id", "PropertyTypeName");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public ActionResult Create([Bind(Include = "Property_Id,PropertyName,Price,PropertySize,Purpose,Description,FloorNo,BedRoom,DiningSpace,LivingRoom,Balconies,AttachedBath,CommonBath,PropertyType_Id,Agent_id,City,Area,Status")] Property property, HttpPostedFileBase ImageFile, HttpPostedFileBase ImageFile1, HttpPostedFileBase ImageFile2, HttpPostedFileBase ImageFile3)
        {
            /*HttpPostedFileBase ImageFile1, HttpPostedFileBase ImageFile2, HttpPostedFileBase ImageFile3*/

            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                property.PropertyImage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                ImageFile.SaveAs(fileName);

                string fileName1 = Path.GetFileNameWithoutExtension(ImageFile1.FileName);
                string extension1 = Path.GetExtension(ImageFile1.FileName);
                fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                property.FirstImage = "~/Image/" + fileName1;
                fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
                ImageFile1.SaveAs(fileName1);

                string fileName2 = Path.GetFileNameWithoutExtension(ImageFile2.FileName);
                string extension2 = Path.GetExtension(ImageFile2.FileName);
                fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                property.SecondImage = "~/Image/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/Image/"), fileName2);
                ImageFile2.SaveAs(fileName2);

                string fileName3 = Path.GetFileNameWithoutExtension(ImageFile3.FileName);
                string extension3 = Path.GetExtension(ImageFile3.FileName);
                fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                property.ThirdImage = "~/Image/" + fileName3;
                fileName3 = Path.Combine(Server.MapPath("~/Image/"), fileName3);
                ImageFile3.SaveAs(fileName3);

                db.Properties.Add(property);
                db.SaveChanges();
            }

            ViewBag.Agent_id = new SelectList(db.Agents, "Agent_Id", "AgentName", property.Agent_id);
            ViewBag.PropertyType_Id = new SelectList(db.PropertyTypes, "PropertyType_Id", "PropertyTypeName", property.PropertyType_Id);
            return View(property);

            /*if (ModelState.IsValid)
            {
                //property.PropertyImage = new string[ImageFile.ContentLength];
               

                /*string fileName1 = Path.GetFileNameWithoutExtension(ImageFile1.FileName);
                string extension1 = Path.GetExtension(ImageFile1.FileName);
                fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
                property.FirstImage = "~/Image/" + fileName1;
                fileName1 = Path.Combine(Server.MapPath("~/Image/"), fileName1);
                ImageFile1.SaveAs(fileName1);

                string fileName2 = Path.GetFileNameWithoutExtension(ImageFile2.FileName);
                string extension2 = Path.GetExtension(ImageFile2.FileName);
                fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                property.SecondImage = "~/Image/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/Image/"), fileName2);
                ImageFile2.SaveAs(fileName2);

                string fileName3 = Path.GetFileNameWithoutExtension(ImageFile3.FileName);
                string extension3 = Path.GetExtension(ImageFile3.FileName);
                fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                property.ThirdImage = "~/Image/" + fileName3;
                fileName3 = Path.Combine(Server.MapPath("~/Image/"), fileName3);
                ImageFile3.SaveAs(fileName3);

                db.Properties.Add(property);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }*/


        }



        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agent_id = new SelectList(db.Agents, "Agent_Id", "AgentName", property.Agent_id);
            ViewBag.PropertyType_Id = new SelectList(db.PropertyTypes, "PropertyType_Id", "PropertyTypeName", property.PropertyType_Id);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Property_Id,PropertyName,Price,PropertySize,Purpose,Description,FloorNo,BedRoom,DiningSpace,LivingRoom,Balconies,AttachedBath,CommonBath,PropertyType_Id,Agent_id,City,Area,Status")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.Agent_id = new SelectList(db.Agents, "Agent_Id", "AgentName", property.Agent_id);
            ViewBag.PropertyType_Id = new SelectList(db.PropertyTypes, "PropertyType_Id", "PropertyTypeName", property.PropertyType_Id);
            return View(property);
        }

        
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        public ActionResult Rent()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult Sale()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult Apartment()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult Commercial()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult New()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult Used()
        {
            var properties = db.Properties.Include(p => p.Agent).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        // POST: Properties/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            //return RedirectToAction("index");
            return View(property);
        }*/

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
