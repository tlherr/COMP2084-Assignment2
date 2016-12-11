using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2084_Assignment2;
using Microsoft.AspNet.Identity;

namespace COMP2084_Assignment2.Controllers
{
    public class MatchesController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        // GET: Matches
        public ActionResult Index()
        {
            var matches = db.Matches.Include(m => m.Class).Include(m => m.Class1).Include(m => m.Map1);
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: Matches/Create
        public ActionResult Create()
        {
            ViewBag.opponent_one = new SelectList(db.Classes, "id", "name");
            ViewBag.opponent_two = new SelectList(db.Classes, "id", "name");
            ViewBag.map = new SelectList(db.Maps, "id", "name");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,result,notes,map,opponent_one,opponent_two,user_id")] Match match)
        {
            match.user_id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.opponent_one = new SelectList(db.Classes, "id", "name", match.opponent_one);
            ViewBag.opponent_two = new SelectList(db.Classes, "id", "name", match.opponent_two);
            ViewBag.map = new SelectList(db.Maps, "id", "name", match.map);
            return View(match);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.opponent_one = new SelectList(db.Classes, "id", "name", match.opponent_one);
            ViewBag.opponent_two = new SelectList(db.Classes, "id", "name", match.opponent_two);
            ViewBag.map = new SelectList(db.Maps, "id", "name", match.map);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,result,notes,map,opponent_one,opponent_two,user_id")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.opponent_one = new SelectList(db.Classes, "id", "name", match.opponent_one);
            ViewBag.opponent_two = new SelectList(db.Classes, "id", "name", match.opponent_two);
            ViewBag.map = new SelectList(db.Maps, "id", "name", match.map);
            return View(match);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
