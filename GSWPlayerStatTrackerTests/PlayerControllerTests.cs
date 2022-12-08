using GSWPlayerStatTracker.Controllers;
using GSWPlayerStatTracker.Data;
using GSWPlayerStatTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GSWPlayerStatTrackerTests
{
    [TestClass]
    public class PlayerControllerTests
    {
        private ApplicationDbContext _context;
        PlayersController controller;

        [TestInitialize] 
        public void Initialize() {

            //Setting up the inmemory db that's needed by the products controller
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            //Mock data Created
            var team = new Team
            {
                TeamId = 10,
                TeamName = "Test"
            };
            _context.Add(team);
            for(var i = 0; i <=3; i++)
            {
                var player = new Player
                {
                    TeamId = 10,
                    PlayerId= i,
                    PlayerName = "Player" + i.ToString(),
                    PointsPerGame = i+10,
                    Position = "Position" +i.ToString(),
                   // Team = team

                };
                _context.Add(player);
            }
            _context.SaveChanges();

            controller = new PlayersController(_context);

        }

        [TestMethod]
        public void DeleteIdNullLoads404()
        {
           
            var result = (ViewResult)controller.Delete(null).Result;

            Assert.AreEqual("404", result.ViewName);
        }


        [TestMethod]
        public void DeleteNoPlayerLoads404()
        {
            _context.Players = null;
            var result = (ViewResult)controller.Delete(2).Result;
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidIdLoads404()
        {

            var result = (ViewResult)controller.Delete(400).Result;
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidPlayerLoadsPlayer()
        {
            var result = (ViewResult)controller.Delete(1).Result;
            var model = (Player)result.Model;
            Assert.AreEqual(_context.Players.Find(1), model);
        }

        [TestMethod]
        public void DeleteValidPlayerIdLoadsDeleteView()
        {
            var results =(ViewResult)controller.Delete(2).Result;
            Assert.AreEqual("Delete", results.ViewName);
        }

        [TestMethod]
        public void DeleteValidPlayer()
        {
            //var player =_context.Players.Find(1);
            _context.Players = null;
           
            var result = (ViewResult)controller.DeleteConfirmed(2).Result;          

            Assert.AreEqual("NotFound", result.ViewName);
        }
        [TestMethod]
        public void DeleteRedirectsView()
        {
            var result = (RedirectToActionResult)controller.DeleteConfirmed(1).Result;

            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void DeletedPlayerNotNull()
        {
            Player player = new Player();
            player.PlayerId= 1;
            var ID = player.PlayerId;
            //var delete = _context.Remove(player);

            var result = controller.DeleteConfirmed(player.PlayerId).Result;

            Assert.AreEqual(_context.Players.Remove(player),result);
        }

    }
}