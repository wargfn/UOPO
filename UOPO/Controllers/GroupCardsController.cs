using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UOPO.Models;

namespace UOPO.Controllers
{
    public class GroupCardsController : Controller
    {
        // Database Connection
        private ApplicationDbContext _context;
        
        // Context
        public GroupCardsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: GroupCards
        public ActionResult Index()
        {
            var groupCards = _context.GroupCards.ToList();

            return View(groupCards);
        }
        
        // GET: GroupCards/Random
        public ActionResult Random()
        {
            var groupCards = new GroupCards() { Name = "Test Card" };
            return View(groupCards);
        }

        // GET: GroupCards/ByRelease
        [Route("groupcards/byrelease/{set}/{cardid:regex(\\d{3}):range(1,50)}")]
        public ActionResult ByRelease(int set, int cardId)
        {
            return Content( set + " / " + cardId);
        }

        // GET: GroupCards/New -> Currently Dead Redirect to Index
        [Route("groupcards/new")]
        public ActionResult New()
        {
            return RedirectToAction("Index", "GroupCards");
        }

        public ActionResult Encounter()
        {
            var groupCards = _context.GroupCards.ToList();
            var days = 8; // Max Number of Days in NOM's Deck
            var tryantCard = 50;
            var day1 = 31;
            var day2 = 32;
            var day3 = 33;

            List<int> EncounterList = new List<int>
            {
                31,
                32,
                33
            };

            while (EncounterList.Count() < days)
            {
                int tempNum;
                Random rand = new Random();
                // rand.Next(0, groupCards.Count);
                // tempNum = rand.Next(0, groupCards.Count);
                tempNum = GetRandomNumber(1, groupCards.Count);
                EncounterList.Add(groupCards.ElementAt(tempNum).Id);
                groupCards.RemoveAt(tempNum);
                
                
                
            }

            var information = EncounterList.ToList().ToString();
            return Content(information);
        }

        // Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) //syncronize
            {
                return getrandom.Next(min, max);
            }
        }

    }

   
}
