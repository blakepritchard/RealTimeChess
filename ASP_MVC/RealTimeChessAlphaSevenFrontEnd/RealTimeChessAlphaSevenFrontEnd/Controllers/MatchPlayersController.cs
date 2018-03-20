using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using RealTimeChessAlphaSevenFrontEnd.Models;
using Microsoft.Rest;

namespace RealTimeChessAlphaSevenFrontEnd.Controllers
{
    public class MatchPlayersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private Uri baseUri;
        private static BasicAuthenticationCredentials authCredsBasic;
        private RealTimeChessAPI apiChess;
        private Configuration rootWebConfig1;
        private KeyValueConfigurationElement configRealTimeChessUri;

        public MatchPlayersController()
        {
            string strRealTimeChessUri = WebConfigurationManager.AppSettings["RealTimeChessUri"];

            baseUri = new Uri(strRealTimeChessUri);
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: MatchPlayers
        public ActionResult Index()
        {
            List<MatchPlayer> lstMatches = apiChess.ApiMatchPlayersGet().ToList<MatchPlayer>();
            return View(lstMatches);
        }

        // GET: MatchPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = apiChess.ApiMatchPlayersByIdGet((int)id);
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
            apiChess.ApiMatchPlayersPost(matchPlayer);
            return View(matchPlayer);
        }

        // POST: MatchPlayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int ChessMatchId, int PlayerId)
        {
            ViewData["ChessMatchId"] = ChessMatchId;
            ViewData["PlayerId"] = PlayerId;
            return View();
        }

        // GET: MatchPlayers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = apiChess.ApiMatchPlayersByIdGet((int)id);
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
            apiChess.ApiMatchPlayersByIdPut((int)matchPlayer.ChessMatchId, matchPlayer);
            return RedirectToAction("Index");
        }

        // GET: MatchPlayers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatchPlayer matchPlayer = apiChess.ApiMatchPlayersByIdGet((int)id);
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
            apiChess.ApiMatchPlayersByIdDelete((int)id);
            return RedirectToAction("Index");
        }
    }
}
