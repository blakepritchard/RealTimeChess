using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using AttributeRouting.Web.Http;
using RealTimeChessAlphaSevenFrontEnd.Models;
using Microsoft.Rest;
using System.Configuration;
using System.Web.Configuration;

namespace RealTimeChessAlphaSevenFrontEnd.RealTimeChess_API.Models
{
    public class ChessMatchesController : Controller
    {
        private Uri baseUri;
        private static BasicAuthenticationCredentials authCredsBasic;
        private RealTimeChessAPI apiChess;


        public ChessMatchesController()
        {
            string strRealTimeChessUri = WebConfigurationManager.AppSettings["RealTimeChessUri"];

            baseUri = new Uri(strRealTimeChessUri);
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: ChessMatches
        public ActionResult Index()
        {
            List<ChessMatch> lstMatches = apiChess.ApiChessMatchesGet().ToList<ChessMatch>();
            return View(lstMatches);
        }

        // GET: ChessMatches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ChessMatch chessMatch = db.ChessMatches.Find(id);
            ChessMatch chessMatch = (ChessMatch)apiChess.ApiChessMatchesByIdGet((int)id);
            if (chessMatch == null)
            {
                return HttpNotFound();
            }
            return View(chessMatch);
        }

        // GET: ChessMatches
        public ActionResult Join()
        {
            List<ChessMatch> lstMatches = apiChess.ApiChessMatchesGet().ToList<ChessMatch>();
            return View(lstMatches);
        }

        // GET: ChessMatches/Game/3
        [HttpGet]
        public ActionResult Game(int Id, int? MatchPlayerId)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ChessMatch chessMatch = db.ChessMatches.Find(id);
            ChessMatch chessMatch = (ChessMatch)apiChess.ApiChessMatchesByIdGet(Id);
            if (chessMatch == null)
            {
                return HttpNotFound();
            }

            ViewData["MatchPlayerId"] = MatchPlayerId;
            return View(chessMatch);
        }

        // GET: ChessMatches/Details/5
        [HttpGet]
        public ActionResult Clock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ChessMatch chessMatch = db.ChessMatches.Find(id);
            ChessMatch chessMatch = (ChessMatch)apiChess.ApiChessMatchesByIdGet((int)id);
            if (chessMatch == null)
            {
                return HttpNotFound();
            }
            return View(chessMatch);
        }

        // GET: ChessMatches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChessMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChessMatchId,PlayerTypeName,MatchStartTime,MatchEndTime,IsActive,IsDeleted,Created,Updated,Deleted")] ChessMatch chessMatch)
        {
            apiChess.ApiChessMatchesPost(chessMatch);
            return View(chessMatch);
        }

        // GET: ChessMatches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChessMatch chessMatch = (ChessMatch)apiChess.ApiChessMatchesByIdGet((int)id);
            if (chessMatch == null)
            {
                return HttpNotFound();
            }
            return View(chessMatch);
        }

        // POST: ChessMatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChessMatchId,PlayerTypeName,MatchStartTime,MatchEndTime,IsActive,IsDeleted,Created,Updated,Deleted")] ChessMatch chessMatch)
        {
            apiChess.ApiChessMatchesByIdPut((int)chessMatch.ChessMatchId, chessMatch);
            return RedirectToAction("Index");
        }

        // GET: ChessMatches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChessMatch chessMatch = (ChessMatch)apiChess.ApiChessMatchesByIdGet((int)id);
            if (chessMatch == null)
            {
                return HttpNotFound();
            }
            return View(chessMatch);
        }

        // POST: ChessMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apiChess.ApiChessMatchesByIdDelete((int)id);
            return RedirectToAction("Index");
        }

    }
}
