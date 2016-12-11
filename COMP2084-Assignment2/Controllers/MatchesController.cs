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
using System.Web.Helpers;

namespace COMP2084_Assignment2.Controllers
{
    [Authorize]
    public class MatchesController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        public ActionResult getWinLossChart()
        {
            int wins = (from a in db.Matches
                       where a.result.Equals(true)
                       select a).Count();
            int losses = (from a in db.Matches
                        where a.result.Equals(false)
                        select a).Count();

            var myChart = new Chart(width: 1000, height: 600)
            .AddTitle("Match Statistics")
            .AddSeries(
                name: "Games Won",
                chartType: "Pie",
                xValue: new[] { String.Concat("Wins (", (wins/(wins+losses))*100,"%)"), String.Concat("Losses (", (losses / (wins + losses)) * 100, "%)") },
                yValues: new[] { wins, losses }
                )
            .Write();

            String fileName = String.Concat(DateTime.Now.Ticks);
            myChart.Save("~/Content/Charts" + fileName, "jpeg");

            return base.File("~/Content/Charts" + fileName, "jpeg");
        }



        // GET: Matches
        public ActionResult Index()
        {
            String userId = User.Identity.GetUserId();
            var matches = db.Matches.Include(m => m.Class).Include(m => m.Class1).Include(m => m.Map1).Where(
                m=>m.user_id == userId
                );
            return View(matches.ToList());
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            String userId = User.Identity.GetUserId();
            Match match = db.Matches.Single(m => m.id==id && m.user_id==userId);
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
