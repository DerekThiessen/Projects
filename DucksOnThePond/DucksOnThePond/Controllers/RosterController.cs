using DucksOnThePond.Core;
using System.Web.Mvc;

namespace DucksOnThePond.Controllers
{
    public class RosterController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePlayer(Player player)
        {
            if (ModelState.IsValid)
                return View("Result", player);
            else
                return View();
        }
    }
}
