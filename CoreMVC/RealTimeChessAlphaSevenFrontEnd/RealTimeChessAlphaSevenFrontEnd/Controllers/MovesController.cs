using System;
using System.Collections.Generic;
using System.Configuration;
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
        private Configuration rootWebConfig1;
        private KeyValueConfigurationElement configRealTimeChessUri;

        public MovesController()
        {
            rootWebConfig1 = WebConfigurationManager.OpenWebConfiguration(null);
            configRealTimeChessUri = rootWebConfig1.AppSettings.Settings["RealTimeChessUri"];
            string strRealTimeChessUri = configRealTimeChessUri.Value;

            baseUri = new Uri(strRealTimeChessUri);
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: Moves
        public ActionResult Index()
        {
            List<Move> lstMoves = apiChess.ApiMovesGet().ToList<Move>();
            return View(lstMoves);
        }

        // GET: Moves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoveId,PlayerTypeName,MatchPlayerId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginMove,PositionEndMove,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            apiChess.ApiMovesPost(move);
            return View(move);
        }

        // GET: Moves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
        public ActionResult Edit([Bind(Include = "MoveId,PlayerTypeName,MatchPlayerId,AlgebraicChessNotation,GameClockBeginMove,GameClockEndMove,PositionBeginMove,PositionEndMove,IsDeleted,Created,Updated,Deleted")] Move move)
        {
            apiChess.ApiMovesByIdPut((int)move.MoveId, move);
            return RedirectToAction("Index");
        }

        // GET: Moves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            apiChess.ApiMovesByIdDelete(id);
            return RedirectToAction("Index");
        }
    }
}
