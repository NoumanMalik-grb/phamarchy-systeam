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
    public class User_detailsController : Controller
    {
        private Model1 db = new Model1();

        // GET: User_details
        public ActionResult Index()
        {
            return View(db.User_details.ToList());
        }

        // GET: User_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_details user_details = db.User_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // GET: User_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_id,User_name,User_email,User_password,User_type,User_working_time,User_phone,User_adress,User_salary")] User_details user_details)
        {
            if (ModelState.IsValid)
            {
                db.User_details.Add(user_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_details);
        }

        // GET: User_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_details user_details = db.User_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // POST: User_details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_id,User_name,User_email,User_password,User_type,User_working_time,User_phone,User_adress,User_salary")] User_details user_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_details);
        }

        // GET: User_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_details user_details = db.User_details.Find(id);
            if (user_details == null)
            {
                return HttpNotFound();
            }
            return View(user_details);
        }

        // POST: User_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_details user_details = db.User_details.Find(id);
            db.User_details.Remove(user_details);
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
