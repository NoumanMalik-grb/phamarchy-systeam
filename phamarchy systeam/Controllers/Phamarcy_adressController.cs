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
    public class Phamarcy_adressController : Controller
    {
        private Model1 db = new Model1();

        // GET: Phamarcy_adress
        public ActionResult Index()
        {
            return View(db.Phamarcy_adress.ToList());
        }

        // GET: Phamarcy_adress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phamarcy_adress phamarcy_adress = db.Phamarcy_adress.Find(id);
            if (phamarcy_adress == null)
            {
                return HttpNotFound();
            }
            return View(phamarcy_adress);
        }

        // GET: Phamarcy_adress/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phamarcy_adress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_id,Company_name,Company_adress,Company_Phone,Company_emails,Company_licinces,Company_logo")] Phamarcy_adress phamarcy_adress)
        {
            if (ModelState.IsValid)
            {
                db.Phamarcy_adress.Add(phamarcy_adress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phamarcy_adress);
        }

        // GET: Phamarcy_adress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phamarcy_adress phamarcy_adress = db.Phamarcy_adress.Find(id);
            if (phamarcy_adress == null)
            {
                return HttpNotFound();
            }
            return View(phamarcy_adress);
        }

        // POST: Phamarcy_adress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_id,Company_name,Company_adress,Company_Phone,Company_emails,Company_licinces,Company_logo")] Phamarcy_adress phamarcy_adress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phamarcy_adress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phamarcy_adress);
        }

        // GET: Phamarcy_adress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phamarcy_adress phamarcy_adress = db.Phamarcy_adress.Find(id);
            if (phamarcy_adress == null)
            {
                return HttpNotFound();
            }
            return View(phamarcy_adress);
        }

        // POST: Phamarcy_adress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phamarcy_adress phamarcy_adress = db.Phamarcy_adress.Find(id);
            db.Phamarcy_adress.Remove(phamarcy_adress);
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
