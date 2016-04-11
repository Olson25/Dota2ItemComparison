using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BuildModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuildModels
        public ActionResult Index()
        {
            return View(db.Builds.ToList());
        }

        public ActionResult List(string searchString)
        {
            var Builds = from m in db.Builds
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Builds = Builds.Where(s => s.Hero.Contains(searchString));
            }
            return View(Builds);
        }
        // GET: BuildModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }

        // GET: BuildModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hero,Item1,Item2,Item3,Item4,Item5,Item6,MoonShardEaten,level")] BuildModel buildModel)
        {
            if (ModelState.IsValid)
            {
                db.Builds.Add(buildModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildModel);
        }

        // GET: BuildModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }

        // POST: BuildModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hero,Item1,Item2,Item3,Item4,Item5,Item6,MoonShardEaten,level")] BuildModel buildModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildModel);
        }

        // GET: BuildModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildModel buildModel = db.Builds.Find(id);
            if (buildModel == null)
            {
                return HttpNotFound();
            }
            return View(buildModel);
        }

        // POST: BuildModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildModel buildModel = db.Builds.Find(id);
            db.Builds.Remove(buildModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ListOfBuildsByHero(int ID)
        {
            var Build = db.Builds.Where(a => a.heroID == ID).ToList();
            var Hero = db.Heroes.Find(ID);
            ViewBag.BuildName = Hero.ID;
            return View(Build);

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
