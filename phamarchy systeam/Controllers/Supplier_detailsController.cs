using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using phamarchy_systeam.Models;

namespace phamarchy_systeam.Controllers
{
    public class Supplier_detailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Supplier_details
        public ActionResult Index()
        {
            return View(db.Supplier_details.ToList());
        }

        // GET: Supplier_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_details supplier_details = db.Supplier_details.Find(id);
            if (supplier_details == null)
            {
                return HttpNotFound();
            }
            return View(supplier_details);
        }

        // GET: Supplier_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supplier_id,Supplier_name,Supplier_Adress,Supplier_Phone,Company_name")] Supplier_details supplier_details)
        {
            if (ModelState.IsValid)
            {
                db.Supplier_details.Add(supplier_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier_details);
        }

        // GET: Supplier_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_details supplier_details = db.Supplier_details.Find(id);
            if (supplier_details == null)
            {
                return HttpNotFound();
            }
            return View(supplier_details);
        }

        // POST: Supplier_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supplier_id,Supplier_name,Supplier_Adress,Supplier_Phone,Company_name")] Supplier_details supplier_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier_details);
        }

        // GET: Supplier_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_details supplier_details = db.Supplier_details.Find(id);
            if (supplier_details == null)
            {
                return HttpNotFound();
            }
            return View(supplier_details);
        }

        // POST: Supplier_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_details supplier_details = db.Supplier_details.Find(id);
            db.Supplier_details.Remove(supplier_details);
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
