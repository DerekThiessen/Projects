using DucksOnThePond.Controllers;
using DucksOnThePond.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace DucksOnThePond.Tests.Controllers
{
    [TestClass]
    public class RosterControllTest
    {
        private Mock<IPlayerService> _playerService;

        public RosterControllTest()
        {
            _playerService = new Mock<IPlayerService>();
        }

        [TestMethod]
        public void RosterController_RendersOutRosterViewModel()
        {
            RosterController controller = new RosterController(_playerService.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RosterController_SetsViewBagTitle()
        {
            RosterController controller = new RosterController(_playerService.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Team Roster", result.ViewBag.Title);
        }
    }
}
