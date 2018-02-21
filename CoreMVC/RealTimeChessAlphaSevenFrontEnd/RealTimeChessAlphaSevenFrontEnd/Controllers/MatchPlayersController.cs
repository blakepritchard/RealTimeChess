using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealTimeChessAlphaSevenFrontEnd.Models;

namespace RealTimeChessAlphaSevenFrontEnd.Controllers
{
    public class MatchPlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MatchPlayers
        public ActionResult Index()
        {
            return View(db.MatchPlayers.ToList());
        }

        // GET: MatchPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            return View(matchPlayer);
        }

        // GET: MatchPlayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatchPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchPlayerId,ChessMatchId,PlayerId,PlayerTypeId,IsDeleted,Created,Updated,Deleted")] MatchPlayer matchPlayer)
        {
            if (ModelState.IsValid)
            {
                db.MatchPlayers.Add(matchPlayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matchPlayer);
        }

        // GET: MatchPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            return View(matchPlayer);
        }

        // POST: MatchPlayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchPlayerId,ChessMatchId,PlayerId,PlayerTypeId,IsDeleted,Created,Updated,Deleted")] MatchPlayer matchPlayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchPlayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matchPlayer);
        }

        // GET: MatchPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            if (matchPlayer == null)
            {
                return HttpNotFound();
            }
            return View(matchPlayer);
        }

        // POST: MatchPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatchPlayer matchPlayer = db.MatchPlayers.Find(id);
            db.MatchPlayers.Remove(matchPlayer);
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
