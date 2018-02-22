using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using RealTimeChessAlphaSevenFrontEnd.Models;

namespace RealTimeChessAlphaSevenFrontEnd.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // private TokenCredentials authTokenCreds = new TokenCredentials("<bearer token>");
        private Uri baseUri;
        private static BasicAuthenticationCredentials authCredsBasic;
        private RealTimeChessAPI apiChess;

        public PlayersController()
        {
            baseUri = new Uri("https://localhost:44373/");
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: Players
        public ActionResult Index()
        {
            List<Player> lstPlayers = apiChess.ApiPlayersGet().ToList<Player>();
            return View(lstPlayers);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = FindPlayerById((int)id);

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);

        }


        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,AuthenticationId,FirstName,LastName,NumWins,NumLosses,IsActive,IsDeleted,Created,Updated,Deleted")] Player player)
        {
            /*
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            */

            apiChess.ApiPlayersPost(player);
            return RedirectToAction("Index");

        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Player player = db.Players.Find(id);
            Player player = FindPlayerById((int)id);

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,AuthenticationId,FirstName,LastName,NumWins,NumLosses,IsActive,IsDeleted,Created,Updated,Deleted")] Player player)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(player).State = EntityState.Modified;
                // db.SaveChanges();
                apiChess.ApiPlayersByIdPut((int)player.PlayerId, player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Player player = db.Players.Find(id);
            Player player = FindPlayerById((int)id);

            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);

        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Player player = db.Players.Find(id);
            //db.Players.Remove(player);
            //db.SaveChanges();

            Player player = FindPlayerById((int)id);
            return RedirectToAction("Index");

        }

        protected Player FindPlayerById(int id)
        {
            Player players = (Player)apiChess.ApiPlayersByIdGet((int)id);
            return players;
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
