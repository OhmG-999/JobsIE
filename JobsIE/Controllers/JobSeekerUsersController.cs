using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobsIE.Models;

namespace JobsIE.Controllers
{
    public class JobSeekerUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobSeekerUsers
        public ActionResult Index()
        {
            return View(db.JobSeekerUsers.ToList());
        }

        // GET: JobSeekerUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerUser jobSeekerUser = db.JobSeekerUsers.Find(id);
            if (jobSeekerUser == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerUser);
        }

        // GET: JobSeekerUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeekerUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobSeekerUserID,JobSeekerName,JobSeekerPhoneNumber,JobSeekerDoB,LastLoginDate,JobSeekerExpertise,CVFiles")] JobSeekerUser jobSeekerUser)
        {
            if (ModelState.IsValid)
            {
                db.JobSeekerUsers.Add(jobSeekerUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobSeekerUser);
        }

        // GET: JobSeekerUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerUser jobSeekerUser = db.JobSeekerUsers.Find(id);
            if (jobSeekerUser == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerUser);
        }

        // POST: JobSeekerUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobSeekerUserID,JobSeekerName,JobSeekerPhoneNumber,JobSeekerDoB,LastLoginDate,JobSeekerExpertise,CVFiles")] JobSeekerUser jobSeekerUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeekerUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobSeekerUser);
        }

        // GET: JobSeekerUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobSeekerUser jobSeekerUser = db.JobSeekerUsers.Find(id);
            if (jobSeekerUser == null)
            {
                return HttpNotFound();
            }
            return View(jobSeekerUser);
        }

        // POST: JobSeekerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobSeekerUser jobSeekerUser = db.JobSeekerUsers.Find(id);
            db.JobSeekerUsers.Remove(jobSeekerUser);
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
