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
    public class PlayerTypesController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        private Uri baseUri;
        private static BasicAuthenticationCredentials authCredsBasic;
        private RealTimeChessAPI apiChess;
        private Configuration rootWebConfig1;
        private KeyValueConfigurationElement configRealTimeChessUri;

        public PlayerTypesController()
        {
            rootWebConfig1 = WebConfigurationManager.OpenWebConfiguration(null);
            configRealTimeChessUri = rootWebConfig1.AppSettings.Settings["RealTimeChessUri"];
            string strRealTimeChessUri = configRealTimeChessUri.Value;

            baseUri = new Uri(strRealTimeChessUri);
            authCredsBasic = new BasicAuthenticationCredentials();
            apiChess = new RealTimeChessAPI(baseUri, authCredsBasic);
        }

        // GET: PlayerTypes
        public ActionResult Index()
        {
            //return View(db.PlayerTypes.ToList());
            return View(apiChess.ApiPlayerTypesGet());
        }

        // GET: PlayerTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlayerType playerType = db.PlayerTypes.Find(id);
            PlayerType playerType = apiChess.ApiPlayerTypesByIdGet((int)id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // GET: PlayerTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerTypeId,PlayerTypeName,TurnOrder")] PlayerType playerType)
        {
            apiChess.ApiPlayerTypesPost(playerType);
            return RedirectToAction("Index");
        }

        // GET: PlayerTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PlayerType playerType = db.PlayerTypes.Find(id);
            PlayerType playerType = apiChess.ApiPlayerTypesByIdGet((int)id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // POST: PlayerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerTypeId,PlayerTypeName,TurnOrder")] PlayerType playerType)
        {
            apiChess.ApiPlayerTypesByIdPut((int)playerType.PlayerTypeId, playerType);
            return RedirectToAction("Index");
        }

        // GET: PlayerTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerType playerType = apiChess.ApiPlayerTypesByIdGet((int)id);
            if (playerType == null)
            {
                return HttpNotFound();
            }
            return View(playerType);
        }

        // POST: PlayerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            apiChess.ApiPlayerTypesByIdDelete(id);
            return RedirectToAction("Index");
        }


    }
}
