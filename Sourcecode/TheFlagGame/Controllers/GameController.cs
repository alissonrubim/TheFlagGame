using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheFlagGame.Helpers;
using TheFlagGame.Models;

namespace TheFlagGame.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Flags(int Id)
        {
            Player player = System.Web.HttpContext.Current.Session["Player"] as Player;

            if (player == null)
            {
                player = new Player();
                player.GenerateDrawnFlags(Global.FlagsStorage);
            }

            if (player.PlayerFlags.Where(p => p.ChoiseFlag == null).Count() > 0 && player.PlayerFlags.Count() != Id)
            {
                return RedirectToAction("Flags", new { Id = player.PlayerFlags.Count() });
            }

            DrawnFlags currentDrawnFlag = player.DrawnFlags[Id - 1];
            Flag answer = currentDrawnFlag.Answer;
            List<Flag> options = currentDrawnFlag.Options;

            if (player.PlayerFlags.Count() > Id - 1)
            {
                player.PlayerFlags.RemoveAt(Id - 1);
            }

            player.PlayerFlags.Add(new PlayerFlag()
            {
                CorrectFlag = answer,
                ChoiseFlag = null
            });

            System.Web.HttpContext.Current.Session["Player"] = player;
          
            return View(new ViewFlags()
            {
                CurrentGameIndex = Id,
                Answer = answer,
                Options = options
            });
        }

        [HttpPost]
        public JsonResult Score(Guid index)
        {
            dynamic result = new { Scored = false };
            Flag answer = Global.FlagsStorage.GetById(index);
            Player player = System.Web.HttpContext.Current.Session["Player"] as Player;
            if (answer != null && player != null)
            {
                player.PlayerFlags.Last().ChoiseFlag = answer;
                result = new { Scored = player.PlayerFlags.Last().ChoiseFlag.Id == player.PlayerFlags.Last().CorrectFlag.Id };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFlagImage(Guid Index)
        {
            Flag currentFlag = Global.FlagsStorage.GetById(Index);
            if (currentFlag == null)
                throw new Exception("The flag was not found!");

            var path = Path.Combine(Server.MapPath("/App_Data"), currentFlag.ImagePath);
            return base.File(path, "image/png");
        }

        public ActionResult Result()
        {
            if (System.Web.HttpContext.Current.Session["Player"] == null)
                return RedirectToAction("Index");

            Player player = System.Web.HttpContext.Current.Session["Player"] as Player;

            if(player.PlayerFlags.Where(p => p.ChoiseFlag == null).Count() > 0)
                return RedirectToAction("Flags", new { Id = 1 });

            System.Web.HttpContext.Current.Session["Player"] = null;
            return View(new Models.ViewResult()
            {
                PlayerFlags = player.PlayerFlags,
                TotalPoints = player.PlayerFlags.Where(p => p.ChoiseFlag.Id == p.CorrectFlag.Id).Sum(p => p.CorrectFlag.Weight * 10)
        });
        }
    }
}