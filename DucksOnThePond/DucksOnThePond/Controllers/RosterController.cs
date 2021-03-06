﻿using DucksOnThePond.Core.Interfaces;
using DucksOnThePond.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using DucksOnThePond.Models;

namespace DucksOnThePond.Controllers
{
    public class RosterController : Controller
    {
        private IPlayerService _playerService;

        public RosterController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Team Roster";

            RosterViewModel rosterViewModel = new RosterViewModel();
            rosterViewModel.Players = new List<Player>();
            rosterViewModel.Players = _playerService.GetAllPlayers();

            return View(rosterViewModel);
        }
    }
}
