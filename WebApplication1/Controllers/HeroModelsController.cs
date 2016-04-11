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
    public class HeroModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HeroModels
        public ActionResult Index()
        {
            return View(db.Heroes.ToList());
        }
        public ActionResult List(string searchString)
        {
            var Heroes = from m in db.Heroes
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Heroes = Heroes.Where(s => s.heroName.Contains(searchString));
            }
            return View(Heroes);
        }
        
        // GET: HeroModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeroModel heroModel = db.Heroes.Find(id);
            if (heroModel == null)
            {
                return HttpNotFound();
            }
            return View(heroModel);
        }

        // GET: HeroModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeroModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,heroName,primaryAttribute,ranged,BAT,baseAgi,baseStr,baseInt,AgiGain,StrGain,IntGain,baseSpeed,baseDamage,baseArmor")] HeroModel heroModel)
        {
            if (ModelState.IsValid)
            {
                db.Heroes.Add(heroModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heroModel);
        }

        // GET: HeroModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeroModel heroModel = db.Heroes.Find(id);
            if (heroModel == null)
            {
                return HttpNotFound();
            }
            return View(heroModel);
        }

        // POST: HeroModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,heroName,primaryAttribute,ranged,BAT,baseAgi,baseStr,baseInt,AgiGain,StrGain,IntGain,baseSpeed,baseDamage,baseArmor")] HeroModel heroModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heroModel);
        }

        // GET: HeroModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeroModel heroModel = db.Heroes.Find(id);
            if (heroModel == null)
            {
                return HttpNotFound();
            }
            return View(heroModel);
        }

        // POST: HeroModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeroModel heroModel = db.Heroes.Find(id);
            db.Heroes.Remove(heroModel);
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
