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
    public class CVFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CVFiles
        public ActionResult Index()
        {
            var cVFiles = db.CVFiles.Include(c => c.JobSeekerUser);
            return View(cVFiles.ToList());
        }

        // GET: CVFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVFile cVFile = db.CVFiles.Find(id);
            if (cVFile == null)
            {
                return HttpNotFound();
            }
            return View(cVFile);
        }

        // GET: CVFiles/Create
        public ActionResult Create()
        {
            ViewBag.JobSeekerUserID = new SelectList(db.JobSeekerUsers, "JobSeekerUserID", "JobSeekerName");
            return View();
        }

        // POST: CVFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobSeekerUserID,Filename,FileContent,FileLastUpdated")] CVFile cVFile)
        {
            if (ModelState.IsValid)
            {
                db.CVFiles.Add(cVFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobSeekerUserID = new SelectList(db.JobSeekerUsers, "JobSeekerUserID", "JobSeekerName", cVFile.JobSeekerUserID);
            return View(cVFile);
        }

        // GET: CVFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVFile cVFile = db.CVFiles.Find(id);
            if (cVFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobSeekerUserID = new SelectList(db.JobSeekerUsers, "JobSeekerUserID", "JobSeekerName", cVFile.JobSeekerUserID);
            return View(cVFile);
        }

        // POST: CVFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobSeekerUserID,Filename,FileContent,FileLastUpdated")] CVFile cVFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cVFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobSeekerUserID = new SelectList(db.JobSeekerUsers, "JobSeekerUserID", "JobSeekerName", cVFile.JobSeekerUserID);
            return View(cVFile);
        }

        // GET: CVFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CVFile cVFile = db.CVFiles.Find(id);
            if (cVFile == null)
            {
                return HttpNotFound();
            }
            return View(cVFile);
        }

        // POST: CVFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CVFile cVFile = db.CVFiles.Find(id);
            db.CVFiles.Remove(cVFile);
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
