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
    public class MovesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Moves
        public ActionResult Index()
        {
            return View(db.Moves.ToList());
        }

        // GET: Moves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Move move = db.Moves.Find(id);
            if (move == null)
            {
                return HttpNotFound();
            }
            return View(move);
        }

        // GET: Moves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoveId,ChessPieceId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginX,PositionBeginY,PositionEndX,PositionEndY,PositionCurrentX,PositionCurrentY,Distance,Velocity,TravelTime,Heading,HeadingSin,HeadingCos,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            if (ModelState.IsValid)
            {
                db.Moves.Add(move);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(move);
        }

        // GET: Moves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Move move = db.Moves.Find(id);
            if (move == null)
            {
                return HttpNotFound();
            }
            return View(move);
        }

        // POST: Moves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoveId,ChessPieceId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginX,PositionBeginY,PositionEndX,PositionEndY,PositionCurrentX,PositionCurrentY,Distance,Velocity,TravelTime,Heading,HeadingSin,HeadingCos,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            if (ModelState.IsValid)
            {
                db.Entry(move).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(move);
        }

        // GET: Moves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Move move = db.Moves.Find(id);
            if (move == null)
            {
                return HttpNotFound();
            }
            return View(move);
        }

        // POST: Moves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Move move = db.Moves.Find(id);
            db.Moves.Remove(move);
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
