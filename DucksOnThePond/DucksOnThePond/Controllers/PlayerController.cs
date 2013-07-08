using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DucksOnThePond.Core;

namespace DucksOnThePond.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult DataEntryForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DataEntryForm(Player player)
        {
            if (ModelState.IsValid)
                return View("Result", player);
            else
                return View();
        }
    }
}
