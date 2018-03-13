using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Rest;
using RealTimeChessAlphaSevenFrontEnd.Models;

namespace RealTimeChessAlphaSevenFrontEnd.Controllers
{
    public class MovesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private Uri baseUri;
        private static BasicAuthenticationCredentials authCredsBasic;
        private RealTimeChessAPI apiChess;

        public MovesController()
        {
            string strRealTimeChessUri = WebConfigurationManager.AppSettings["RealTimeChessUri"];
            baseUri = new Uri(strRealTimeChessUri);
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: Moves
        public ActionResult Index()
        {
            //return View(db.Moves.ToList());
            return View(apiChess.ApiMovesGet().ToList<Move>());
        }

        // GET: Moves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Move move = db.Moves.Find(id);
            Move move = apiChess.ApiMovesByIdGet((int)id);
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
        // [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoveId,ChessPieceId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginX,PositionBeginY,PositionEndX,PositionEndY,PositionCurrentX,PositionCurrentY,Distance,Velocity,TravelTime,Heading,HeadingSin,HeadingCos,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            if (ModelState.IsValid)
            {
                //db.Moves.Add(move);
                //db.SaveChanges();
                apiChess.ApiMovesPost(move);
                return RedirectToAction("Game");
            }

            // return View(move);
            return RedirectToAction("Game");
        }

        // POST: Moves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Begin([Bind(Include = "MoveId,ChessPieceId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginX,PositionBeginY,PositionEndX,PositionEndY,PositionCurrentX,PositionCurrentY,Distance,Velocity,TravelTime,Heading,HeadingSin,HeadingCos,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            if (ModelState.IsValid)
            {
                //db.Moves.Add(move);
                //db.SaveChanges();

                apiChess.ApiMovesBeginMovePost((int)move.ChessPieceId, (int)move.PositionEndX, (int)move.PositionEndY);
            }
            var result = new { Success = "True", Message = "Moved" };
            return Json(result, JsonRequestBehavior.AllowGet);
            // return View(move);
            // return new EmptyResult();
            // var strUrl = Request.UrlReferrer.ToString();
            // return Redirect(strUrl);
            // return RedirectToAction("Game", "ChessMatches", new {Id=3, MatchPlayerId=1 });
        }

        // GET: Moves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Move move = db.Moves.Find(id);
            Move move = apiChess.ApiMovesByIdGet((int)id);
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
                //db.Entry(move).State = EntityState.Modified;
                //db.SaveChanges();
                apiChess.ApiMovesByIdPut((int)move.MoveId, move);
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
            // Move move = db.Moves.Find(id);
            Move move = apiChess.ApiMovesByIdGet((int)id);
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
            //Move move = db.Moves.Find(id);
            //db.Moves.Remove(move);
            //db.SaveChanges();
            apiChess.ApiMovesByIdDelete((int)id);
            return RedirectToAction("Index");
        }

    }
}
