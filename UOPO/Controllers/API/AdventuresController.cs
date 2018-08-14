using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UOPO.Models;

namespace UOPO.Controllers.API
{
    public class AdventuresController : ApiController
    {
        private ApplicationDbContext _context;

        public AdventuresController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/Adventures
        public IEnumerable<GroupCards> GetGroupCards()
        {
            var groupCards = _context.GroupCards.ToList();

            if (groupCards == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return groupCards;
        }

        // GET /API/GrouPCards/1
        public GroupCards GetGroupCards(int id)
        {
            var groupCard = _context.GroupCards.SingleOrDefault(C => C.Id == id);

            if (groupCard == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return groupCard;
        }


        // Post /api/GroupCards
        [HttpPost]
        public GroupCards CreateGroupCards(GroupCards groupCard)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.GroupCards.Add(groupCard);
            _context.SaveChanges();

            return groupCard;
        }

        // Post /API/GroupCards/1
        [HttpPut]
        public void UpdateGroupCard(int id, GroupCards groupCard)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            groupCardInDB.Name = groupCard.Name;
            groupCardInDB.FrontText = groupCard.FrontText;
            groupCardInDB.BackTextOption1 = groupCard.BackTextOption1;
            groupCardInDB.BackTextOption2 = groupCard.BackTextOption2;
            groupCardInDB.BackTextOption3 = groupCard.BackTextOption3;
            groupCardInDB.RewardsOption1 = groupCard.RewardsOption1;
            groupCardInDB.RewardsOption2 = groupCard.RewardsOption2;
            groupCardInDB.RewardsOption3 = groupCard.RewardsOption3;
            groupCardInDB.Reward = groupCard.Reward;
            groupCardInDB.CardSet = groupCard.CardSet;
            groupCardInDB.CardType = groupCard.CardType;
            groupCardInDB.CardNum = groupCard.CardNum;

            _context.SaveChanges();

        }

        // DELETE /api/GroupCards/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var groupCardInDB = _context.GroupCards.SingleOrDefault(c => c.Id == id);

            if (groupCardInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.GroupCards.Remove(groupCardInDB);
            _context.SaveChanges();
        }
    }
}
